﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model;

public class Gender
{
    public int Gender_id { get; set; }
    public string gender { get; set; }
    public Movie_Cast MovieCast { get; set; }
}