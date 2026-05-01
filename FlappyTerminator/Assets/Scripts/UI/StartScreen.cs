using System;
using UnityEngine;

public class StartScreen : Window
{
    public event Action PlayButtonClicked;

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
        PlayButtonClicked?.Invoke();
    }
}