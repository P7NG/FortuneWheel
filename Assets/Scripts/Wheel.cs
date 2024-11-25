using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wheel : MonoBehaviour
{
    public bool IsRotate = false;
    public float Speed;
    [SerializeField] private float _stopAcceleration;
    [SerializeField] private GameObject _wheel;
    [SerializeField] private ControlAnswer _controlAnswer;

    private void FixedUpdate()
    {
        if (!IsRotate) return;

        if (Speed > 0)
        {
            _wheel.transform.Rotate(transform.forward * Speed);

            Speed -= _stopAcceleration * Time.deltaTime;
        }
        else
        {
            IsRotate = false;
            _controlAnswer.CanCheck = true;
        }
    }
}
