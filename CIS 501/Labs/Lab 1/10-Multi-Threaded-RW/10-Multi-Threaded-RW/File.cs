using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Multi_Threaded_RW
{

    // models a simple text file that can be read or written one line at a time.
    // It implements both interfaces Reader and Writer, depending on how it's used.
    public class File : Reader, Writer
    {

        private List<string> lines;  // the "file" is a list of strings
        private int count;   // counts the lines read while reading/writing the file

        public File() { lines = new List<string>(); }

        // initializes the file for reading its lines one by one:
        public void initRead() { count = 0; }

        // initializes the file for writing fresh lines to it.  Erases existing contents.
        public void initWrite() { lines = new List<string>(); count = 0; }

        // reads and returns the next line of the file (or returns null if no more lines):
        public string readLine()
        {
            string line = null;
            if (count < lines.Count)
            {
                line = lines[count]; count++;
            }
            return line;
        }

        // writes a new line to the end of the file:
        public void writeLine(string s)
        {
            lines.Add(s); count++;
        }
    }
}
