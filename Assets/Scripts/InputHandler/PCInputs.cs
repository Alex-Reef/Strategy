using UnityEngine;
using UnityEngine.EventSystems;

namespace InputHandler
{
    public class PCInputs : IInputType
    {
        private BaseInputHandler _baseInputHandler;
        
        public void Init(BaseInputHandler baseInputHandler)
        {
            _baseInputHandler = baseInputHandler;
        }

        public void Handle()
        {
            if (!Input.anyKeyDown || EventSystem.current.IsPointerOverGameObject()) return;
            
            if(Input.GetMouseButtonDown(0)) _baseInputHandler.OnLeftButtonClick();
            if(Input.GetMouseButtonDown(1)) _baseInputHandler.OnRightButtonClick();
        }
    }
}