using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class QuestionaryMenu : MonoBehaviour {

    public GameObject buttonPrefab;
    public Transform listviewContent;

    void OnEnable(){
        StartCoroutine(GetText());
    }
 
    IEnumerator GetText() {
        UnityWebRequest req = UnityWebRequest.Get("http://localhost:3000/getp");
        req.SetRequestHeader("Content-Type", "application/json");
        yield return req.SendWebRequest();
        if(req.isNetworkError || req.isHttpError) {
            Debug.Log(req.error);
        } else {
            Debug.Log(req.downloadHandler.text);
            Questionary [] arr = JsonHelper.FromJson<Questionary>("{\"Items\":" + req.downloadHandler.text + "}");
            foreach (Questionary item in arr){
                GameObject button = (GameObject) Instantiate (buttonPrefab);
			    button.GetComponentInChildren<Text>().text = item.questionaryName;
			    button.GetComponent<Button>().onClick.AddListener(() => {
                    Debug.Log(button.GetComponentInChildren<Text>().text);
                });
			    button.transform.SetParent(listviewContent, false);
            }
        }
    }

}

