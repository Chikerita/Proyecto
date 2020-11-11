
[System.Serializable]
public class PMQuestion {

    public const string CANNON_TYPE  = "cannon";
    public const string GRAVITY_TYPE = "gravity";
    public const string WALL_TYPE = "wall";
    public string SIMULATION = "ParabolicMovement";
    public string statement;
    public string type;
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
            statement = string.Format("Prepare el cañon para disparar un proyectil que pase por el espacio de la pared que esta a {0}m de altura y a {1}m del cañon, y "+
                                        "golpee el objetivo que se encuentra a {2}m del cañon", maxHeight.ToString("F3"), midlePoint.ToString("F3"), maxDistance.ToString("F3"));
        } else {
            statement = string.Format("El cañon esta dispuesto para disparar a una velociadad de {0}m/s a un angulo de {1}°,"+
                                        "coloque el objetivo en la distancia maxima y el espacio de la pared en la altura maxima del disparo", velocity.ToString("F3"), angle.ToString("F3"));
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
