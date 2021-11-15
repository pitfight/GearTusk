using UnityEngine;

public class GeneralGear : BaseGears
{
    private LevelArmControll armControll;
    public ConfigurableJoint joint;
    private Settings settings;

    private void Start()
    {
        armControll = FindObjectOfType<LevelArmControll>();
        settings = FindObjectOfType<Settings>();
    }
    private void FixedUpdate()
    {
        RotateGear();
        Vector3 dir = armControll.Direction;
        joint.targetVelocity += new Vector3(0,dir.x);
        joint.targetVelocity = new Vector3(0,Mathf.Clamp(joint.targetVelocity.y, -5.50f, 9.30f));
        if (joint.targetVelocity.y == -5.50f)
            settings.RunGears(BehaviorEngine.ForceForwad);
        else if (joint.targetVelocity.y == 9.30f)
            settings.RunGears(BehaviorEngine.ForceBack);
        else
            settings.RunGears(BehaviorEngine.Stop);
    }

    protected override void RotateGear()
    {
        base.RotateGear();
    }
}
