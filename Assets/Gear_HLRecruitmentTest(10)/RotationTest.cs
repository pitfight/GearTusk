using UnityEngine;

public class RotationTest : MonoBehaviour
{

    public float torque;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        float turn = Input.GetAxis("Horizontal");
        rb.AddTorque(Vector3.forward * torque * turn);
    }
}
