using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionaryHandler : MonoBehaviour {
    
    public GameObject loadMenu;
    public static Questionary questionary;
    public static bool inQuestionary = false;
    public static int questionIndex;

    public void startQuestionary(){
        inQuestionary = true;
        questionIndex = 0;
        StartCoroutine(loadAsynchronously(questionary.questions[questionIndex].SIMULATION));
    }

    public void questionSolved(){
        if(questionIndex < questionary.questions.Length){
            questionIndex++;
            if(questionary.questions[questionIndex].SIMULATION.CompareTo(SceneManager.GetActiveScene().name) == 0){
                TestManager temp = GameObject.Find("TestManager").GetComponent<TestManager>();
                temp.presentQuestion(questionary.questions[questionIndex]);
            } else {
                StartCoroutine(loadAsynchronously(questionary.questions[questionIndex].SIMULATION));
            }
        }
    }

    IEnumerator loadAsynchronously (string sceneName){
        string actualScene = SceneManager.GetActiveScene().name;
        AsyncOperation operation =  SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        loadMenu.SetActive(true);
        while (!operation.isDone){
            yield return null;
        }
        StartCoroutine(unloadAsynchronously(actualScene));
    }

    IEnumerator unloadAsynchronously (string sceneName){
        AsyncOperation operation =  SceneManager.UnloadSceneAsync(sceneName);
        while (!operation.isDone){
            yield return null;
        }
        loadMenu.SetActive(false);
    }
}
