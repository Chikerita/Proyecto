using UnityEngine;
using UnityEngine.UI;

public class PMFormController : MonoBehaviour {
    
    public Dropdown type;
    public InputField angle;
    public InputField velocity;
    public InputField targetDistance;
    public InputField wallHeight;
    public InputField wallDistance;
    public Toggle randomToggle;

    public PMQuestion generateQuestion(){
        string type = this.type.options[this.type.value].text;
        float angle = float.Parse(this.angle.text);
        float velocity = float.Parse(this.velocity.text);
        float targetDistance = float.Parse(this.targetDistance.text);
        float wallHeight = float.Parse(this.wallHeight.text);
        float wallDistance = float.Parse(this.wallDistance.text);
        return new PMQuestion(type, angle, velocity, targetDistance, wallHeight, wallDistance, 9.8f);
    }

    public void hiddeOptions(int value){
        if(value == 0){
            GameObject [] arr = GameObject.FindGameObjectsWithTag("CannonOptions");
            foreach (GameObject item in arr) item.GetComponent<InputField>().interactable = false;
            arr = GameObject.FindGameObjectsWithTag("WallOptions");
            foreach (GameObject item in arr) item.GetComponent<InputField>().interactable = !randomToggle.isOn;
        } else if (value == 1){
            GameObject [] arr = GameObject.FindGameObjectsWithTag("WallOptions");
            foreach (GameObject item in arr) item.GetComponent<InputField>().interactable = false;
            arr = GameObject.FindGameObjectsWithTag("CannonOptions");
            foreach (GameObject item in arr) item.GetComponent<InputField>().interactable = !randomToggle.isOn;
        }
    }

    public void hiddeOptions(){
        hiddeOptions(type.value);
    }

    public void delete(){
        GameObject.Destroy(gameObject);
    }
}
