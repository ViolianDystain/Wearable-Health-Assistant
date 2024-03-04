using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoAltKolControl : MonoBehaviour
{

    public bool sliderControl = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sliderControl == true)
        {
            Vector3 demoAltRotation = new Vector3();
            demoAltRotation.x = GameObject.Find("Slider").GetComponent<Slider>().value;
            demoAltRotation.y = GameObject.Find("Slider (1)").GetComponent<Slider>().value;
            demoAltRotation.z = GameObject.Find("Slider (2)").GetComponent<Slider>().value;
            transform.eulerAngles = demoAltRotation;
        }
        transform.position = GameObject.Find("Demo Ust Kol Joint").transform.position;
        

        
    }
}
