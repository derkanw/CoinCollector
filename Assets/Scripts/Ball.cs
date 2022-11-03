using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    public event Action Burst = () => { };
    public event Action CollectCoin = () => { };

    private Animator _animator;

    private void Awake()
    {
        //_animator = gameObject.transform.GetChild(0).GetComponent<Animator>();
        //_animator.SetBool("Move", true);
    }

    private void Update()
    {
        /*if (!_isMovable || !MovementController.TryGetPosition(out _currentPosition)) return;
        _isMovable = false;
        var duration = (_currentPosition - new Vector2(transform.position.x, transform.position.y)).magnitude / Speed;
        _rigidbody.DOMove(_currentPosition, duration).OnComplete(() => _isMovable = true);*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ETags.Spike.ToString())) CollectCoin();
        else
            if (other.CompareTag(ETags.Spike.ToString()))
        {
            Burst();
            _animator.SetTrigger("Burst");
        }
    }
}
