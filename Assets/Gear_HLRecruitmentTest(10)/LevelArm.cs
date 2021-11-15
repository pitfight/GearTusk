using UnityEngine;

public class LevelArm : MonoBehaviour
{ 
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.forward;
    }
}
