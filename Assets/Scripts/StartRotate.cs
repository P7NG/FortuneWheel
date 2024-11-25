using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartRotate : MonoBehaviour
{
    [SerializeField] private Wheel _wheel;
    [SerializeField] private bool _buttonDown = false;
    [SerializeField] private Slider _forceSlider;
    [SerializeField] private float _sliderSpeed;

    private bool _newValue = false;

    public void ChangeButtonStatus(bool status)
    {
        _buttonDown = status;
    }

    private void FixedUpdate()
    {
        if (!_wheel.IsRotate)

            if (_buttonDown)
            {
                UpdateSlider();
            }
            else
            {
                if (_newValue)
                {
                    _newValue = false;
                    _wheel.IsRotate = true;
                    _wheel.Speed = _forceSlider.value;
                }
            }
    }

    public void UpdateSlider()
    {
        if(_forceSlider.value == _forceSlider.maxValue || _forceSlider.value == _forceSlider.minValue)
        {
            _sliderSpeed *= -1;
        }
        _newValue = true;
        _forceSlider.value += _sliderSpeed * Time.deltaTime;
    }
}
