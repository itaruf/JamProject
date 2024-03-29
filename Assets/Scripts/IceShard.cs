using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceShard : MonoBehaviour
{
    [SerializeField] float _movingSpeed = 6f;
    [SerializeField] float _speedBonus = 1f;

    [SerializeField] private float _delayBeforeLaunch = 1.0f;
    [SerializeField] private float _xPositionLowerBound = -8.39f;
    [SerializeField] private float _xPositionUpperBound = 8.39f;
    [SerializeField] private float _yPosition = -2.57f;
    private bool _isLaunched;
    private SpriteRenderer _sprite;

    private Rigidbody2D _rb;

    void Start()
    {
        //Spawning ice shard either at _xPositionLower or _xPositionUpper
        transform.position = new Vector3((Random.Range(0,2) == 0 ? _xPositionLowerBound: _xPositionUpperBound ), _yPosition,0);
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        // Event.current._onHalfWayMinGame += SpeedUp;
        //flipping assets if we spawned on the left side of the screen
        if (transform.position.x < 0)
        {
            _sprite.flipX = true;
        }

        StartCoroutine(PrepareLaunchingCoroutine());
    }

    private void SpeedUp()
    {
        _movingSpeed += _speedBonus;
    }

    IEnumerator PrepareLaunchingCoroutine()
    {
        yield return new WaitForSeconds(_delayBeforeLaunch);
        _isLaunched = true;
    }

    private Vector3 DirectionFacingVector()
    {
        if (!_sprite.flipX)
        {
            return Vector3.left;
        }

        return Vector3.right;
        
    }
    // Update is called once per frame
    void Update()
    {
        if (!_isLaunched)
        {
            return;
        }
        
        transform.Translate(DirectionFacingVector() * _movingSpeed *Time.deltaTime);


            
        CheckIfOutOfBounds();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collided with player");
            Event.current.OnGameLost();
            Destroy(gameObject);
        }

    }

    private void CheckIfOutOfBounds()
    {
        
        if (transform.position.x < -9.0 || transform.position.x > 9.0)
        {
            Destroy(gameObject);
            SpeedUp();
        }
    }
}