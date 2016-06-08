using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTests
{
    public class LogAnalyzer
    {
        public bool WasLastFileNameValid { get; set; }   
        public bool IsValidLogFileName(string fileName)
        {
            WasLastFileNameValid = false;
            if (fileName.EndsWith(".SLF", StringComparison.InvariantCultureIgnoreCase))
            {
                WasLastFileNameValid = true;
                return true;
            }
            if (String.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("file name cannot be empty string");
            }
            return false;
        }
    }
}
