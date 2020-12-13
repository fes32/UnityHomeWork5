using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Time.deltaTime*_speed,0,0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Time.deltaTime * _speed, 0, 0);
        }
        else if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, Time.deltaTime * _speed,  0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -Time.deltaTime * _speed, 0);
        }     
    }
}
