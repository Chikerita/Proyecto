using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtributeController : MonoBehaviour {

    public GameObject panelContainer;
    public Slider firstSlider;
    public Slider secondSlider;
    
    public void showControllers(){
        if (panelContainer.activeInHierarchy) panelContainer.SetActive(false);
        else panelContainer.SetActive(true);
    }

}
