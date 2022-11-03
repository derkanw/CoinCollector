using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private bool _isActive = true;

    public event Action<Vector3> ChangedPosition = (Vector3) => { };

    public void Disable() => _isActive = false;

    private void MovePlayer()
    {
        Vector3 position = Vector3.zero;
        position.x = Input.GetAxisRaw("Horizontal");
        position.z = Input.GetAxisRaw("Vertical");
        ChangedPosition(position);
    }

    private void Update()
    {
        if (!_isActive) return;
        MovePlayer();
    }
}
