using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELogLib.Interfaces
{
    public interface IMessage
    {
        void Print(string message, string callerName);
    }
}
