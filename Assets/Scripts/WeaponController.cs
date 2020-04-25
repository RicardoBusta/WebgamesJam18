using UnityEngine;

public class WeaponController : MonoBehaviour
{
   public Animator animator;
   private static readonly int Attack1 = Animator.StringToHash("Attack");

   public void Attack()
   {
      animator.SetTrigger(Attack1);
   }
}
