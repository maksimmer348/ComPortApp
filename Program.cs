using System;
using System.Windows.Forms;

namespace ComPortSettings
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new MainFormController(new Form1());
            Application.Run(form.View);
        }
    }
}
