using System;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(PlayerController))]
    public class KeyboardInput : MonoBehaviour
    {
        private PlayerController _controller;

        private readonly RaycastHit[] _hit = new RaycastHit[1];

        private Camera _cam;
        private const float Tolerance = 0.01f;

        private void Start()
        {
            _cam = Camera.main;
            _controller = GetComponent<PlayerController>();
        }

        private void Update()
        {
            var v = Input.GetAxis("Vertical");
            var h = Input.GetAxis("Horizontal");

            if (Math.Abs(v) < Tolerance && Math.Abs(h) < Tolerance)
            {
                _controller.Stop();
            }
            else
            {
                _controller.Move(new Vector3(h, 0, v));
            }

            var lmb = Input.GetMouseButtonDown(0);

            if (lmb)
            {
                _controller.AttackLeftHand();
            }

            var rmb = Input.GetMouseButtonDown(1);
            if (rmb)
            {
                _controller.AttackRightHand();
            }

            if (Physics.RaycastNonAlloc(_cam.ScreenPointToRay(Input.mousePosition), _hit, LayerMask.GetMask("Input")) >
                0)
            {
                var mousePosition = _hit[0].point;
                mousePosition.y = 0;
                _controller.LookAt(mousePosition);
            }
        }
    }
}