using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoUstKolControl : MonoBehaviour
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
            Vector3 demoUstRotation = new Vector3();
            demoUstRotation.x = GameObject.Find("Slider (3)").GetComponent<Slider>().value;
            demoUstRotation.y = GameObject.Find("Slider (4)").GetComponent<Slider>().value;
            demoUstRotation.z = GameObject.Find("Slider (5)").GetComponent<Slider>().value;
            transform.eulerAngles = demoUstRotation;
        }
        
    }
}
