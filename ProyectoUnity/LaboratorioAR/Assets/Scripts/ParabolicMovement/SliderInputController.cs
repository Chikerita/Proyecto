using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderInputController : MonoBehaviour {

    public Slider slider;
    public InputField input;
    public Text text;
    public string variableName;
    public string units;

    void Start() {
        changeInputValue(slider.value);
        updateText();
        if (variableName.CompareTo("vacio") == 0){
            gameObject.SetActive(false);
        }
    }

    public void changeSliderValue(string value){
        slider.value = float.Parse(input.text);
        updateText();
    }

    public void changeInputValue(float value){
        input.text = value.ToString("F3");
        updateText();
    }

    public void updateText(){
        if (variableName.CompareTo("vacio") == 0) {
            text.text = "";
        } else {
            text.text = variableName + ": " + slider.value.ToString("F3") + units;
        }
    }
}
