// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Attractor : MonoBehaviour
// {
//     [SerializeField] float _mass = 2;
//     [SerializeField] float _gConstant = 1;
//     [SerializeField] float _disMax, _disMin;

//     public float Attract(Particle particle)
//     {
//         float d = Vector3.Distance(particle.transform.position, transform.position);

//         d = Mathf.Clamp(d, _disMin, _disMax);

//         float attraction = (_mass * particle._mass) / (d * d) * _gConstant;
//         return attraction;
//     }
// }
