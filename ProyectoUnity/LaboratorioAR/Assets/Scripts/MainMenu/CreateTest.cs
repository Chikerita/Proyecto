using UnityEngine;

public class CreateTest : MonoBehaviour {

    public GameObject pmFormPrefab;
    public Transform listViewContent;

    public void newPMQuestion(){
        GameObject form = (GameObject) Instantiate (pmFormPrefab);
        form.transform.SetParent(listViewContent, false);
        foreach (Transform child in listViewContent.transform){
            Debug.Log(child.name);
        }
    }

}
