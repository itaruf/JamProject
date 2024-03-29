using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float _movingSpeed = 2.0f;
    [SerializeField] float _speedBonus = 0.1f;
    [SerializeField] private float _xPositionLowerBound;
    [SerializeField] private float _xPositionUpperBound;
    [SerializeField] private float _yPosition;

    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(_xPositionLowerBound, _xPositionUpperBound), _yPosition,0);
        _rb = GetComponent<Rigidbody2D>();

        Event.current._onCollectLava += SpeedUp;
    }

    private void SpeedUp(float value)
    {
        _movingSpeed += _speedBonus;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _movingSpeed *Time.deltaTime);
        CheckIfOutOfBounds();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bucket"))
        {
            // Debug.Log("Collided with bucket");
            Destroy(gameObject);
        }

        else if (other.CompareTag("Ground"))
        {
            // Debug.Log("Collided with Ground");
            Event.current.OnGameLost();
        }
    }

    private void CheckIfOutOfBounds()
    {
        
        if (transform.position.y < -6.0)
        {
            Destroy(gameObject);
        }
    }
}
