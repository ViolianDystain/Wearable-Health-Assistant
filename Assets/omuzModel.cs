using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class omuzModel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 omuzLocation = GameObject.Find("mavi").transform.position;

        Quaternion omuzRotation = GameObject.Find("mavi").transform.localRotation;

        transform.position = omuzLocation;

        gameObject.transform.localRotation = new Quaternion(omuzRotation.y,omuzRotation.z,omuzRotation.x,omuzRotation.w);

        // y > x, z > y, x > z
        
    }
}
