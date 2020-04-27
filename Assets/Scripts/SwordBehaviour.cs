using DG.Tweening;

public class SwordBehaviour : ExtraWeaponBehaviour
{
    public float distance;

    public float duration;
    public PlayerController player;

    public override void TriggerEffect()
    {
        player.dashing = true;

        var tr = player.transform;

        var targetPosition = tr.position + tr.forward * distance;

        player.transform.DOMove(targetPosition, duration).OnComplete(() => player.dashing = false);
    }
}