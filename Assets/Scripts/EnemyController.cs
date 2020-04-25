using System;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyController : MonoBehaviour
    {
        public float thresholdDistance;

        public Transform targetTransform;

        public float moveSpeed;
        public float rotationSpeed;

        private float currentAngle;
        private float targetAngle;

        private Transform tr;

        private Rigidbody rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            tr = transform;
        }

        private void Update()
        {
            var targetDirection = targetTransform.position - transform.position;
            targetDirection.y = 0;
            Rotate(targetDirection);
            rb.velocity = Vector3.zero;
            if (Vector3.SqrMagnitude(targetDirection) < thresholdDistance * thresholdDistance)
            {
                Attack();
            }
            else
            {
                Move(targetDirection);
            }
        }

        private void Rotate(Vector3 direction)
        {
            rb.rotation = Quaternion.RotateTowards(rb.rotation, Quaternion.LookRotation(direction, Vector3.up),
                rotationSpeed);
        }

        private void Move(Vector3 direction)
        {
            rb.velocity = tr.forward * (moveSpeed);
        }

        private void Attack()
        {
        }
    }
}