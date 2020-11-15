using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class ARHandler : MonoBehaviour {

    public GameObject objects;
    public GameObject arCamera;
    public GameObject normalCamera;
    public GameObject stage;
    public PlaneFinderBehaviour plane;
    public UIController uiController;

    public void changeCamera(){
        if(arCamera.activeInHierarchy)activateNormal();
        else activateAR();
    }
    
    private void activateAR(){
        uiController.activateARUI(true);
        normalCamera.SetActive(false);
        arCamera.SetActiveRecursivelyExt(true);
        stage.SetActive(true);
        objects.transform.SetParent(stage.transform, false);
    }

    private void activateNormal(){
        uiController.activateARUI(false);
        objects.transform.SetParent(null, false);
        arCamera.SetActiveRecursivelyExt(false);
        stage.SetActive(false);
        normalCamera.SetActive(true);
        objects.SetActiveRecursivelyExt(true);
    }

    public void onTrigger(){
        Vector2 pos = new Vector2(0,0);
        plane.PerformHitTest(pos);
    }

}
