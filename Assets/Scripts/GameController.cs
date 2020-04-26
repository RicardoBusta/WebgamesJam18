using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public SelectWeaponMenu selectWeaponMenu;
    public WeaponButton[] weaponButtons;

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
        }
        else if(!playerHasRightWeapon)
        {
            playerHasRightWeapon = true;
        }
        waitPlayerInput = false;
        selectWeaponMenu.Disable();
    }

    private IEnumerator GameCoroutine()
    {
        waitPlayerInput = true;
        selectWeaponMenu.Enable(false);
        yield return  new WaitUntil(()=>!waitPlayerInput);
        waitPlayerInput = true;
        selectWeaponMenu.Enable(true);
        yield return  new WaitUntil(()=>!waitPlayerInput);
    }

    private void Update()
    {
        
    }
}