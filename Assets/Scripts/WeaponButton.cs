using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class WeaponButton : MonoBehaviour
{
    private Button _button;

    public Color enabledColor;

    public Image icon;
    public TextMeshProUGUI text;

    private static readonly Color DisabledColor = new Color(0.4f, 0.4f, 0.4f);

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void SetListener(Action<WeaponButton> buttonAction)
    {
        _button.onClick.AddListener(() => buttonAction?.Invoke(this));
    }

    public void Enable()
    {
        _button.interactable = true;
        SetColor(enabledColor);
    }

    public void Disable()
    {
        _button.interactable = false;
        SetColor(DisabledColor);
    }

    private void SetColor(Color color)
    {
        _button.image.color = color;
        icon.color = color;
        text.color = color;
    }
}