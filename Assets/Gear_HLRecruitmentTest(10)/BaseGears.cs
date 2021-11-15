using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public abstract class BaseGears : MonoBehaviour 
{
    //Is it active when the scene starts
    [SerializeField] private bool active;
    //Torsional force
    [SerializeField] private float torque;
    protected Rigidbody rb;
    protected CapsuleCollider coll;

    private void Awake()
    {
        coll = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        rb.angularDrag = 1f;
        rb.useGravity = false;
        coll.enabled = false;
    }

    public void Turn()
    {
        if (active)
            RotateGear();
    }

    protected virtual void RotateGear()
    {
        rb.AddTorque(Vector3.forward * torque);
    }

    //The speed of movement of points from the radius
    public float speed
    {
        get
        {
            float spd = torque * coll.radius;
            return spd;
        }
    }
    public void SetTorque(float torq)
    {
        torque = torq;
    }
    public void SetActiveGear(bool set)
    {
        active = set;
    }
}
