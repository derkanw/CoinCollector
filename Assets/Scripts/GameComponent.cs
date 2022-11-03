using UnityEngine;

public abstract class GameComponent : MonoBehaviour
{
    public static float SpawnRadius;
    public static Vector3 ReservedPosition;

    protected Animator _animator;
    private Vector3 _position;

    protected abstract void BallCollision();
    private void Awake()
    {
        _animator = gameObject.transform.GetChild(0).GetComponent<Animator>();
        //_animator.SetBool("Move", true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(ETags.Ball.ToString()))
            BallCollision();
        else
        {
            do
                _position = Random.onUnitSphere * SpawnRadius;
            while (_position.Equals(ReservedPosition));

            gameObject.transform.position = _position;
            transform.LookAt(_position);
        }
    }
}
