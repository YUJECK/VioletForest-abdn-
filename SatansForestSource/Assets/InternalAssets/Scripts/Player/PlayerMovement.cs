using UnityEngine;
using VioletHell.InputServices;
using Zenject;

namespace VioletHell.PlayerServices
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 4;

        private PlayerAnimator _playerAnimator;
        private Rigidbody2D _rigidbody;
        private IInputService _inputService;

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;

            _inputService.OnMoved += OnMoved;
            _inputService.OnMoved += PlayAnimations;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _playerAnimator = GetComponent<PlayerAnimator>();
        }

        private void OnMoved(Vector2 movement)
            => _rigidbody.velocity = movement * moveSpeed;

        private void PlayAnimations(Vector2 playerMovement)
        {
            if (playerMovement != Vector2.zero) _playerAnimator.PlayWalkAnimation();
            else _playerAnimator.PlayIdleAnimation();
        }
    }
}