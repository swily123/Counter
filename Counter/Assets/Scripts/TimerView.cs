using System;
using TMPro;
using System.Collections;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private Timer _timer;

    private void Start()
    {
        _timerText.text = "0";
    }

    private void OnEnable()
    {
        _timer.ValueChanged += DisplayValue;
    }

    private void OnDisable()
    {
        _timer.ValueChanged -= DisplayValue;
    }

    private void DisplayValue(float value)
    {
        _timerText.text = value.ToString();
    }
}
