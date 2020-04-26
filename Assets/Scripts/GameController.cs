using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public SelectWeaponMenu selectWeaponMenu;
    public WeaponButton[] weaponButtons;

    public Canvas playerGuiCanvas;

    public PlayerController player;

    public bool playerHasLeftWeapon;
    public bool playerHasRightWeapon;

    public bool waitPlayerInput;

    private void Start()
    {
        foreach (var weaponButton in weaponButtons)
        {
            weaponButton.SetListener(WeaponButtonClicked);
            weaponButton.Enable();
        }

        StartCoroutine(GameCoroutine());
    }

    private void WeaponButtonClicked(WeaponButton button)
    {
        if (!playerHasLeftWeapon)
        {
            playerHasLeftWeapon = true;
            button.Disable(false);
            player.mat1 = button.materialColor;
            player.col1 = button.enabledColor;
            player.Weapon1 = button.playerWeapon;
        }
        else if (!playerHasRightWeapon)
        {
            playerHasRightWeapon = true;
            button.Disable(true);
            player.mat2 = button.materialColor;
            player.col2 = button.enabledColor;
            player.Weapon2 = button.playerWeapon;
        }

        waitPlayerInput = false;
        selectWeaponMenu.Disable();
    }

    private IEnumerator GameCoroutine()
    {
        playerGuiCanvas.gameObject.SetActive(false);
        player.paused = true;
        waitPlayerInput = true;
        selectWeaponMenu.Enable(false);
        yield return new WaitUntil(() => !waitPlayerInput);
        waitPlayerInput = true;
        selectWeaponMenu.Enable(true);
        yield return new WaitUntil(() => !waitPlayerInput);
        playerGuiCanvas.gameObject.SetActive(true);
        player.paused = false;
    }

    private void Update()
    {
    }
}