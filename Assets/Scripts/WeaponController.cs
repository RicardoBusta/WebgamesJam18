using System;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private static readonly int Attack1 = Animator.StringToHash("Attack");
    private static readonly int Walk = Animator.StringToHash("Walk");

    private bool _hasExtraBehaviour;
    private float _rechargeAmmoScale;
    public float ammo;
    public Animator animator;

    public ExtraWeaponBehaviour extraBehaviour;

    public float maxAmmo;
    public float rechargeAmmoScale;

    public event Action FinishAttackEvent;

    private void Start()
    {
        _hasExtraBehaviour = extraBehaviour != null;
    }

    public bool Attack()
    {
        var canAttack = ammo >= 1;
        if (canAttack)
        {
            animator.SetTrigger(Attack1);
            ammo -= 1;
        }

        return canAttack;
    }

    public void Enable(bool rightHand)
    {
        transform.localScale = new Vector3(rightHand ? 1 : -1, 1, 1);
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void SetWalkAnim(bool walk)
    {
        animator.SetBool(Walk, walk);
    }

    public void FinishAttack()
    {
        FinishAttackEvent?.Invoke();
    }

    public void TriggerExtraBehaviour()
    {
        if (_hasExtraBehaviour) extraBehaviour.TriggerEffect();
    }
}