using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace Multi_Threaded_RW
{
    static class Program
    {
        /// <summary>
        /// Constructs a "file" that is shared by a reader thread and a writer thread.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            File f = new File();
            FileController c = new FileController(f);  // controls access to File f

            // start two threads, one for the reader and one for the writer:
            new Thread(ReaderThread).Start(c);
            new Thread(WriterThread).Start(c);
            // the main thread is still running:
            MessageBox.Show("System initiated.");
        }


        // you can pass an object to a new thread (but be sure to cast it when you use it):
        static void ReaderThread(Object ob)
        { Application.Run(new RForm((FileController)ob)); }

        static void WriterThread(Object ob)
        { Application.Run(new WForm((FileController)ob)); }

    }
}
