using UnityEngine;

namespace SatansForest.PlayerServices 
{
    public class PlayerAnimator : MonoBehaviour
    {
        private const string WalkAnimation = "PlayerWalk";
        private const string IdleAnimation = "PlayerIdle";
     
        private Animator _animator;

        private void Start() => _animator = GetComponent<Animator>();

        public void PlayWalkAnimation() => _animator.Play(WalkAnimation);
        public void PlayIdleAnimation() => _animator.Play(IdleAnimation);
    }
}
