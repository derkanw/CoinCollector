using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class CameraMovement : MonoBehaviour
{
    private CinemachineComposer _vcam;

    private float _trackedPosition;
    private const float _maxOffset = 0f;

    public void Rotate(Vector2 offset)
    {
        _trackedPosition += offset.y;
        _trackedPosition = Mathf.Clamp(_trackedPosition, -_maxOffset, _maxOffset);
        _vcam.m_TrackedObjectOffset.y = _trackedPosition; //???
    }

    private void Awake()
    {
        _vcam = GetComponent<CinemachineVirtualCamera>().GetComponentInChildren<CinemachineComposer>();
    }
}
