public class Coin : GameComponent
{
    protected override void BallCollision() => Destroy(gameObject);
}
