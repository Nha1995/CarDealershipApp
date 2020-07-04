using System;
using System.Collections.Generic;
using System.Text;

namespace MyCarDealership
{
    public abstract class Command
    {
        public abstract string CommandText();
        public abstract CommandResult Execute();
    }
}