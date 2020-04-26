using TMPro;
using UnityEngine;

public class SelectWeaponMenu : MonoBehaviour
{
    public TextMeshProUGUI title;

    public void Enable(bool rightHand)
    {
        gameObject.SetActive(true);
        title.text = $"Select your {(rightHand ? "right" : "left")} hand weapon";
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}