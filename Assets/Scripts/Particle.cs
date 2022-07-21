using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] float _mass = 1;
    [SerializeField] Vector3 _vel = new Vector2(1,1);
    [SerializeField] float _velLimit = 1;

    [SerializeField] float _gConstant = 1;
    [SerializeField] float _disMax, _disMin;
    Vector3 _acc = Vector3.zero; 

    void Start()
    {
        _vel = Random.insideUnitCircle * _velLimit;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        _acc = Vector3.zero;

        Particle otherBody = other.GetComponent<Particle>();

        float attraction = Attract(otherBody);

        Vector3 dir = otherBody.transform.position - transform.position;
        Vector3 gravitationalForce = dir.normalized * attraction * Time.deltaTime;
        ApplyForce(gravitationalForce);

        _vel += _acc;

        _vel = Vector3.ClampMagnitude(_vel, _velLimit);

        transform.position += _vel * Time.deltaTime; 
    }

    public float Attract(Particle particle)
    {
        float d = Vector3.Distance(particle.transform.position, transform.position);

        d = Mathf.Clamp(d, _disMin, _disMax);

        float attraction = (_mass * particle._mass) / (d * d) * _gConstant;
        return attraction;
    }

    void ApplyForce(Vector3 force)
    {
        Vector3 acc = force / _mass;
        _acc += acc *Time.deltaTime;
    }
}
