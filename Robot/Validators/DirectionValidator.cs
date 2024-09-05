using Robot.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Validators
{
    public sealed class DirectionValidator : BaseValidator
    {
        public override bool IsValid(int value)
        {
            return value >= 0 && value <= 3;
        }

        public bool IsValid(Directions direction)
        {
            return Enum.IsDefined(typeof(Directions), direction);
        }
    }
}
