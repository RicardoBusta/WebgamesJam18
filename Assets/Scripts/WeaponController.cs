using System;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Animator animator;

    private static readonly int Attack1 = Animator.StringToHash("Attack");
    private static readonly int Walk = Animator.StringToHash("Walk");

    public float maxAmmo;
    public float ammo;

    public event Action FinishAttackEvent;

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
}