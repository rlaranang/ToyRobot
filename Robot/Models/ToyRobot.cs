using Robot.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Models
{
    public sealed class ToyRobot
    {
        public bool IsPlaced { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Directions Direction { get;  set; }
    }
}
