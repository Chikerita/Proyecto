using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PMFormController : MonoBehaviour {
    
    public Dropdown type;
    public InputField angle;
    public InputField velocity;
    public InputField targetDistance;
    public InputField wallHeight;
    public InputField wallDistance;

    public string generateJSON(){
        string type = this.type.options[this.type.value].text;
        float angle = float.Parse(this.angle.text);
        float velocity = float.Parse(this.velocity.text);
        float targetDistance = float.Parse(this.targetDistance.text);
        float wallHeight = float.Parse(this.wallHeight.text);
        float wallDistance = float.Parse(this.wallDistance.text);
        PMQuestion question = new PMQuestion(type, angle, velocity, targetDistance, wallHeight, wallDistance, 9.8f);
        string temp = JsonUtility.ToJson(question);
        Debug.Log(temp);
        return temp;
    }

    public void delete(){
        GameObject.Destroy(gameObject);
    }
}
