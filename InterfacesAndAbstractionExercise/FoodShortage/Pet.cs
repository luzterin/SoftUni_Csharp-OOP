﻿using System;
using System.Text.RegularExpressions;

namespace FoodShortage
{
    public class Pet : Identification 
    {
        private string birthday;

        public Pet(string name, DateTime birthday) : base(name, birthday)
        {
        }

        public string GetBirthDay()
        {
            return this.Birthday.Date.ToString("dd\\/MM\\/yyyy");
        }
    }
}