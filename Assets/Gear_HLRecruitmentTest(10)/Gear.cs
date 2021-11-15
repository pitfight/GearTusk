public class Gear : BaseGears 
{
    //Angular velocity
    public float AngularVelocity(float spd)
    {
        float angularVelocity = spd / coll.radius;
        return angularVelocity;
    }

    private void FixedUpdate()
    {
        Turn();
    }
}
