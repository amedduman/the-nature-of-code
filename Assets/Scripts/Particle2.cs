using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle2 : MonoBehaviour
{
    [SerializeField] float _maxSpeed = 1;
    [SerializeField] Vector2 _vel;
    [SerializeField] Vector2 _acc;
    Vector2 _pos;


    private void Start()
    {
        _pos = new Vector2(transform.position.x, transform.position.y);
    }

    private void Update()
    {
        _vel += _acc;
        _vel = Vector2.ClampMagnitude(_vel, _maxSpeed);
        _pos += _vel;
        transform.position = _pos;
    }
}
