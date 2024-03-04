using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dirsekModel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dirsekLocation = GameObject.Find("kirmizi").transform.position;

        Quaternion dirsekRotation = GameObject.Find("kirmizi").transform.localRotation;

        transform.position = dirsekLocation;

        gameObject.transform.localRotation = dirsekRotation;
     
    }
}
