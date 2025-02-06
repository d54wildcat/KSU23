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
    // form that shows buttons for opening, reading, and closing a file.
    public partial class RForm : Form
    {
        private FileController c;  // we'll let the form talk directly to the controller.
        private Reader file;       // handle to the file we'll be reading
        private Status state;  // STATE VARIABLE --- remembers if the form 
        // is in act of reading the file

        public RForm(FileController c)
        {
            this.c = c;
            state = Status.Closed;
            InitializeComponent();
        }

        private void RForm_Load(object sender, EventArgs e)
        {
            button1.Text = "Open";
            button2.Text = "Close";
            button2.Enabled = false;
        }

        // handles button-press events to open file and also to read lines from it
        private void button1_Click(object sender, EventArgs e)
        {
            if (state == Status.Closed)
            {  // we want to open the file?
                file = c.openRead();
                if (file != null)
                { // success at opening?
                    state = Status.Reading;
                    button1.Text = "Read";
                    label1.Text = "";
                    button2.Enabled = true;   // buttons set to read lines and close file
                }
                else { label1.Text = "Open error. Try later"; }
            }
            else if (state == Status.Reading)
            {  // read a new line:
                string line = file.readLine();
                if (line != null)
                { // new line read ok ?
                    label1.Text = label1.Text + "\n" + line;
                }
                else { label1.Text = label1.Text + "\n" + "EOF or error"; }
            }
        }

        // signals to close file
        private void button2_Click(object sender, EventArgs e)
        {
            if (state == Status.Reading)
            {
                c.close();
                state = Status.Closed;
                button1.Text = "Open";
                button2.Enabled = false;
            }
        }
    }
}
