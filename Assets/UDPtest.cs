using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
// using UnityEditor.Search;
using UnityEngine;

public class UDPtest : MonoBehaviour
{
    public string dataGet, qquatX, qquatY, qquatZ, qquatW;
    public float quatX, quatY, quatZ, quatW = 0.0f;
    int check = 0;
    public UDPReceive udpReceive;
    private object a;
    public float eulerX, eulerY, eulerZ, teulerX, teulerY, teulerZ = 0.0f;
    string dataSet;

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

        

        eulerX = quatX + eulerX;
        eulerY = quatY + eulerY;
        eulerZ = quatZ + eulerZ;

        
        
        if (gameObject.name == "kirmizi" && dataSet == "6B")
        {
            Vector3 sphereLocation = GameObject.Find("maviSphere").transform.position;
            transform.position = sphereLocation;
            gameObject.transform.localRotation = new Quaternion(quatX, quatY, quatZ, quatW);

        }
        else if (gameObject.name == "mavi" && dataSet == "FC")
        {
            gameObject.transform.localRotation = new Quaternion(quatX, quatY, quatZ, quatW);

        }
    }

    

    
}
