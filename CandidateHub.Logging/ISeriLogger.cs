using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateHub.Logging
{
    public interface ISeriLogger
    {
        void Information(string message);
        void Warning(string message);
        void Debug(string message);
        void Error(string message, Exception ex);
    }
}
