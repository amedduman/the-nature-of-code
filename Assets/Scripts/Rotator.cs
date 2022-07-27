using UnityEngine;

public class Rotator : MonoBehaviour
{
    float _degree = 0;
    void Start()
    {
    }

    void Update()
    {
        _degree += Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, _degree));
    }
}
