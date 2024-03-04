using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DogrulukSlider : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "Ust Kol Dogruluk")
        {
            Slider slider = GetComponent<Slider>();
            slider.value = Vector3.Distance(GameObject.Find("Demo Ust Kol Joint").GetComponent<Transform>().position, GameObject.Find("Model Ust Kol Joint").GetComponent<Transform>().position);
            if (slider.value < 10) { GameObject.Find("Hatali").GetComponent<TextMeshProUGUI>().text = "DOGRU HAREKET"; }
            else if (slider.value > 10) { GameObject.Find("Hatali").GetComponent<TextMeshProUGUI>().text = "YANLIS HAREKET"; }
        }
        
        if (gameObject.name == "Alt Kol Dogruluk")
        {
            Slider slider = GetComponent<Slider>();
            slider.value = Vector3.Distance(GameObject.Find("Demo Alt Kol Joint").GetComponent<Transform>().position, GameObject.Find("Model Alt Kol Joint").GetComponent<Transform>().position);
            if (slider.value < 10) { GameObject.Find("Hatali").GetComponent<TextMeshProUGUI>().text = "DOGRU HAREKET"; }
            else if (slider.value > 10) { GameObject.Find("Hatali").GetComponent<TextMeshProUGUI>().text = "YANLIS HAREKET"; }
        }
    }
}