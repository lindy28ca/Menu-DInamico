using System;
using System.Collections.Generic;
using UnityEngine;

namespace Motores.Week5
{
    public class CamerasManager : MonoBehaviour
    {
        [SerializeField] private List<CameraController> camerasList;
        [SerializeField] private int elementPosition = 0;

        public Action<CameraController> OnNextCamera;
        public Action<CameraController> OnPreviousCamera;

        private void Awake()
        {
            elementPosition = 0;
        }

        private void Start()
        {
            OnNextCamera?.Invoke(camerasList[elementPosition]);
        }

        public void ActivateNextCamera()
        {
            elementPosition = ++elementPosition % camerasList.Count;

            OnNextCamera?.Invoke(camerasList[elementPosition]);
        }

        public void ActivatePreviousCamera()
        {
            elementPosition = elementPosition - 1 >= 0 ? elementPosition - 1 : camerasList.Count - 1;

            OnPreviousCamera?.Invoke(camerasList[elementPosition]);
        }

        public void ActivateCameraByIndex(int newPosition)
        {
            elementPosition = newPosition;

            OnNextCamera?.Invoke(camerasList[elementPosition]);
        }
    }
}