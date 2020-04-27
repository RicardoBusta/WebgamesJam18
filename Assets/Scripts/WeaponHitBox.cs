using DefaultNamespace;
using UnityEngine;

public class WeaponHitBox : MonoBehaviour
{
    public GameController controller;

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<EnemyController>();
        enemy.Die();

        controller.score++;
    }
}