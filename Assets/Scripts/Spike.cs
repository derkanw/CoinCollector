public class Spike : GameComponent
{
    protected override void BallCollision() => _animator.SetTrigger("Collision");
}
