using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class WeaponButton : MonoBehaviour
{
    private static readonly Color DisabledColor = new Color(0.4f, 0.4f, 0.4f);
    private Button _button;

    public Color enabledColor;

    public Image icon;
    public Material materialColor;

    public WeaponController playerWeapon;
    public TextMeshProUGUI text;

    private void Awake()
    {
        _button = GetComponent<Button>();
        enabledColor = materialColor.GetColor("_BaseColor");
    }

    public void SetListener(Action<WeaponButton> buttonAction)
    {
        _button.onClick.AddListener(() => buttonAction?.Invoke(this));
    }

    public void Enable()
    {
        playerWeapon.Disable();
        _button.interactable = true;
        SetColor(enabledColor);
    }

    public void Disable(bool rightHand)
    {
        playerWeapon.Enable(rightHand);
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