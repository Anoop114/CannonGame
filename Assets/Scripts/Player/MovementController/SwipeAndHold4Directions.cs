using UnityEngine;
using Utils;

namespace Player.MovementController
{
    public class SwipeAndHold4Directions : MonoBehaviour
    {
        #region variables

        //declare variables for later
        private float _fingerInitialPositionX;
        private float _fingerMovedPositionX;

        private float _fingerInitialPositionY;
        private float _fingerMovedPositionY;

        private bool _isLeftTouch;
        private bool _isNotTouch;
        private bool _swipeUpOn;
        private bool _swipeDownOn;
        private bool _swipeRightOn;
        private bool _swipeLeftOn;

        private int _screenWidth;

        #endregion
        // Use this for initialization
        private void Start ()
        {
            ResetBoolToFalse();
            ResetVariablesToZero();
            
            _screenWidth = Screen.width / 2;
        }

        private void Update ()
        {
            if(!IsLeftTouch())return;
            foreach (var touch in Input.touches)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        _fingerInitialPositionX = touch.position.x; //get initial X position of touch
                        _fingerInitialPositionY = touch.position.y; //get initial Y position of touch
                        break;
                    case TouchPhase.Moved:
                    {
                        _fingerMovedPositionX = touch.position.x; //get the new X position of touch
                        _fingerMovedPositionY = touch.position.y; //get the new Y position of touch
                        _isNotTouch = false;
                        
                        //first case - finger is moved right, movement is predominantly horizontal (x axis)
                        if (_fingerMovedPositionX > _fingerInitialPositionX && Mathf.Abs(_fingerMovedPositionX - _fingerInitialPositionX) > Mathf.Abs(_fingerMovedPositionY - _fingerInitialPositionY))
                        {
                            //swipe right
                            if (IsAllSwipeFalse()) _swipeRightOn = true;
                        }
                        //second case - finger is moved left, movement is predominantly horizontal (x axis)
                        else if (_fingerMovedPositionX < _fingerInitialPositionX && Mathf.Abs(_fingerMovedPositionX - _fingerInitialPositionX) > Mathf.Abs(_fingerMovedPositionY - _fingerInitialPositionY))
                        {
                            //swipe left
                            if (IsAllSwipeFalse()) _swipeLeftOn = true;
                        }

                        //third case - finger is moved up, movement predominantly vertical (y axis)
                        else if (_fingerMovedPositionY > _fingerInitialPositionY && Mathf.Abs(_fingerMovedPositionX - _fingerInitialPositionX) < Mathf.Abs(_fingerMovedPositionY - _fingerInitialPositionY))
                        {
                            //swipe up
                            if (IsAllSwipeFalse()) _swipeUpOn = true;
                        }

                        //fourth case - finger is moved down, movement predominantly vertical (y axis)
                        else if (_fingerMovedPositionY < _fingerInitialPositionY && Mathf.Abs(_fingerMovedPositionX - _fingerInitialPositionX) < Mathf.Abs(_fingerMovedPositionY - _fingerInitialPositionY))
                        {
                            //swipe down
                            if (IsAllSwipeFalse()) _swipeDownOn = true;
                        }
                        SwipeMoveAction();
                        break;
                    }
                    case TouchPhase.Ended:
                        ResetBoolToFalse();
                        ResetVariablesToZero();
                        if(_isNotTouch)return;
                        _isNotTouch = true;
                        ActionHelper.OnFingerMove?.Invoke(PlayerDirection.Stop);                      
                        break;
                }
            }
        }

        //call player to move on desire direction.
        private void SwipeMoveAction()
        {
            if (_swipeRightOn)
            {
                ActionHelper.OnFingerMove?.Invoke(PlayerDirection.Right);
            }
            else if (_swipeLeftOn)
            {
                ActionHelper.OnFingerMove?.Invoke(PlayerDirection.Left);
            }
            else if (_swipeUpOn)
            {
                ActionHelper.OnFingerMove?.Invoke(PlayerDirection.Forward);
            }
            else if (_swipeDownOn)
            {
                ActionHelper.OnFingerMove?.Invoke(PlayerDirection.Backward);
            }
        }

        #region Reset All values

        private void ResetVariablesToZero()
        {
            _fingerInitialPositionX = _fingerMovedPositionX = 
                _fingerInitialPositionY = 
                    _fingerMovedPositionY = 0;
        }

        private void ResetBoolToFalse()
        {
            _swipeUpOn = _swipeDownOn = _swipeRightOn = _swipeLeftOn = false;
        }

        #endregion

        private bool IsAllSwipeFalse()
        {
            return _swipeRightOn == false && _swipeLeftOn == false && _swipeUpOn == false && _swipeDownOn == false;
        }
        
        private bool IsLeftTouch()
        {
            if (Input.touchCount <= 0) return _isLeftTouch;

            var inputData = Input.GetTouch(0);
            // left touch true;
            if (inputData.position.x < _screenWidth)
            {
                if (inputData.phase == TouchPhase.Began) _isLeftTouch = true;
            }
            // left touch false;
            else if (inputData.position.x > _screenWidth)
            {
                if (inputData.phase == TouchPhase.Began) _isLeftTouch = false;
            }
            return _isLeftTouch;
        }
    }
}