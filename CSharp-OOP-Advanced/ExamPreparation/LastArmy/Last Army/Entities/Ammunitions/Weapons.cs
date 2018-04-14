using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Weapons : Ammunition
{
    private int caliber;
    private double shootDistance;
    private int bullets;

    protected Weapons(string name, double weight)
        : base(name, weight)
    {
    }

    protected Weapons(string name, double weight, int number, int caliber, double shootDistance, int bullets)
        : base(name, weight)
    {
        this.caliber = caliber;
        this.shootDistance = shootDistance;
        this.Bullets = bullets;
    }

    public int Caliber
    {
        get { return caliber; }
        set { caliber = value; }
    }

    public double ShootDistance
    {
        get { return shootDistance; }
        set { shootDistance = value; }
    }

    public int Bullets
    {
        get { return bullets; }
        set { bullets = value; }
    }
}