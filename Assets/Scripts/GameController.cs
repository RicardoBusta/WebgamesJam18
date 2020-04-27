using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private Tween changeFlash;

    public EnemySpawner enemySpawner;

    public Image hudWeapon1Icon;
    public Image hudWeapon2Icon;

    public PlayerController player;

    public Canvas playerGuiCanvas;

    public bool playerHasLeftWeapon;
    public bool playerHasRightWeapon;

    public int score;

    public Slider scoreSlider;

    public Image screenFlash;
    public SelectWeaponMenu selectWeaponMenu;
    public SpriteRenderer shockWave;

    public bool waitPlayerInput;

    public Slider weapon1Slider;
    public Slider weapon2Slider;
    public WeaponButton[] weaponButtons;

    public Image weaponSliderImage1;
    public Image weaponSliderImage2;

    public WeaponToReplaceMenu replaceMenu;

    private const int MAX_SCORE = 100;

    private void Start()
    {
        selectWeaponMenu.gameObject.SetActive(true);
        replaceMenu.gameObject.SetActive(false);
        foreach (var weaponButton in weaponButtons)
        {
            weaponButton.SetListener(WeaponButtonClicked);
            weaponButton.Enable();
        }

        scoreSlider.maxValue = MAX_SCORE;
        scoreSlider.value = 0;

        shockWave.gameObject.SetActive(false);
        screenFlash.gameObject.SetActive(false);

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
            player.weapon1 = button.playerWeapon;
            weaponSliderImage1.color = button.enabledColor;
            weapon1Slider.maxValue = player.weapon1.maxAmmo;
            hudWeapon1Icon.sprite = button.icon.sprite;
            hudWeapon1Icon.color = player.col1;
        }
        else if (!playerHasRightWeapon)
        {
            playerHasRightWeapon = true;
            button.Disable(true);
            player.mat2 = button.materialColor;
            player.col2 = button.enabledColor;
            player.weapon2 = button.playerWeapon;
            weaponSliderImage2.color = button.enabledColor;
            weapon2Slider.maxValue = player.weapon2.maxAmmo;
            hudWeapon2Icon.sprite = button.icon.sprite;
            hudWeapon2Icon.color = player.col2;
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
        player.Init();
        enemySpawner.Init();
    }

    private void Update()
    {
        if (player.paused) return;

        if (score >= MAX_SCORE)
        {
            score = 0;
            replaceMenu.Show();
        }

        var w1 = player.weapon1;
        HandleWeapon(w1, weapon1Slider);

        var w2 = player.weapon2;
        HandleWeapon(w2, weapon2Slider);

        scoreSlider.value = score;
    }

    public void PlayShockWave(Color color)
    {
        changeFlash?.Kill();

        shockWave.color = color;
        screenFlash.color = color;

        shockWave.gameObject.SetActive(true);
        screenFlash.gameObject.SetActive(true);

        var baseColor = color;
        changeFlash = DOVirtual.Float(0, 1, 0.5f, f =>
        {
            var shockWaveColor = baseColor;
            shockWaveColor.a = 1 - f;
            var flashColor = baseColor;
            flashColor.a = Mathf.Sin(f * Mathf.PI) * 0.05f;
            shockWave.color = shockWaveColor;
            screenFlash.color = flashColor;
            var scale = f * 10;
            shockWave.transform.localScale = new Vector3(scale, scale, scale);
        }).OnComplete(() =>
        {
            shockWave.gameObject.SetActive(false);
            screenFlash.gameObject.SetActive(false);
        });
    }

    private void HandleWeapon(WeaponController weapon, Slider slider)
    {
        if (weapon.ammo < weapon.maxAmmo)
        {
            weapon.ammo += Time.deltaTime * weapon.rechargeAmmoScale;
            if (weapon.ammo > weapon.maxAmmo) weapon.ammo = weapon.maxAmmo;

            slider.value = weapon.ammo;
        }
    }
}