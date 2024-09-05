using Robot.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Validators
{
    public sealed class PlacementValidator : BaseValidator
    {
        public override bool IsValid(int value)
        {
            return value >= Constants.MIN_X_Y && value <= Constants.MAX_X_Y;
        }
    }
}
