using UnityEngine;

public class Particle : MonoBehaviour
{
    Vector2 _pos;
    Vector2 _vel;

    private void Start()
    {
        _pos = new Vector2(transform.position.x, transform.position.y);
        _vel = new Vector2(1, -1);
    }

    private void Update()
    {
        _pos += _vel;
        transform.position = _pos;
    }
}

