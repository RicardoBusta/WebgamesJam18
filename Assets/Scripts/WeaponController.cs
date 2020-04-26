using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Animator animator;

    public void Attack()
    {
        animator.SetTrigger("Attack");
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
        animator.SetBool("Walk", walk);
    }
}