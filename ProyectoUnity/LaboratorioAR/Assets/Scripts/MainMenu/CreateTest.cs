using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CreateTest : MonoBehaviour {

    public GameObject pmFormPrefab;
    public Transform listViewContent;
    private string questionaryJson;

    public void newPMQuestion(){
        GameObject form = (GameObject) Instantiate (pmFormPrefab);
        form.transform.SetParent(listViewContent, false);
    }

    public void create(){
        Questionary questionary = new Questionary();
        questionary.questions = new PMQuestion[listViewContent.transform.childCount];
        int index = 0;
        foreach (Transform child in listViewContent.transform){
            questionary.questions[index] = child.GetComponent<PMFormController>().generateQuestion();
            index++;
        }
        string json = JsonUtility.ToJson(questionary);
        Debug.Log(json);
        StartCoroutine(SendQuestionary(json));
    }

    IEnumerator SendQuestionary(string json){
        UnityWebRequest req = UnityWebRequest.Put("http://localhost:3000/put", json);
        req.SetRequestHeader("Content-Type", "application/json");
        yield return req.SendWebRequest();
        if(req.isNetworkError || req.isHttpError) {
            Debug.Log(req.error);
        } else {
            Debug.Log("Cuetionario enviado");
            Debug.Log(req.downloadHandler.text);
        }
    }

}
