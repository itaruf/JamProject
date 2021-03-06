using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] AnimatorController _animatorController = null;
    [SerializeField] Rigidbody2D _rb = null;

    // Inputs
    [Header("Input")]
    [SerializeField] PlayerInput _inputAction = null;
    [SerializeField] InputActionReference _move = null;
    [SerializeField] InputActionReference _jump = null;
    [SerializeField] InputActionReference _rolldice = null;
    [SerializeField] InputActionReference _kick = null;
    // Movement
    [Header("Movement")]
    [SerializeField] float _ms = 2;
    [SerializeField] float _jumpForce = 5;
    Vector2 moveValue = new Vector2(0, 0);

    public bool _isJumping = false;
    public bool _canRollDice = false;
    public bool _isKicking = false;
    public Vector2 Direction { get; private set; }
    public void PrepareDirection(Vector2 v) => Direction = v.normalized;
    Coroutine MovementTracking { get; set; }

    [SerializeField] Dice _dice = null;
    [SerializeField] Bucket _bucket = null;

    // Icons
    [SerializeField] Icon _rolldiceIcon = null;

    void Awake()
    {
        Event.current._onRollDiceStarted += () => { _canRollDice = false; };
        /*Event.current._onRollDiceEnded += () => { _canRollDice = false; };*/

        if (_rolldiceIcon)
            Event.current._onRollDiceStarted += _rolldiceIcon.Deactivation;
        
        if (!_rb)
            TryGetComponent(out _rb);

        if (!_animatorController)
            TryGetComponent(out _animatorController);

        _move.action.started += MoveInput;
        _move.action.canceled += MoveCanceled;

        _jump.action.performed += JumpInput;
        _jump.action.canceled += JumpCanceled;

        _kick.action.performed += KickInput;
        _kick.action.canceled += KickCanceled;
        
        Event.current._onCollectLava += IncreaseMS;
        /*_rolldice.action.started += RollDiceInput;*/
    }

    private void IncreaseMS(float value)
    {
        _ms += value;
    }

    private void RollDiceInput(InputAction.CallbackContext obj)
    {
        if (!_canRollDice)
            return;

        _animatorController._animator.SetTrigger(Animator.StringToHash("RollDice"));

        _dice._animatorController._sprite.enabled = true;
        _dice._animatorController._animator.SetBool(Animator.StringToHash("DiceThrow"), true);

        StartCoroutine(_dice.Result());
    }

    private void JumpCanceled(InputAction.CallbackContext obj)
    {
        /*jumpForce = 0;*/
    }

    private void JumpInput(InputAction.CallbackContext obj)

    {   if (_isJumping)
            return;

        _isJumping = true;
        _rb.AddForce((Vector2.up * _jumpForce), ForceMode2D.Impulse);
    }
    
    private void KickCanceled(InputAction.CallbackContext obj)
    {
        
    }
    
    private void KickInput(InputAction.CallbackContext obj)

    {   
        // _animatorController._animator.Play("ThrowDice");
        Event.current.Kick();
    }

    public void Endkick()
    {
        _isKicking = false;
    }
    private void OnDestroy()
    {
        _move.action.started -= MoveInput;
        _move.action.canceled -= MoveCanceled;

        _jump.action.performed -= JumpInput;
        _jump.action.performed -= MoveCanceled;

        _rolldice.action.started -= RollDiceInput;
        
        _kick.action.performed -= KickInput;
        _kick.action.canceled -= KickCanceled;
    }

    void FixedUpdate()
    {
        /*if (MovementTracking != null)
            _rb.MovePosition(_rb.position + (Direction * _ms) * Time.fixedDeltaTime);*/

        Move();
    }

    private void MoveInput(InputAction.CallbackContext obj)
    {
        /*   if (MovementTracking != null)
               return;

           MovementTracking = StartCoroutine(MovementTrackingRoutine());
           IEnumerator MovementTrackingRoutine()
           {
               while (true)
               {
                   PrepareDirection(obj.ReadValue<Vector2>());
                   _animatorController.FlipX(obj.ReadValue<Vector2>());
                   yield return null;

                   _rb.MovePosition(_rb.position + (Direction * _ms) * Time.fixedDeltaTime);
               }
           }*/

        moveValue = obj.ReadValue<Vector2>();
        _animatorController.FlipX(obj.ReadValue<Vector2>());
        _animatorController._animator.SetBool(Animator.StringToHash("IsMoving"), true);

        if (_bucket)
        {
            switch (moveValue)
            {
                case Vector2 v when v.Equals(Vector2.left):
                    _bucket.transform.position = transform.TransformPoint(-_bucket._offset.x, _bucket._offset.y, 0); 
                    break;
                case Vector2 v when v.Equals(Vector2.right):
                    _bucket.transform.position = transform.TransformPoint(_bucket._offset.x, _bucket._offset.y, 0);
                    break;
            }
        }
    }

    private void Move()
    {
        transform.Translate(moveValue * Time.fixedDeltaTime * _ms);
    }

    public void MoveCanceled(InputAction.CallbackContext obj)
    {
        moveValue = new Vector2(0, 0);
        _animatorController._animator.SetBool(Animator.StringToHash("IsMoving"), false);

        if (MovementTracking == null)
            return;

        StopCoroutine(MovementTracking);
        MovementTracking = null;
        PrepareDirection(Vector2.zero);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Foreground") ||collision.gameObject.CompareTag("Ground"))
            _isJumping = false;

        if (collision.gameObject.TryGetComponent(out Dice dice) && _canRollDice)
        {
            _rolldice.action.started += RollDiceInput;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Dice dice) && _canRollDice)
        {
            _rolldice.action.started -= RollDiceInput;
        }
    }
}
