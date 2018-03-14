using System;

public class UltrasoftTyre : Tyre
{
    private const string ULTRASOFTNAME = "Ultrasoft";
    private double grip;
    private double degradation;

    public UltrasoftTyre(double hardness, double grip) 
        : base(hardness)
    {
        this.Grip = grip;
    }
    
    public double Grip
    {
        get { return this.grip; }
        protected set { this.grip = value; }
    }

    public override double Degradation
    {
        get => this.degradation;
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException("Blown Tyre");
            }
            this.degradation = value;
        }
    }

    public override string Name => ULTRASOFTNAME;

    public override void ReduceDegradation()
    {
        var sum = this.Hardness + this.Grip;
        this.Degradation -= sum;
    }
}

