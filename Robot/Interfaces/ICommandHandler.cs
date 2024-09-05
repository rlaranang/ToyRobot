using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Interfaces
{
    public interface ICommandHandler
    {
        void Handle(string command);
    }
}
