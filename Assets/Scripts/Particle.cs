using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public float _mass = 1;

    [SerializeField] Vector3 _vel = new Vector2(1,1);
    [SerializeField] float _velLimit = 1;
    [SerializeField] Attractor _attractor;

    Vector3 _acc = Vector3.zero; 

    void Start()
    {
        _velLimit = Random.Range(5, 15);
        Time.timeScale = 10;
        _vel = Random.insideUnitCircle * _velLimit;
        //GetComponentInChildren<TrailRenderer>().material.color = Random.ColorHSV();
    }


    void Update()
    {
        _acc = Vector3.zero;

        float attraction = _attractor.Attract(this);

        Vector3 dir = (_attractor.transform.position - transform.position).normalized;

        ApplyForce(dir * attraction);
        
        _vel += _acc;

        _vel = Vector3.ClampMagnitude(_vel, _velLimit);

        //Debug.DrawRay(transform.position, _vel);

        transform.position += _vel * Time.deltaTime; 
    }

    void ApplyForce(Vector3 force)
    {
        Vector3 acc = force / _mass;
        _acc += acc *Time.deltaTime;
    }
}
