using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyController : MonoBehaviour
    {
        public MeshRenderer body;

        public GameController controller;

        private float currentAngle;

        private bool initialized;

        public float moveSpeed;

        private Rigidbody rb;
        public float rotationSpeed;

        public PlayerController target;
        private float targetAngle;
        public float thresholdDistance;

        private Transform tr;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            tr = transform;
        }

        public void Init()
        {
            initialized = true;
            var result = Random.Range(0, 2);
            body.material = result == 0 ? target.mat1 : target.mat2;
        }

        private void Update()
        {
            if (!initialized || target.paused || controller.waitPlayerInput)
            {
                rb.velocity = Vector3.zero;
                rb.position = transform.position;
                return;
            }

            var targetDirection = target.transform.position - transform.position;
            targetDirection.y = 0;
            Rotate(targetDirection);
            rb.velocity = Vector3.zero;
            if (Vector3.SqrMagnitude(targetDirection) < thresholdDistance * thresholdDistance)
                Attack();
            else
                Move(targetDirection);
        }

        private void Rotate(Vector3 direction)
        {
            rb.rotation = Quaternion.RotateTowards(rb.rotation, Quaternion.LookRotation(direction, Vector3.up),
                rotationSpeed);
        }

        private void Move(Vector3 direction)
        {
            rb.velocity = tr.forward * moveSpeed;
        }

        private void Attack()
        {
        }

        public void Die()
        {
            initialized = false;
            gameObject.SetActive(false);
        }

        public void OnCollisionEnter(Collision other)
        {
            if (other.gameObject == target.gameObject)
            {
                target.gameObject.SetActive(false);
            }
        }
    }
}