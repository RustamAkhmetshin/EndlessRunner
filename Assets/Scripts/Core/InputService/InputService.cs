using System;
using UnityEngine;

namespace Core
{
    public class InputService : IInputService
    {
        public event Action OnJump;
        public event Action OnSlide;

        private bool _isEnabled = false;
        
        public void Enable()
        {
            _isEnabled = true;
        }

        public void Disable()
        {
            _isEnabled = false;
        }

        private Vector2 touchStart;
        private Vector2 touchEnd;
        private bool isSwipeDetected;

        public void Update()
        {
            if(!_isEnabled) return;

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        touchStart = touch.position;
                        isSwipeDetected = false;
                        break;

                    case TouchPhase.Moved:
                        if (!isSwipeDetected)
                        {
                            touchEnd = touch.position;
                            Vector2 delta = touchEnd - touchStart;

                            if (Mathf.Abs(delta.x) < Mathf.Abs(delta.y))
                            {
                                if (delta.y > 0)
                                    OnJump?.Invoke();
                                else
                                    OnSlide?.Invoke();
                            
                                isSwipeDetected = true;
                            }
                        }
                        break;
                }
            }
        }
    }
}