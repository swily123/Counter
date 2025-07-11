using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private ClickHandler _clickHandler;

    public event Action<float> ValueChanged;
    private Coroutine _coroutine;

    private bool _isActive = false;
    private float _delay = 0.5f;
    private int _value = 0;

    private void OnEnable()
    {
        _clickHandler.MouseButtonClick += OnClick;
    }

    private void OnDisable()
    {
        _clickHandler.MouseButtonClick -= OnClick;
    }

    private void OnClick()
    {
        _isActive = !_isActive;

        if (_isActive)
        {
            _coroutine = StartCoroutine(CountValueWithFrequency(_delay));
        }
        else
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
        }
    }

    private IEnumerator CountValueWithFrequency(float delay)
    {
        while (true)
        {
            var waitTime = new WaitForSeconds(delay);
            InceraseValue();
            ValueChanged?.Invoke(_value);
            yield return waitTime;
        }
    }

    private void InceraseValue()
    {
        ++_value;
    }
}
