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
            
            var controller = new MainFormController(new MainForm());
            Application.Run(controller.View);
        }
    }
}
