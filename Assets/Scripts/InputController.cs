using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private bool _isActive = true;

    public event Action<Vector3> ChangedPosition = (Vector3) => { };
    public event Action<Vector2> ChangedRotation = (Vector2) => { };

    public void Disable() => _isActive = false;

    private void Update()
    {
        if (!_isActive) return;
        //ChangedPosition(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized);
        ChangedPosition((Vector3.forward * Input.GetAxis("Vertical")).normalized);
        ChangedRotation(new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")));

    }
}
