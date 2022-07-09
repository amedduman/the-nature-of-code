using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorToMouse : MonoBehaviour
{
    [SerializeField] Vector2 _vel = new Vector2(1,1);
    [SerializeField] float _velLimit = 1;
    [SerializeField] float _accFactor = .1f;

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
        
        Vector2 acc = (mousePos - myPos).normalized;
        acc *= _accFactor; 
        
        _vel += acc;
        _vel = Vector2.ClampMagnitude(_vel, _velLimit);

        transform.position = myPos + _vel; 
    }
}
