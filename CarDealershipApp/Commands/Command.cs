using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipApp.Commands
{
    public abstract class Command
    {
        public abstract string CommandText();
        public abstract CommandResult Execute();
    }
}
