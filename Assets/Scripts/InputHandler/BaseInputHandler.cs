using UnityEngine;

namespace InputHandler
{
    public abstract class BaseInputHandler : MonoBehaviour
    {
        private float _pressedTime;
        
        private Camera _mainCamera;
        private IInputType _input;

        private void Awake()
        {
            _mainCamera = Camera.main;
            _input = new PCInputs();
            _input.Init(this);
        }

        private void Update()
        {
            _input.Handle();
        }

        public virtual void OnRightButtonClick() { }

        public virtual void OnLeftButtonClick() { }

        protected RaycastHit GetRaycastHit()
        {
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out var hit, 100);
            return hit;
        }

        protected bool TryGetComponentFromHit<T>(out T component)
        {
            var rayCollider = GetRaycastHit().collider;
            if (!rayCollider)
            {
                component = default;
                return false;
            }
            return rayCollider.TryGetComponent<T>(out component);
        }
    }
}