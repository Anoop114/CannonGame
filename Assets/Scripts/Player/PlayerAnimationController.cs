using System;
using UnityEngine;

namespace Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        private Animator _animator;
        private int _velocityAnimationHash;
        private int _jumpAnimationHash;
        private void Start()
        {
            _animator = GetComponent<Animator>();
            _velocityAnimationHash = Animator.StringToHash("Velocity");
            _jumpAnimationHash = Animator.StringToHash("Jump");
        }

        public void JumpAnimationCall()
        {
            _animator.SetTrigger(_jumpAnimationHash);
        }

        public void MoveAnimationCall(float velocity)
        {
            _animator.SetFloat(_velocityAnimationHash,velocity);
        }
    }
}