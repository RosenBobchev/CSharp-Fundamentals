﻿using System;
using System.Collections.Generic;
using System.Text;

public class Mood
{
    private string mood;
    private int happiness;

    public string MoodType
    {
        get
        {
            SetMood();
            return this.mood;
        }
    }

    public int Happiness
    {
        get
        {
            return this.happiness;
        }
    }

    public Mood()
    {
        this.happiness = 0;
        this.mood = string.Empty;
    }

    public void AddHappiness(string food)
    {
        HappinessFromFood happinessFromFood = new HappinessFromFood();
        bool hasParsed = Enum.TryParse<HappinessFromFood>(food.ToLower(), out happinessFromFood);

        if (!hasParsed)
        {
            happinessFromFood = HappinessFromFood.EverythingElse;
        }

        this.happiness += (int)happinessFromFood;
    }

    private void SetMood()
    {
        if (this.happiness < 5)
        {
            this.mood = "Angry";
        }

        if (this.happiness >= -5 && this.happiness <= 0)
        {
            this.mood = "Sad";
        }

        if (this.happiness >= 1 && this.happiness <= 15)
        {
            this.mood = "Happy";
        }

        if (this.happiness > 15)
        {
            this.mood = "JavaScript";
        }
    }
}

