using UnityEngine;
using System.Collections;

public class PropScript : MonoBehaviour
{
    public int dir;

    void FixedUpdate()
    {
        transform.Rotate(0, ((transform.root.GetComponent<QuadScript>().throttle + 1) * 1000 * dir), 0);
    }
}
