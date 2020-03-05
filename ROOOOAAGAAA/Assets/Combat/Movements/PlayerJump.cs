using UnityEngine;

namespace ROOOOAAGAAA.Combat
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(ControlsManager))]
    public class PlayerJump : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private ControlsManager _controlsManager;

        private float _JumpsLeft;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _controlsManager = GetComponent<ControlsManager>();
            _JumpsLeft = _controlsManager.MaxJumps;
        }

        private void Update()
        {
            if (_controlsManager.IsGrounded && _JumpsLeft <= 0)
            {
                _JumpsLeft = _controlsManager.MaxJumps;
            }
        }

        public void TryToJump()
        {
            var canJump = _controlsManager.IsGrounded || _JumpsLeft > 0;

            if (canJump)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _controlsManager.JumpForce);
                _JumpsLeft--;
            }
        }
    }
}