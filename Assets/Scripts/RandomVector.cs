using UnityEngine;

public class RandomVector : MonoBehaviour
{
    [SerializeField] GameObject _point;
    [SerializeField] float _radiusMax = 4;
    [SerializeField] float _radiusMin = 0;
    float _radius = 4;
    float _factor = 0;
    void Start()
    {
        
    }

    void Update()
    {
        Vector2 unitVector = Random.onUnitSphere * _radius;

        _factor += Time.deltaTime;
        if(_factor > 1)
        {
            _factor = 0;
        }


        _radius = Mathf.Lerp(_radiusMin, _radiusMax, _factor);
        
        Instantiate(_point, unitVector, Quaternion.identity);
    }
}
