using DG.Tweening;
using UnityEngine;

public class SwordBehaviour : ExtraWeaponBehaviour
{
    public PlayerController player;

    public float duration;
    public float distance;

    public override void TriggerEffect()
    {
        player.dashing = true;

        var tr = player.transform;

        var targetPosition = tr.position + tr.forward * distance;

        player.transform.DOMove(targetPosition, duration).OnComplete(() => player.dashing = false);
    }
}