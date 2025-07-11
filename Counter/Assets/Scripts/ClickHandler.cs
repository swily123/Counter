using System;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    public event Action MouseButtonClick;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseButtonClick?.Invoke();
        }
    }
}
