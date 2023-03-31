using UnityEngine;
using System;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public event Action Burst = () => { };
    public event Action CollectCoin = () => { };

    public GravityAttractor Attractor { set; private get; }

    [SerializeField] [Range(0f, 10f)] private float Speed; // hmm

    private Rigidbody _rigidbody;
    private Animator _animator;
    private float _duration = 1f;

    private void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        _rigidbody.useGravity = false;
    }

    private void OnTriggerEnter(Collider other) // reorganize
    {
        if (other.CompareTag(ETags.Spike.ToString())) CollectCoin();
        else
            if (other.CompareTag(ETags.Spike.ToString()))
        {
            Burst();
            _animator.SetTrigger("Burst");
        }
    }

    public void Rotate(Vector2 offset)
    {
        transform.Rotate(Vector3.up * offset.x); //???
    }

    public void MoveTo(Vector3 position)
    {
        _rigidbody.DOMove(transform.TransformDirection(position) + transform.position, _duration);
        Attractor.Attract(transform);
    }

}
