using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipCommands
{
    public class CommandResult
    {
        public bool Success;
        public string Message;

        public CommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}