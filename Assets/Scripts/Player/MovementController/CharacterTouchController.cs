using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Player.MovementController
{
    public class CharacterTouchController : MonoBehaviour
    {
        #region Variables

        private float _horizontalMove;
        private float _verticalMove;
        private float _speed;
        private float _rotateVelocity;
        private float _ySpeed;
        private float _animationVelocity;
        
        private Vector3 _moveDir;
        private Rigidbody _rb;

        private bool _isStop;
        private bool _isJump;
        private bool _moveLeft, _moveRight, _moveForward, _moveBackward;
        private bool _isStartWalkSoundPlay,_isStartRunSoundPlay;
        
        [SerializeField] private float speedAcceleration;
        [SerializeField] private float maxSpeed;
        [SerializeField] private Button jumpBtn;
        
        private void JumpAction() => _isJump = true;

        #endregion

        #region Unity Event

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();

            jumpBtn.onClick.AddListener(JumpAction);
        }
        private void OnEnable() => ActionHelper.OnFingerMove += MovePlayer;

        private void OnDisable() => ActionHelper.OnFingerMove += MovePlayer;

        #endregion

        private void Update()
        {
            //check player stop moving
            CheckPlayerStoped();
            
            // check which direction the player is moving.
            AssigneePlayerDirection();
            
            // move player on desire direction with rotation.
            PlayerMoveWithRotation();
            
            // play walking and running sound.
            SoundPlayer();
        }
        
        #region Move Player Logic

        private void MovePlayer(PlayerDirection direction)
        {
            switch (direction)
            {
                case PlayerDirection.Stop:
                    _isStop = true;
                    _moveLeft = _moveRight = _moveForward = _moveBackward = false;
                    break;
                case PlayerDirection.Left:
                    _moveLeft = true;
                    break;
                case PlayerDirection.Right:
                    _moveRight = true;
                    break;
                case PlayerDirection.Forward:
                    _moveForward = true;
                    break;
                case PlayerDirection.Backward:
                    _moveBackward = true;
                    break;
                default:
                    _isStop = true;
                    _moveLeft = _moveRight = _moveForward = _moveBackward = false;
                    break;
            }


        }

        #region Player Direction

        private void AssigneePlayerDirection()
        {
            if (_moveLeft || _moveRight)
            {
                MoveLeftRight(_moveLeft ? -1 : 1);
            }

            if (_moveForward || _moveBackward)
            {
                MoveForwardBackward(_moveForward ? -1 : 1);
            }
        }
        private void MoveForwardBackward(int dir)
        {
            _isStop = false;
            _horizontalMove = dir;

            if (_speed <= maxSpeed)
                _speed += Time.deltaTime * speedAcceleration;
            else
                _speed = maxSpeed;

            AnimationVelocitySet(1);
        }
        private void MoveLeftRight(int dir)
        {

            _isStop = false;
            _verticalMove = dir;
            
            if (_speed <= maxSpeed)
                _speed += Time.deltaTime * speedAcceleration;
            else
                _speed = maxSpeed;

            AnimationVelocitySet(1);
        }

        #endregion

        private void PlayerMoveWithRotation()
        {
            _moveDir = new Vector3(_horizontalMove, 0, _verticalMove);
            _moveDir.Normalize();
            if (_isJump)
            {
                _isJump = false;
                _rb.AddForce(Vector3.up * 5,ForceMode.Impulse);
                GameBehaviourManager.Instance.PlayerAnimationController.JumpAnimationCall();
            }
            transform.Translate(_moveDir * (_speed * Time.deltaTime),Space.World);
            
            GameBehaviourManager.Instance.PlayerAnimationController.MoveAnimationCall(_animationVelocity);
            
            if (_moveDir == Vector3.zero) return;
            var lookRotation = Quaternion.LookRotation(_moveDir,Vector3.up);
            lookRotation = Quaternion.RotateTowards(transform.rotation, lookRotation, 720 * Time.deltaTime);
            
            transform.rotation = lookRotation;
        }
        
        private void AnimationVelocitySet(float speedVal)
        {
            _isStartWalkSoundPlay = true;
            if (_animationVelocity < speedVal)
                _animationVelocity += Time.deltaTime * .2f;
            else
                _animationVelocity = speedVal;
        }

        #endregion

        #region Play sound and Player stop logic

        private void CheckPlayerStoped()
        {
            if(!_isStop)return;
            if (_speed > 0)
                _speed -= Time.deltaTime * 5f;
            else
                _horizontalMove = _verticalMove = 0;
            
            if (_animationVelocity > 0)
                _animationVelocity -= Time.deltaTime * 2f;
        }
        
        private void SoundPlayer()
        {
            if (_isStartWalkSoundPlay && _isStartRunSoundPlay) return;
            if (_animationVelocity <= 0)
            {
                //stop audio.
                _isStartWalkSoundPlay = _isStartRunSoundPlay = false;
                GameBehaviourManager.Instance.SoundController.StopWalkRunSound();
                return;
            }
            
            switch (_animationVelocity)
            {
                case > 0 and < .5f:
                    if (!_isStartWalkSoundPlay)
                    {
                        _isStartRunSoundPlay = false;
                        _isStartWalkSoundPlay = true;
                        GameBehaviourManager.Instance.SoundController.PlayWalkSound();
                    }
                    break;
                case >.5f and < 1f:
                    if (!_isStartRunSoundPlay)
                    {
                        _isStartWalkSoundPlay = false;
                        _isStartRunSoundPlay = true;
                        GameBehaviourManager.Instance.SoundController.PlayRunSound();
                    }
                    break;
            }
        }
        

        #endregion
    }
}