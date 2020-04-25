using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(PlayerController))]
    public class KeyboardInput : MonoBehaviour
    {
        private PlayerController controller;

        private RaycastHit[] hit = new RaycastHit[1];

        private Camera cam;

        private void Start()
        {
            cam = Camera.main;
            controller = GetComponent<PlayerController>();
        }

        private void Update()
        {
            var v = Input.GetAxis("Vertical");
            var h = Input.GetAxis("Horizontal");

            controller.Move(new Vector3(h, 0, v));

            var lmb = Input.GetMouseButtonDown(0);

            if (lmb)
            {
                controller.AttackLeftHand();
            }

            var rmb = Input.GetMouseButtonDown(1);
            if (rmb)
            {
                controller.AttackRightHand();
            }

            if (Physics.RaycastNonAlloc(cam.ScreenPointToRay(Input.mousePosition), hit, LayerMask.GetMask("Input")) > 0)
            {
                var mousePosition = hit[0].point;
                mousePosition.y = 0;
                controller.LookAt(mousePosition);
                Debug.DrawLine(Vector3.zero, mousePosition);
            }
        }
    }
}