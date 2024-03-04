using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
// using UnityEditor.Search;
using UnityEngine;
/*

public class UDPTest3 : MonoBehaviour
{
    public GameObject airplane;
    public Quat quat = new Quat(0, 0, 0, -1);
    public float speed = 0.01f;
    public string dataGet, qquatX, qquatY, qquatZ, qquatW;
    public float quatX, quatY, quatZ, quatW = 0.0f;
    int check = 0;
    public UDPReceive udpReceive;
    private object a;
    public float altEulerX, altEulerY, altEulerZ, ustEulerX, ustEulerY, ustEulerZ;
    string dataSet;
    public float resetUstX, resetUstY, resetUstZ, resetAltX, resetAltY, resetAltZ;
    public float manuelUstSetX, manuelUstSetY, manuelUstSetZ;

    void FixedUpdate()
    {
        float inputX = Input.GetAxis("UpDown");
        float inputY = Input.GetAxis("LeftRight");
        float inputZ = Input.GetAxis("Roll");

        Quat qx = new Quat(Mathf.Cos(speed * inputX / 2), 0, 0, Mathf.Sin(speed * inputX / 2));
        Quat qy = new Quat(Mathf.Cos(speed * inputY / 2), 0, Mathf.Sin(speed * inputY / 2), 0);
        Quat qz = new Quat(Mathf.Cos(speed * inputZ / 2), Mathf.Sin(speed * inputZ / 2), 0, 0);

        quat = Quat.Multiply(qx, quat);
        quat = Quat.Multiply(qy, quat);
        quat = Quat.Multiply(qz, quat);

        airplane.transform.rotation = quat.ToUnityQuaternion();
    }


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {


        

        

        dataGet = udpReceive.data.ToString();
        dataGet = dataGet.Remove(0, 1);
        dataSet = dataGet.Substring(dataGet.Length - 2, 2);
        dataGet = dataGet.Remove(dataGet.Length - 4, 4);
        string[] info = dataGet.Split(',');
        for (int i = 0; i < info.Length; i++)
        {
            info[i] = info[i].Remove(0, 4);
        }
        //qquatW = info[0];
        qquatX = info[0];
        qquatY = info[1];
        qquatZ = info[2];

        quatX = float.Parse(info[1]);
        quatY = float.Parse(info[2]);
        quatZ = float.Parse(info[3]);
        quatW = float.Parse(info[0]);

        if (GameObject.Find("resres").GetComponent<Egzersiz>().resetControl == false)
        {
            resetAltX = 0.0f;
            resetAltY = 0.0f;
            resetAltZ = 0.0f;
            resetUstX = 0.0f;
            resetUstY = 0.0f;
            resetUstZ = 0.0f;
        }
        else if (GameObject.Find("resres").GetComponent<Egzersiz>().resetControl == true)
        {
            resetAltX = GameObject.Find("Reset").GetComponent<Egzersiz>().altRotatResX;
            resetAltY = GameObject.Find("Reset").GetComponent<Egzersiz>().altRotatResY;
            resetAltZ = GameObject.Find("Reset").GetComponent<Egzersiz>().altRotatResZ;
            resetUstX = GameObject.Find("Reset").GetComponent<Egzersiz>().ustRotatResX;
            resetUstY = GameObject.Find("Reset").GetComponent<Egzersiz>().ustRotatResY;
            resetUstZ = GameObject.Find("Reset").GetComponent<Egzersiz>().ustRotatResZ;
        }
        







        if (gameObject.name == "Model Alt Kol Kontrol" && dataSet == "6B")
        {
            Vector3 sphereLocation = GameObject.Find("Model Ust Kol Joint").transform.position;
            transform.position = sphereLocation;
            gameObject.transform.rotation = new Quaternion(quatX, quatY, quatZ, quatW);
            
            

        }
        else if (gameObject.name == "Model Ust Kol Kontrol" && dataSet == "FC")
        {
            gameObject.transform.rotation = new Quaternion(quatX, quatY, quatZ, quatW);

            manuelUstSetX = GameObject.Find("Model Ust Kol Kontrol").GetComponent<Transform>().eulerAngles.x;
            manuelUstSetY = GameObject.Find("Model Ust Kol Kontrol").GetComponent<Transform>().eulerAngles.y;
            manuelUstSetZ = GameObject.Find("Model Ust Kol Kontrol").GetComponent<Transform>().eulerAngles.z;
            Vector3 manuelSetUst = new Vector3();
            manuelSetUst.x = manuelUstSetX;
            manuelSetUst.z = manuelUstSetY;
            manuelSetUst.y = manuelUstSetZ * -1;

            gameObject.transform.rotation = Quaternion.Euler(manuelSetUst);



        }
        
        altEulerX = GameObject.Find("Model Alt Kol Kontrol").GetComponent<Transform>().rotation.x;
        //altEulerY = altCurrRotationVector.y;
        //altEulerZ = altCurrRotationVector.z;


        ustEulerX = GameObject.Find("Model Ust Kol Kontrol").GetComponent<Transform>().rotation.x;
        // ustEulerY = ustCurrRotationVector.y;
        // ustEulerZ = ustCurrRotationVector.z;
        







        if (gameObject.name == "Model Alt Kol Kontrol" && dataSet == "6B")
        {

            
            gameObject.transform.Rotate(resetAltX * -1, resetAltY * -1, resetAltZ * -1);
        }

        else if (gameObject.name == "Model Ust Kol Kontrol" && dataSet == "FC")
        {
            
            gameObject.transform.Rotate(resetUstX * -1, resetUstY * -1, resetUstZ * -1);
        }

        


    }




}
        */
