using UnityEngine;
using UnityEngine.EventSystems;

namespace InputHandler
{
    public class MobileInputs : IInputType
    {
        private float _pressedTime;
        private bool _pressed;
        private BaseInputHandler _baseInputHandler;

        public void Init(BaseInputHandler baseInputHandler)
        {
            _baseInputHandler = baseInputHandler;
        }

        public void Handle()
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;
            
            if (Input.touches.Length > 0)
            {
                _pressedTime += Time.fixedDeltaTime;
                _pressed = true;
                
                if (_pressedTime >= 2)
                {
                    _baseInputHandler.OnRightButtonClick();
                    Reset();
                }
            }
            else
            {
                if (_pressed) _baseInputHandler.OnLeftButtonClick();
                Reset();
            }
        }

        private void Reset()
        {
            _pressedTime = 0;
            _pressed = false;
        }
    }
}