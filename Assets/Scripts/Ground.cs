using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ground : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _targetDirection;
    //private bool _isMovable = true;

    [SerializeField] [Range(0f, 10f)] private float Speed; // hmm

    public void Rotate(Vector3 direction)
    {
        var targetRotation = direction * -Speed;
        var duration = Quaternion.Angle(transform.rotation, Quaternion.Euler(targetRotation)) / Speed;
        _rigidbody.DORotate(targetRotation, duration);
    }



    //=> _targetDirection = direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //var duration = (_currentPosition - new Vector2(transform.position.x, transform.position.y)).magnitude / Speed;

    }
}
