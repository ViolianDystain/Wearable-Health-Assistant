using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggleControl : MonoBehaviour
{
    public void ToggleControl()
    {
        if (gameObject.GetComponent<Toggle>().isOn == false)
        {
            GameObject.Find("Demo Ust Kol Kontrol").GetComponent<DemoUstKolControl>().sliderControl = false;
            GameObject.Find("Demo Alt Kol Kontrol").GetComponent<DemoAltKolControl>().sliderControl = false;
            
        }
        else
        {
            GameObject.Find("Demo Ust Kol Kontrol").GetComponent<DemoUstKolControl>().sliderControl = true;
            GameObject.Find("Demo Alt Kol Kontrol").GetComponent<DemoAltKolControl>().sliderControl = true;
        }
        
    }

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
