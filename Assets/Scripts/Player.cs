using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _moveSpeed = 100f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
    }

    private void Update()
    {
        float vertical = PlayerInput.Vertical;
        _rigidbody.AddForce(0, 0, vertical * _moveSpeed);
    }

    public IPlayerInput PlayerInput { get; set; }
}
