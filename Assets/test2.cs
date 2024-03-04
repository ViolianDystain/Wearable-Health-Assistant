using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Globalization;
using System.Text;

public class test2 : MonoBehaviour
{

    private CharacterController characterController;

    [SerializeField]
    private float movementSpeed = 3.0f;

    private Transform rotator;

    [SerializeField] 
    private float smoothing = 0.1f;

    float momentaryGyroX, momentaryGyroY, momentaryGyroZ, gyroX, gyroY, gyroZ, rotationX, rotationY, rotationZ, rotationTotalX, rotationTotalY, rotationTotalZ = 0;
    float i = 1;
    float gravityX, gravityY, gravityZ, quatX, quatY, quatZ, quatW, momentaryAccX, momentaryAccY, momentaryAccZ, accX, accY, accZ, movementX, movementY, movementZ, movementTotalX, movementTotalY, movementTotalZ = 0;
    float magX, magY, magZ, vX, vY, vZ = 0;
    float forceX = 0;
    float forceY = 0;
    float forceZ = 0;
    float aCorQuatX, aCorQuatY, aCorQuatZ, aCorQuatW, bCorQuatX, bCorQuatY, bCorQuatZ, bCorQuatW = 0.0f;
    float aFinQuatX, aFinQuatY, aFinQuatZ, aFinQuatW, bFinQuatX, bFinQuatY, bFinQuatZ, bFinQuatW = 0.0f;
    int check = 0;


    public int line;
    

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("maviRotation").transform.rotation = new Quaternion(0, 0, 0, 1);
        GameObject.Find("kirmiziRotation").transform.rotation = new Quaternion(0, 0, 0, 1);
        /*
        characterController = GetComponent<CharacterController>();

        rotator = new GameObject("Rotator").transform;
        rotator.SetPositionAndRotation(transform.position, transform.rotation);


        // Application.targetFrameRate = 50;

        //gameObject.GetComponent<Rigidbody>().AddForce(0,10,0);

        */


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion maviCurrentRotation = new Quaternion(-quatX, -quatY, -quatZ, quatW);
        accX = momentaryAccX;
        accY = momentaryAccY;
        accZ = momentaryAccZ;
        string[] textAcc = File.ReadAllLines(@"C:\Users\utku.ondin\Desktop\MetaWear-SDK-Python-master\MetaWear-SDK-Python-master\examples\streamAcc.txt");
        string[] textGyro = File.ReadAllLines(@"C:\Users\utku.ondin\Desktop\MetaWear-SDK-Python-master\MetaWear-SDK-Python-master\examples\streamGyro.txt");
        string[] textMag = File.ReadAllLines(@"C:\Users\utku.ondin\Desktop\MetaWear-SDK-Python-master\MetaWear-SDK-Python-master\examples\streamMag.txt");
        string[] textQuat = File.ReadAllLines(@"C:\Users\utku.ondin\Desktop\New folder\MetaWear-SDK-Python-master\examples\streamQuat.txt");
        string[] textGravity = File.ReadAllLines(@"C:\Users\utku.ondin\Desktop\MetaWear-SDK-Python-master\MetaWear-SDK-Python-master\examples\streamGravity.txt");

        
        
        momentaryGyroX = float.Parse(textGyro[line].Substring(0, 5), CultureInfo.InvariantCulture);
        momentaryGyroY = float.Parse(textGyro[line].Substring(6, 5), CultureInfo.InvariantCulture);
        momentaryGyroZ = float.Parse(textGyro[line].Substring(12, 5), CultureInfo.InvariantCulture);

          gravityX = float.Parse(textGravity[line].Substring(0, 5), CultureInfo.InvariantCulture);
          gravityY = float.Parse(textGravity[line].Substring(6, 5), CultureInfo.InvariantCulture);
          gravityZ = float.Parse(textGravity[line].Substring(12, 5), CultureInfo.InvariantCulture);

          momentaryAccX = float.Parse(textAcc[line].Substring(0, 5), CultureInfo.InvariantCulture);
          momentaryAccY = float.Parse(textAcc[line].Substring(6, 5), CultureInfo.InvariantCulture);
          momentaryAccZ = float.Parse(textAcc[line].Substring(12, 5), CultureInfo.InvariantCulture);

        //magX = float.Parse(textMag[line].Substring(0, 5), CultureInfo.InvariantCulture);
        //magY = float.Parse(textMag[line].Substring(6, 5), CultureInfo.InvariantCulture);
        //magZ = float.Parse(textMag[line].Substring(12, 5), CultureInfo.InvariantCulture);

          quatX = float.Parse(textQuat[line].Substring(0, 5), CultureInfo.InvariantCulture);
          quatY = float.Parse(textQuat[line].Substring(6, 5), CultureInfo.InvariantCulture);
          quatZ = float.Parse(textQuat[line].Substring(12, 5), CultureInfo.InvariantCulture);
          quatW = float.Parse(textQuat[line].Substring(18, 5), CultureInfo.InvariantCulture);

