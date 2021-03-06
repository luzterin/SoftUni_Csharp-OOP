﻿using System.Text;

namespace Cars
{
    public class Tesla : Car, IElectricCar, ICar
    {
        public Tesla(string model, string color, int battery)
        :base (model, color)
        {
            this.Battery = battery;
        }
        public int Battery { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} {nameof(Tesla)} {this.Model} with {this.Battery} Batteries");
            sb.AppendLine(this.Start);
            sb.AppendLine(this.Stop);
            return sb.ToString().TrimEnd();
        }
    }
}
