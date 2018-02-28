﻿using System;
using System.Collections.Generic;
using System.Text;

public class Robot : IIdentable
{
    public Robot(string model, string id)
    {
        this.Model = model;
        this.Id = id;
    }

    public string Model { get; set; }

    public string Id { get; set; }
}

