public class Engine
{
    private int power;
    private int speed;

    public Engine(int speed, int power)
    {
        this.power = power;
        this.speed = speed;
    }

    public int Power
    {
        get { return this.power; }
        set { this.power = value; }
    }

    public int Speed
    {
        get { return this.speed; }
        set { this.speed = value; }
    }
}