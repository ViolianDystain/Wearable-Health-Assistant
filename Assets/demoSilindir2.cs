using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Globalization;
using System.Text;

public class demoSilindir2 : MonoBehaviour
{

    float rotatZ = 0.0f;
    float rotationSpeed = 20.0f;
    float waitTime = 0.0f;
    float accuracy = 0.0f;
    Vector3 accuracyVector = new Vector3(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotatZ < 90){
            rotatZ = rotatZ + (Time.deltaTime * rotationSpeed);

        }
        if (rotatZ >= 90){
            rotatZ = 90;

            waitTime = waitTime + Time.fixedDeltaTime;

            Debug.Log("WAIT TIME = " + waitTime);

            if (waitTime > 2.0f){
                rotationSpeed = rotationSpeed * (-1);
                rotatZ = 89.0f;
                waitTime = 0;
            }

            
        }

        if (rotatZ <= 0) {
            rotatZ = 0;
        }

        Vector3 maviRotation = GameObject.Find("mavi").transform.eulerAngles;
        Vector3 maviModelRotation = transform.eulerAngles;

        accuracyVector = maviModelRotation - maviRotation;

        if (Math.Abs(accuracyVector.x) < 5.0f) {
            accuracyVector.x = 0.0f;
        }
        if (Math.Abs(accuracyVector.y) < 5.0f) {
            accuracyVector.y = 0.0f;
        }
        if (Math.Abs(accuracyVector.z) < 5.0f) {
            accuracyVector.z = 0.0f;
        }
        
        accuracy = Math.Abs(accuracyVector.x) + Math.Abs(accuracyVector.y) + Math.Abs(accuracyVector.z);

        

        



        transform.rotation = Quaternion.Euler(0.0f,0.0f,90.0f - rotatZ);

        GameObject.Find("Slider2").GetComponent<Slider>().value = accuracy;

    }
}
