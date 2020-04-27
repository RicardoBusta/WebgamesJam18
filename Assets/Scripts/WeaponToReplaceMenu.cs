using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponToReplaceMenu : MonoBehaviour
{
    public Button button1;
    public Button button2;

    public Image icon1;
    public Image icon2;

    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;

    public GameController controller;

    public PlayerController player;

    private void Start()
    {
        button1.onClick.AddListener(Button1Clicked);
        button2.onClick.AddListener(Button2Clicked);
    }

    private void Button1Clicked()
    {
        controller.playerHasLeftWeapon = false;
        player.weapon1.gameObject.SetActive(false);
        ButtonClicked();
    }

    private void Button2Clicked()
    {
        controller.playerHasRightWeapon = false;
        player.weapon2.gameObject.SetActive(false);
        ButtonClicked();
    }

    private void ButtonClicked()
    {
        controller.selectWeaponMenu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Show()
    {
        controller.waitPlayerInput = true;
        
        player.attacking = false;

        button1.image.color = player.col1;
        button2.image.color = player.col2;
        text1.color = player.col1;
        text2.color = player.col2;
        icon1.sprite = player.weapon1.icon;
        icon1.color = player.col1;
        icon2.sprite = player.weapon2.icon;
        icon2.color = player.col2;

        gameObject.SetActive(true);
    }
}