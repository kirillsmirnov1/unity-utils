﻿using System;
using UnityEngine;

 namespace UnityUtils.Camera
{
    [RequireComponent(typeof(UnityEngine.Camera))]
    public class FitCamera : MonoBehaviour
    {
        public static event Action OnCameraResized;
        
#pragma warning disable 0649
        [SerializeField] private GameObject objectToFit;
        [SerializeField] private FitType fitType;
        [SerializeField] private float fitCoefficient = 1f;
        [SerializeField] private bool resizeOnUpdate;
#pragma warning restore 0649

        private UnityEngine.Camera _camera;
        private Bounds _boundsToFit;

        private void Awake()
        {
            _camera = GetComponent<UnityEngine.Camera>();
            _boundsToFit = objectToFit.GetComponent<Renderer>().bounds;
            Resize();
        }

        private void Update()
        {
            if (resizeOnUpdate)
            {
                Resize();
            }
        }

        private void Resize()
        {
            switch (fitType)
            {
                case FitType.FitWidth: 
                    _camera.orthographicSize = _boundsToFit.size.x * Screen.height / Screen.width * 0.5f * fitCoefficient;
                    break;
                case FitType.FitHeight:
                    _camera.orthographicSize = _boundsToFit.size.y * 0.5f * fitCoefficient;
                    break;
            }
            
            OnCameraResized?.Invoke();
        }
    }

    public enum FitType
    {
        FitWidth, 
        FitHeight,
    }
}
