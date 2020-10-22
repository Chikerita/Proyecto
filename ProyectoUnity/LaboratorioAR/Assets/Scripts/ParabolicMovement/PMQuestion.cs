using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMQuestion {

    public const string CANNON_TYPE  = "cannon";
    public const string GRAVITY_TYPE = "gravity";
    public const string WALL_TYPE = "wall";
    private string type;
    private string statement;
    private float angle;
    private float velocity;
    private float maxDistance;
    private float maxHeight;
    private float midlePoint;
    private float gravity;

    public PMQuestion(){
        if(Random.Range(0f, 1f) > 0.5f){
            type = CANNON_TYPE;
            angle = -1f;
            velocity = -1f;
            maxDistance = -1f; //Definir estos tres
            maxHeight = -1f;
            midlePoint = -1f;
            gravity = 9.81f;
            statement = string.Format("Prepare el cañon para disparar un proyectil que pase por encima de la pared que mide {0}m y esta a {1}m, y ,"+
                                        "golpee el objetivo que se encuentra a {2}m", maxHeight, midlePoint, maxDistance);
        } else {
            type = WALL_TYPE;
            angle = Random.Range(10.0f, 90.0f);
            velocity = Random.Range(0.0f, 100.0f);
            maxDistance = -1f;
            maxHeight = -1f;
            midlePoint = -1f;
            gravity = 9.81f;
            statement = string.Format("El cañon esta dispuesto para disparar a una velociadad de {0} a un angulo de {1},"+
                                        "coloque el objetivo en la distancia maxima y la pared debajo de la altura maxima", velocity, angle);
        }
    }

    public string Type { get => type; set => type = value; }
    public string Statement { get => statement; set => statement = value; }
    public float Angle { get => angle; set => angle = value; }
    public float Velocity { get => velocity; set => velocity = value; }
    public float MaxDistance { get => maxDistance; set => maxDistance = value; }
    public float MaxHeight { get => maxHeight; set => maxHeight = value; }
    public float MidlePoint { get => midlePoint; set => midlePoint = value; }
    public float Gravity { get => gravity; set => gravity = value; }
}
