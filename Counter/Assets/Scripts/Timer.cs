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

    private void Update()
    {
        if (_isActive)
        {
            _value++;
            _coroutine = StartCoroutine(WaitAndInvokeEvent(_delay, _value));
        }
    }

    private void OnEnable()
    {
        _clickHandler.ClicksChanged += OnClicksChanged;
    }

    private void OnDisable()
    {
        _clickHandler.ClicksChanged -= OnClicksChanged;
    }

    private void OnClicksChanged(int clickCount)
    {
        if (clickCount % 2 == 0)
        {
            _isActive = false;
            StopCoroutine(_coroutine);
        }
        else
        {
            _isActive = true;
        }
    }

    private IEnumerator WaitAndInvokeEvent(float delay, int value)
    {
        _isActive = false;
        var waitTime = new WaitForSeconds(delay);
        ValueChanged?.Invoke(value);
        yield return waitTime;
        _isActive = true;
    }
}
