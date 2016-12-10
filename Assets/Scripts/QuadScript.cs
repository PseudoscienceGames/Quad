using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class QuadScript : MonoBehaviour
{
    public float throttle;
    public float yaw;
    public float pitch;
    public float roll;
    public float thrust;

    public float rotScale;

    public Rigidbody myRB;
    public GameObject myCam;

    void Update()
    {
        throttle = Input.GetAxis("Throttle") + 1;
        pitch = Mathf.Pow(Input.GetAxis("Pitch"), 3);
        roll = Mathf.Pow(Input.GetAxis("Roll"), 3);
        yaw = Mathf.Pow(Input.GetAxis("Yaw"), 3);

        transform.Rotate(new Vector3(pitch, yaw, -roll) * rotScale);

        if (Input.GetButtonDown("Fire1"))
            PhotonNetwork.Instantiate("Bullet", transform.position, transform.rotation, 0);
    }

    void FixedUpdate()
    {
        thrust = Mathf.Pow(throttle, 2) * -Physics.gravity.y * myRB.mass;
        myRB.AddForce(transform.up * thrust);
    }
}
