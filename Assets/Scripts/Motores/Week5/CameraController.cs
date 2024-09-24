using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Motores.Week5
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Camera cameraReference;
        [SerializeField] private CamerasManager cameraManager;

        public UnityEvent OnActivate;
        public UnityEvent OnDeactivate;

        private bool _wasActive;

        private void Awake()
        {
            if(cameraManager == null)
            {
                cameraManager = (CamerasManager)FindObjectOfType(typeof(CamerasManager));
            }

            if(cameraReference == null)
            {
                cameraReference = GetComponent<Camera>();
            }

            _wasActive = true;
        }

        private void OnEnable()
        {
            cameraManager.OnNextCamera += CheckCameraStatus;
            cameraManager.OnPreviousCamera += CheckCameraStatus;
        }

        private void OnDisable()
        {
            cameraManager.OnNextCamera -= CheckCameraStatus;
            cameraManager.OnPreviousCamera -= CheckCameraStatus;
        }

        private void CheckCameraStatus(CameraController instance)
        {
            if (this != instance)
            {
                DeactivateCamera();
            }
            else
            {
                ActivateCamera();
            }
        }

        private void ActivateCamera()
        {
            cameraReference.enabled = true;

            OnActivate?.Invoke();

            _wasActive = true;
        }

        private void DeactivateCamera()
        {
            if (!_wasActive) return;

            cameraReference.enabled = false;

            OnDeactivate?.Invoke();

            _wasActive = false;
        }
    }
}