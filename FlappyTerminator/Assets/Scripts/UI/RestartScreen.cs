using System;
using UnityEngine;

public class RestartScreen : Window
{
    public event Action RestartButtonClicked;

    public override void Open()
    {
        CanvasGroup.alpha = 1f;
        ActionButton.interactable = true;
    }

    public override void Close()
    {
        CanvasGroup.alpha = 0f;
        ActionButton.interactable = false;
    }

    protected override void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }
}