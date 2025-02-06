using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Multi_Threaded_RW
{
    // interface for Files that can be written:
    public interface Writer { void writeLine(string s); }
}
