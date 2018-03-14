using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Tyre
{
    private double hardness;
    private double degradation;

    protected Tyre(double hardness)
    {
        this.Hardness = hardness;
        this.Degradation = 100;
    }

    public abstract string Name { get;}

    public double Hardness
    {
        get { return this.hardness; }
        set { this.hardness = value; }
    }

    public virtual double Degradation
    {
        get
        {
            return this.degradation;
        }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Blown Tyre");
            }
            this.degradation = value;
        }
    }

    public virtual void ReduceDegradation()
    {
        this.Degradation -= this.Hardness;
    }
}

