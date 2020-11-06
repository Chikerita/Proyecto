
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
            statement = string.Format("Prepare el cañon para disparar un proyectil que pase por encima de la pared que mide {0}m y esta a {1}m, y ,"+
                                        "golpee el objetivo que se encuentra a {2}m", maxHeight, midlePoint, maxDistance);
        } else {
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
