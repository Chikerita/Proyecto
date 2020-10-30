using UnityEngine;

public class CreateTest : MonoBehaviour {

    public GameObject pmFormPrefab;
    public Transform listViewContent;
    private string questionaryJson;

    public void newPMQuestion(){
        GameObject form = (GameObject) Instantiate (pmFormPrefab);
        form.transform.SetParent(listViewContent, false);
        foreach (Transform child in listViewContent.transform){
            Debug.Log(child.name);
        }
    }

    public void create(){
        Questionary questionary = new Questionary();
        questionary.questions = new string[listViewContent.transform.childCount];
        int index = 0;
        foreach (Transform child in listViewContent.transform){
            questionary.questions[index] = child.GetComponent<PMFormController>().generateJSON();
            index++;
        }
    }

}
