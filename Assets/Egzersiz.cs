using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Egzersiz : MonoBehaviour
{

    public float ustRotationSpeed = 30.0f;
    public float altRotationSpeed = 40.0f;
    public int ustXd, ustYd, ustZd, altXd, altYd, altZd = 0;
    public float ustX, ustY, ustZ, altX, altY, altZ = 0.0f;
    public float zaman = 0.0f;
    public float zamanLimit = 0.1f;
    public float ustRotatResX, ustRotatResY, ustRotatResZ;
    public float altRotatResX, altRotatResY, altRotatResZ;
    Vector3 ustRotationReset = new Vector3();
    Vector3 altRotationReset = new Vector3();
    public bool resetControl = false;
    public float setUstX, setUstY, setUstZ, setAltX, setAltY, setAltZ = 0.0f;

    public void ResRes()
    {
        GameObject.Find("Model Ust Kol Kontrol").GetComponent<UDPTest2>().resetUstX = 0;
        GameObject.Find("Model Ust Kol Kontrol").GetComponent<UDPTest2>().resetUstY = 0;
        GameObject.Find("Model Ust Kol Kontrol").GetComponent<UDPTest2>().resetUstZ = 0;
        GameObject.Find("Model Alt Kol Kontrol").GetComponent<UDPTest2>().resetUstX = 0;
        GameObject.Find("Model Alt Kol Kontrol").GetComponent<UDPTest2>().resetUstY = 0;
        GameObject.Find("Model Alt Kol Kontrol").GetComponent<UDPTest2>().resetUstZ = 0;
        resetControl = false;
    }

    public void Res()
    {
        resetControl = true;

        ustRotationReset = GameObject.Find("Model Ust Kol Kontrol").GetComponent<Transform>().eulerAngles;
        altRotationReset = GameObject.Find("Model Alt Kol Kontrol").GetComponent<Transform>().eulerAngles;

        GameObject.Find("Model Ust Kol Kontrol").GetComponent<UDPTest2>().resetUstX = ustRotationReset.x;
        GameObject.Find("Model Ust Kol Kontrol").GetComponent<UDPTest2>().resetUstY = ustRotationReset.y;
        GameObject.Find("Model Ust Kol Kontrol").GetComponent<UDPTest2>().resetUstZ = ustRotationReset.z;
        GameObject.Find("Model Alt Kol Kontrol").GetComponent<UDPTest2>().resetAltX = altRotationReset.x;
        GameObject.Find("Model Alt Kol Kontrol").GetComponent<UDPTest2>().resetAltY = altRotationReset.y;
        GameObject.Find("Model Alt Kol Kontrol").GetComponent<UDPTest2>().resetAltZ = altRotationReset.z;


        ustRotatResX = ustRotationReset.x;
        ustRotatResY = ustRotationReset.y;
        ustRotatResZ = ustRotationReset.z;
        altRotatResX = altRotationReset.x;
        altRotatResY = altRotationReset.y;
        altRotatResZ = altRotationReset.z;

        



    }

    public void Curl()
    {
        zaman = 0.0f;
        zamanLimit = 10;
        ustX = 90;
        ustY = 90;
        ustZ = 90;
        altX = 90;
        altY = 90;
        altZ = 90;

        ustYd = 1;
        altYd = 1;

        
    }






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        ustRotatResX = ustRotationReset.x;
        ustRotatResY = ustRotationReset.y;
        ustRotatResZ = ustRotationReset.z;
        altRotatResX = altRotationReset.x;
        altRotatResY = altRotationReset.y;
        altRotatResZ = altRotationReset.z;



        zaman = zaman + Time.deltaTime;

        if (zaman <= zamanLimit)
        {
            switch (ustXd)
            {
                case 1:
                    ustX = ustX + Time.deltaTime * ustRotationSpeed;
                    break;
                case 2:
                    ustX = ustX - Time.deltaTime * ustRotationSpeed;
                    break;
            }

            switch (ustYd)
            {
                case 1:
                    ustY = ustY + Time.deltaTime * ustRotationSpeed;
                    break;
                case 2:
                    ustY = ustY - Time.deltaTime * ustRotationSpeed;
                    break;
            }

            switch (ustZd)
            {
                case 1:
                    ustZ = ustZ + Time.deltaTime * ustRotationSpeed;
                    break;
                case 2:
                    ustZ = ustZ - Time.deltaTime * ustRotationSpeed;
                    break;
            }

            switch (altXd)
            {
                case 1:
                    altX = altX + Time.deltaTime * altRotationSpeed;
                    break;
                case 2:
                    altX = altX - Time.deltaTime * altRotationSpeed;
                    break;
            }

            switch (altYd)
            {
                case 1:
                    altY = altY + Time.deltaTime * altRotationSpeed;
                    break;
                case 2:
                    altY = altY - Time.deltaTime * altRotationSpeed;
                    break;
            }

            switch (altZd)
            {
                case 1:
                    altZ = altZ + Time.deltaTime * altRotationSpeed;
                    break;
                case 2:
                    altZ = altZ - Time.deltaTime * altRotationSpeed;
                    break;
            }
        }
        

        if (GameObject.Find("Toggle").GetComponent<Toggle>().isOn == false)
        {
            GameObject.Find("Demo Ust Kol Kontrol").GetComponent<Transform>().rotation = Quaternion.Euler(ustX, ustY, ustZ);
            GameObject.Find("Demo Alt Kol Kontrol").GetComponent<Transform>().rotation = Quaternion.Euler(altX, altY, altZ);
            GameObject.Find("Demo Alt Kol Kontrol").GetComponent<Transform>().position = GameObject.Find("Demo Ust Kol Joint").transform.position;
        }
    }
}
