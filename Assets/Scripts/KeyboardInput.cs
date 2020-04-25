using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(PlayerController))]
    public class KeyboardInput : MonoBehaviour
    {
        private PlayerController controller;

        private void Start()
        {
            controller = GetComponent<PlayerController>();
        }

        private void Update()
        {
            var v = Input.GetAxis("Vertical");
            var h = Input.GetAxis("Horizontal");

            controller.Move(new Vector3(h, 0, v));
        }
    }
}