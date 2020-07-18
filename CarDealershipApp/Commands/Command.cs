using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipCommands
{
    public abstract class Command
    {
        public abstract string CommandText();
        public abstract CommandResult Execute();
    }
}