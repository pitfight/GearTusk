using UnityEngine;

public class TransformObject : MonoBehaviour
{
    private LevelArmControll armControll;
    public ConfigurableJoint joint;

    private void Start()
    {
        armControll = FindObjectOfType<LevelArmControll>();
    }
    private void FixedUpdate()
    {
        Vector3 dir = armControll.Direction;
        joint.targetVelocity += new Vector3(0, dir.x);
        joint.targetVelocity = new Vector3(0, Mathf.Clamp(joint.targetVelocity.y, -5.50f, 9.30f));

    }
}
