using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GravityAttractor : MonoBehaviour
{
    private const float _gravity = -9.8f;

    //private bool _isMovable = true;


    public void Attract(Transform body)
    {
        Vector3 targetDirection = (body.position - transform.position).normalized;
        body.rotation = Quaternion.FromToRotation(body.up, targetDirection) * body.rotation;
        body.GetComponent<Rigidbody>().AddForce(targetDirection * _gravity);

        /*var targetRotation = direction * -Speed;
        var duration = Quaternion.Angle(transform.rotation, Quaternion.Euler(targetRotation)) / Speed;
        _rigidbody.DORotate(targetRotation, duration);*/
    }

    public void Cancel(Transform body)
    {
        Vector3 targetDirection = (body.position - transform.position).normalized;

        body.GetComponent<Rigidbody>().AddForce(-targetDirection * _gravity);
    }

    private void FixedUpdate()
    {
    }

    //=> _targetDirection = direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
}
