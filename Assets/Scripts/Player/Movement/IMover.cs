public interface IMover
{
    public void Move(float speed);
    public void Decelerate(float decelerationFactor, float fixedDeltaTime);
}