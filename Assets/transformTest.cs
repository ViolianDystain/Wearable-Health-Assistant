using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;
using System.Globalization;
using System.Text;
using UnityEngine;



public class transformTest : MonoBehaviour
{
    int inc = 0;
    float momentaryAccX,momentaryAccY,momentaryAccZ,accX,accY,accZ = 0;
    string[] lines = File.ReadAllLines("test.txt");
    float forceX = 0;
    float forceY = 0;
    float forceZ = 0;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        
        
        

        
    }
    

    // Update is called once per frame
    void Update()
    {
        accX = momentaryAccX;
        accY = momentaryAccY;
        accZ = momentaryAccZ;
        
        Debug.Log(lines[inc]);
        Debug.Log(inc);
        Debug.Log("-" + (lines[inc].Substring(lines[inc].IndexOf("x") + 4, 5)) + "-");
        momentaryAccX = float.Parse(lines[inc].Substring(lines[inc].IndexOf("x") + 4, 5), CultureInfo.InvariantCulture);
        momentaryAccY = float.Parse(lines[inc].Substring(lines[inc].IndexOf("y") + 4, 5), CultureInfo.InvariantCulture);
        momentaryAccZ = float.Parse(lines[inc].Substring(lines[inc].IndexOf("z") + 4, 5), CultureInfo.InvariantCulture);

        Debug.Log(accX);
        Debug.Log(momentaryAccX);

        if (momentaryAccX > accX) {
            forceX = Math.Abs(momentaryAccX - accX);
        }
        else if (momentaryAccX < accX) {
            forceX = Math.Abs(momentaryAccX - accX) * -1;
        }
        else if (momentaryAccX == accX) {
            forceX = 0;
        }

        if (momentaryAccY > accY) {
            forceY = Math.Abs(momentaryAccY - accY);
        }
        else if (momentaryAccY < accY) {
            forceY = Math.Abs(momentaryAccY - accY) * -1;
        }
        else if (momentaryAccY == accY) {
            forceY = 0;
        }

        if (momentaryAccZ > accZ) {
            forceZ = Math.Abs(momentaryAccZ - accZ);
        }
        else if (momentaryAccZ < accZ) {
            forceZ = Math.Abs(momentaryAccZ - accZ) * -1;
        }
        else if (momentaryAccZ == accZ) {
            forceZ = 0;
        }

        Debug.Log("ForceX = " + forceX);

        

        gameObject.GetComponent<Rigidbody>().AddForce(forceY,forceX,forceZ);
        inc = inc + 1;
    }
}
