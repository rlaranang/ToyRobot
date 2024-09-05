using Robot.Enums;
using Robot.Exceptions;
using Robot.Helpers;
using Robot.Interfaces;
using Robot.Models;
using Robot.Validators;

namespace Robot.CommandHandlers
{
    public class CommandHandler : BaseHandler, ICommandHandler
    {
        private readonly ToyRobot _toyRobot;

        public CommandHandler(ToyRobot toyRobot)
        {
            _toyRobot = toyRobot;
        }

        public void Handle(string command)
        {
            var comm = command.Split(' ');
            var actualCommand = command.Split()[0];
            if (_toyRobot.IsPlaced || actualCommand == Constants.PLACE)
            {
                switch (actualCommand)
                {
                    case Constants.PLACE:
                        Place(comm);
                        _toyRobot.IsPlaced = true;
                        break;
                    case Constants.MOVE:
                        Move();
                        break;
                    case Constants.LEFT:
                        TurnLeft();
                        break;
                    case Constants.RIGHT:
                        TurnRight();
                        break;
                    case Constants.REPORT:
                        Report();
                        break;
                    default:
                        throw new CommandInvalidException("Input command is invalid. Please try a valid command.");
                }
            }
        }

        #region PrivateMethods
        private void Place(string[] command)
        {
            PlacementValidator placementValidator = new PlacementValidator();
            DirectionValidator directionValidator = new DirectionValidator();

            var placeParameters = command[1].Split(',');
            var newX = Convert.ToInt32(placeParameters[0]);
            var newY = Convert.ToInt32(placeParameters[1]);
            var newDirection = _toyRobot.Direction;

            if (!_toyRobot.IsPlaced && placeParameters.Length < 3)
            {
                throw new PlacementInvalidException("Direction is required on the first placement.");
            }
            else if (_toyRobot.IsPlaced  && placeParameters.Length == 3)
            {
                newDirection = (Directions)Enum.Parse(typeof(Directions), placeParameters[2]);
            }

            if (placementValidator.IsValid(newX) 
                && placementValidator.IsValid(newY)
                && directionValidator.IsValid(newDirection))
            {
                _toyRobot.X = newX;
                _toyRobot.Y = newY;
                _toyRobot.Direction = newDirection;
            }
            else
            {
                throw new PlacementInvalidException("Invalid placement.");
            }            
        }

        private void Move()
        {
            int val = 0;

            switch (_toyRobot.Direction)
            {
                case Directions.NORTH:
                    val = _toyRobot.Y;
                    Move(ref val, 1);

                    //new location is already valid at this part
                    _toyRobot.Y = val;
                    break;
                case Directions.EAST:
                    val = _toyRobot.X;
                    Move(ref val, 1);

                    //new location is already valid at this part
                    _toyRobot.X = val;
                    break;
                case Directions.SOUTH:
                    val = _toyRobot.Y;
                    Move(ref val, -1);

                    //new location is already valid at this part
                    _toyRobot.Y = val;
                    break;
                case Directions.WEST:
                    val = _toyRobot.X;
                    Move(ref val, -1);

                    //new location is already valid at this part
                    _toyRobot.X = val;
                    break;
            }
        }

        private void TurnLeft()
        {
            --_toyRobot.Direction;

            DirectionValidator directionValidator = new DirectionValidator();
            if (!directionValidator.IsValid(Convert.ToInt32(_toyRobot.Direction)))
            {
                _toyRobot.Direction = Directions.WEST;
            }
        }

        private void TurnRight()
        {
            ++_toyRobot.Direction;

            DirectionValidator directionValidator = new DirectionValidator();
            if (!directionValidator.IsValid(Convert.ToInt32(_toyRobot.Direction)))
            {
                _toyRobot.Direction = Directions.NORTH;
            }
        }

        private void Report()
        {
            Console.WriteLine($"X: {_toyRobot.X}  Y: {_toyRobot.Y}  Direction: {_toyRobot.Direction}");
        }

        private void Move(ref int param, int val = 0)
        {
            PlacementValidator placementValidator = new PlacementValidator();
            if (placementValidator.IsValid(param + val))
            {
                param = param + val;
            }
            else
            {
                throw new PlacementInvalidException("Cannot move.");
            }
        }
        #endregion PrivateMethods
    }
}
