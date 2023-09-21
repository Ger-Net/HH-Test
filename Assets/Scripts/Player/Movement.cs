using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private VariableJoystick _joystick;
    [SerializeField] private Transform _transform;

    public void FixedUpdate()
    {
        float x = _joystick.Horizontal;
        float y = _joystick.Vertical;

        _transform.position += new Vector3(x, y) * _speed * Time.deltaTime;
    }
}
