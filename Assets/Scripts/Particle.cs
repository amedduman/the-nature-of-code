using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] Vector3 _gravity = new Vector3(0, -9.8f, 0);
    [SerializeField] Vector3 _wind = new Vector3(1, 0, 0);
    float _bottomEdgeHeight;
    Vector3 _vel = Vector3.zero;
    Vector3 _acc = Vector3.zero;

    private void Start()
    {
        _bottomEdgeHeight = -Camera.main.orthographicSize;
    }

    void Update()
    {
        _acc = Vector3.zero;

        ApplyForce(_gravity);

        if(Input.GetKey(KeyCode.Mouse0))
        {
            ApplyForce(_wind);
        }

        if(Input.GetKey(KeyCode.Mouse1))
        {
            ApplyForce(_wind * -1);
        }

        Edges();

        _vel += _acc;


        transform.position += _vel * Time.deltaTime;;
    }

    void ApplyForce(Vector3 force)
    {
        _acc += force * Time.deltaTime;
    }

    void Edges()
    {
        Vector3 pos = transform.position;

        float up = Camera.main.orthographicSize;
        float bottom = -Camera.main.orthographicSize;
        float right = Camera.main.orthographicSize;
        float left = -Camera.main.orthographicSize;

        

        if(pos.y  <= bottom)
        {
            pos.y = bottom;
            transform.position = pos;
            _vel.y *= -1;
        }
        else if(pos.y  >= up)
        {
            pos.y = up;
            transform.position = pos;
            _vel.y *= -1;
        }
        if(pos.x  <= left)
        {
            pos.x = left;
            transform.position = pos;
            _vel.x *= -1;
        }
        else if(pos.x  >= right) 
        {
            pos.x = right;
            transform.position = pos;
            _vel.x *= -1;
        }
    }
}
