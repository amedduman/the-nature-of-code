using UnityEngine;

public class Rotator : MonoBehaviour
{
    [ReadOnly] [SerializeField] float _angle;
    [SerializeField] float _angleVel;
    [ReadOnly] [SerializeField] float _angleAcc;

    void Update()
    {
        _angleAcc = 0;
        float mouseX = Input.GetAxis("Mouse X");
        mouseX = Mathf.Clamp(mouseX, -0.1f, 0.1f);
        _angleAcc = mouseX;
        _angleVel += _angleAcc;
        _angle += _angleVel * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, _angle));
    }
}
