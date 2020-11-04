﻿using UnityEngine;

[System.Serializable]
public class PMQuestion {

    public const string CANNON_TYPE  = "cannon";
    public const string GRAVITY_TYPE = "gravity";
    public const string WALL_TYPE = "wall";
    public const string SIMULATION = "ParabolicMovement";
    public string type;
    public string statement;
    public float angle;
    public float velocity;
    public float maxDistance;
    public float maxHeight;
    public float midlePoint;
    public float gravity;
    public bool solved;

    public PMQuestion(string type, float angle, float velocity, float maxDistance, float maxHeight, float midlePoint, float gravity){
        this.type = type;
        this.angle = angle;
        this.velocity = velocity;
        this.maxDistance = maxDistance;
        this.maxHeight = maxHeight;
        this.midlePoint = midlePoint;
        this.gravity = gravity;
        if (type.CompareTo(CANNON_TYPE) == 0){
            statement = string.Format("Prepare el cañon para disparar un proyectil que pase por encima de la pared que mide {0}m y esta a {1}m, y ,"+
                                        "golpee el objetivo que se encuentra a {2}m", maxHeight, midlePoint, maxDistance);
        } else {
            statement = string.Format("El cañon esta dispuesto para disparar a una velociadad de {0} a un angulo de {1},"+
                                        "coloque el objetivo en la distancia maxima y la pared debajo de la altura maxima", velocity, angle);
        }
    }

    public PMQuestion(){
            angle = Random.Range(20.0f, 75.0f);
            velocity = Random.Range(15.0f, 27.0f);
//        if(Random.Range(0f, 1f) > 0.5f){
          if(true){
            type = CANNON_TYPE;
            maxDistance = 0.2038f * Mathf.Pow(velocity, 2) * Mathf.Sin((angle * Mathf.PI) / 180) * Mathf.Cos((angle * Mathf.PI) / 180);
            maxHeight = Mathf.Pow(velocity * Mathf.Sin((angle * Mathf.PI) / 180), 2) / 19.62f;
            midlePoint = maxDistance / 2f;
            gravity = -9.81f;
//            angle = -1f;
//            velocity = -1f;
            statement = string.Format("Prepare el cañon para disparar un proyectil que pase por encima de la pared que mide {0}m y esta a {1}m, y "+
                                        "golpee el objetivo que se encuentra a {2}m", maxHeight.ToString("F3"), midlePoint.ToString("F3"), maxDistance.ToString("F3"));
        } else {
            type = WALL_TYPE;
            maxDistance = -1f;
            maxHeight = -1f;
            midlePoint = -1f;
            gravity = -9.81f;
            statement = string.Format("El cañon esta dispuesto para disparar a una velociadad de {0} a un angulo de {1},"+
                                        "coloque el objetivo en la distancia maxima y la apertura de la pared a la altura maxima", velocity.ToString("F3"), angle.ToString("F3"));
        }
        solved = false;
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
