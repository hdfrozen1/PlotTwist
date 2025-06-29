using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseButton : MonoBehaviour, IPointerDownHandler
{
    private event Action<object[]> _buttonPressed;

    public void RegisterListener(Action<object[]> callback)
    {
        _buttonPressed += callback;
    }
    public void UnRegisterListener(Action<object[]> callback)
    {
        _buttonPressed -= callback;
    }

    protected void TriggerButtonPressed(params object[] args)
    {
        _buttonPressed?.Invoke(args);
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        TriggerButtonPressed(null);
    }
}
