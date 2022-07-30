using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float _speed = 10;

    void Update()
    {
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 vel = target - transform.position;

        vel = vel.normalized;
        vel.z = 0;

        float angle = Mathf.Atan2(vel.y, vel.x) * (180 / Mathf.PI) - 90; 

        transform.position += vel * Time.deltaTime * _speed;  
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
