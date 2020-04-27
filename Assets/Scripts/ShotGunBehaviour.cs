using DG.Tweening;
using UnityEngine;

public class ShotGunBehaviour : ExtraWeaponBehaviour
{
    private static readonly int Fire = Animator.StringToHash("Fire");

    private int effectIndex;

    public GameObject GunTip;

    public GameObject player;
    public WeaponController ShotGunController;
    public Animator[] ShotGunEffects;

    public override void TriggerEffect()
    {
        var effect = ShotGunEffects[effectIndex];
        var transform1 = effect.transform;
        transform1.position = GunTip.transform.position;
        transform1.forward = player.transform.forward;
        effectIndex = (effectIndex + 1) % ShotGunEffects.Length;
        effect.gameObject.SetActive(true);
        effect.SetTrigger(Fire);
        DOVirtual.DelayedCall(0.5f, () => effect.gameObject.SetActive(false));
    }
}