        rotationTotalX = momentaryGyroX + rotationTotalX; 
        rotationTotalY = momentaryGyroY + rotationTotalY;
        rotationTotalZ = momentaryGyroZ + rotationTotalZ;

        movementTotalX = momentaryAccX + movementTotalX; 
        movementTotalY = momentaryAccY + movementTotalY;
        movementTotalZ = momentaryAccZ + movementTotalZ;

        Debug.Log("X = " + rotationTotalX);
        Debug.Log("Y = " + rotationTotalY);
        Debug.Log("Z = " + rotationTotalZ);
        Debug.Log("Xacc = " + movementTotalX);
        Debug.Log("Yacc = " + movementTotalY);
        Debug.Log("Zacc = " + movementTotalZ); 

        

        

        
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
        /*
         if (forceX < 0.01f && forceX > -0.01f) {
        forceX = 0;
        }
        if (forceY < 0.01f && forceY > -0.01f) {
        forceY = 0;
        }
        if (forceZ < 0.01f && forceZ > -0.01f) {
          forceZ = 0;
         }
         */
        

        // Vector3 newRotation = new Vector3(rotationTotalX/50, rotationTotalY/25, (rotationTotalZ/100));
        // transform.eulerAngles = newRotation;


        Vector3 sphereLocation = GameObject.Find("Sphere").transform.position;



        if (line == 1) {
            transform.position = sphereLocation;

        }



        // gameObject.GetComponent<Rigidbody>().AddForce(forceX,forceY,forceZ);
        

        if (line == 0) {
            /*
            gameObject.transform.localRotation = new Quaternion(quatX, quatY, quatZ, quatW);

            if (Input.GetKeyDown("space"))
            {
                aCorQuatX = -quatX;
                aCorQuatY = -quatY;
                aCorQuatZ = -quatZ;
                aCorQuatW = 1-quatW;
                Debug.Log("KEY PRESSED");
                Quaternion maviCurrentRotation = Quaternion.Euler(-1 * (transform.rotation.x), -1 * (transform.rotation.y), -1 * (transform.rotation.y));
                GameObject.Find("maviRotation").transform.localRotation = maviCurrentRotation;
                // Quaternion dirsekRotation = GameObject.Find("kirmizi").transform.localRotation;
            }
            aFinQuatX = quatX + aCorQuatX;
            aFinQuatY = quatY + aCorQuatY;
            aFinQuatZ = quatZ + aCorQuatZ;
            aFinQuatW = quatW + aCorQuatW;
            
            */

            if (Input.GetKeyDown("space"))
            {
                check = 1;
                maviCurrentRotation = new Quaternion(-quatX, quatY, quatZ, quatW);
                GameObject.Find("maviRotation").transform.rotation = maviCurrentRotation;

            }

           
            transform.rotation = new Quaternion(-quatX, quatY, quatZ, quatW);
             




            }
        else if (line == 1) {
            gameObject.transform.rotation = new Quaternion(-quatX, quatY, quatZ, quatW);
            

        }
        






        // transform.rotation = Quaternion.Euler(magX, magY, magZ);

        //transform.position = new Vector3(accX,accY,accZ);

        //Move();
        //LookAround();

    }
    /*
    private void Move()
    {
    Vector3 acceleration = new Vector3(forceX,forceY,forceZ);
    if (momentaryAccX < 0.01f && momentaryAccX > -0.01f) {
        momentaryAccX = 0;
    }
    if (momentaryAccY < 0.01f && momentaryAccY > -0.01f) {
        momentaryAccY = 0;
    }
    if (momentaryAccZ < 0.01f && momentaryAccZ > -0.01f) {
        momentaryAccZ = 0;
    }
    vX = (momentaryAccX * Time.deltaTime);
    vY = (momentaryAccY * Time.deltaTime);
    vZ = (momentaryAccZ * Time.deltaTime);
    Vector3 velocity = new Vector3(vX,vY,vZ);
    Debug.Log("VELOCITY X = " + vX);
    Debug.Log("VELOCITY Y = " + vY);
    Debug.Log("VELOCITY Z = " + vZ);

    Vector3 moveDirection = new(vX,vY,vZ);
    Vector3 transformedDirection = transform.TransformDirection(moveDirection);

    characterController.Move(transformedDirection);
    }

    private void LookAround()
    {
        Quaternion attitude = new Quaternion(quatX,quatY,quatZ,quatW);

        rotator.rotation = attitude;
        rotator.Rotate(0f, 0f, 180f, Space.Self);
        rotator.Rotate(90f, 180f, 0f, Space.World);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotator.rotation, smoothing);
    }
    */

}
