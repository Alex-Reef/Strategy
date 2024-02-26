using Joystick_Pack.Scripts.Joysticks;
using UnityEngine;

namespace Utils
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private FixedJoystick fixedMovementJoystick;
        [SerializeField] private FixedJoystick fixedRotationJoystick;
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private Transform cameraParentTransform;
        [SerializeField] private float speed;
        [SerializeField] private float mouseSensitivity;
    
        private float _xRotation = 0f;
    
        private void Update()
        {
            HandleMovement();
            HandleRotation();
        }

        private void HandleMovement()
        {
            if (fixedMovementJoystick.Horizontal != 0 && fixedMovementJoystick.Vertical != 0)
            {
                Vector3 move = cameraParentTransform.right * fixedMovementJoystick.Horizontal + cameraParentTransform.forward * fixedMovementJoystick.Vertical;
                cameraParentTransform.position += move * speed * Time.fixedDeltaTime;
            }
        }

        private void HandleRotation()
        {
            if (fixedRotationJoystick.Horizontal != 0 && fixedRotationJoystick.Vertical != 0)
            {
                float x = fixedRotationJoystick.Vertical * mouseSensitivity * Time.fixedDeltaTime;
                float y = fixedRotationJoystick.Horizontal * mouseSensitivity * Time.fixedDeltaTime;
            
                _xRotation += x;
                _xRotation = Mathf.Clamp(_xRotation, -90, 90);
            
                cameraTransform.localEulerAngles = new Vector3(-_xRotation, transform.localEulerAngles.y, cameraTransform.localEulerAngles.z);
                cameraParentTransform.Rotate(0, y, 0);
            }
        }
    }
}
