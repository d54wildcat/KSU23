using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Multi_Threaded_RW
{
    // form that shows buttons for opening, writing, and closing a file:
    public partial class WForm : Form
    {
        private FileController c;  // we'll connect directly to the controller this time.
        private Writer file;       // handle to the file we will be writing
        private Status state = Status.Closed;  // STATE VARIABLE: remembers if form 
        // is in process of writing file

        public WForm(FileController c)
        {
            this.c = c;
            InitializeComponent();
        }

        // signals to open file and also to write lines into it
        private void button1_Click(object sender, EventArgs e)
        {
            if (state == Status.Closed)
            {  // want to open the file?
                file = c.openWrite();
                if (file != null)
                {
                    state = Status.Writing;
                    button1.Text = "Write";
                    textBox1.Text = "";
                    button2.Enabled = true;  // enable buttons to write and close file
                }
                else { textBox1.Text = "Open Error; try again"; }
            }
            else if (state == Status.Writing)
            {  // write another line to it:
                file.writeLine(textBox1.Text);
                textBox1.Text = "";
            }
        }

        // signals to close file
        private void button2_Click(object sender, EventArgs e)
        {
            if (state == Status.Writing)
            {
                c.close();
                state = Status.Closed;
                button1.Text = "Open";
                textBox1.Text = "";
                button2.Enabled = false;
            }
        }

        private void WForm_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }
    }
}
