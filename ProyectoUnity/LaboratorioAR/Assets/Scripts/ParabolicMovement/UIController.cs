using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour{

    public InputField angleInput;
    public Slider angleSlider;
    public InputField velInput;
    public Slider velSlider;
    public Text statsLabel;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void updateAngleInput(float value){
        angleInput.text = value.ToString();
    }

    public void updateAngleSlider(string text){
        angleSlider.value = float.Parse(text);
    }

    public void updateVelocityInput(float value){
        velInput.text = value.ToString();
    }

    public void updateVelocitySlider(string text){
        velSlider.value = float.Parse(text);
    }

    public void updateStats(float yPosition, float xPosition){
        statsLabel.text = string.Format("Ymax: {0}m\nXmax: {1}m\nFlight time: {2}s", yPosition.ToString("F3"), xPosition.ToString("F3"), "0");
    }

    public void resetStats(){
        statsLabel.text = "Ymax: 0m\nXmax: 0m\nFlight time: 0s";
    }

}
