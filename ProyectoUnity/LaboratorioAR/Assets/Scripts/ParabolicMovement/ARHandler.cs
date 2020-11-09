using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARHandler : MonoBehaviour {

    public GameObject objects;
    public GameObject arCamera;
    public GameObject normalCamera;
    public GameObject stage;

    public void changeCamera(){
        if(arCamera.activeInHierarchy)activateNormal();
        else activateAR();
    }
    
    private void activateAR(){
        normalCamera.SetActive(false);
        arCamera.SetActiveRecursively(true);
        stage.SetActive(true);
        objects.transform.SetParent(stage.transform, false);
    }

    private void activateNormal(){
        objects.transform.SetParent(null, false);
        arCamera.SetActiveRecursively(false);
        stage.SetActive(false);
        normalCamera.SetActive(true);
    }
}
