using System;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    public event Action<int> ClicksChanged;
    private int _clicksCount;

    private void Start()
    {
        _clicksCount = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _clicksCount++;
            ClicksChanged?.Invoke(_clicksCount);
        }
    }
}
