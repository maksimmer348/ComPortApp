using ComPortSettings.MVC;

namespace ComPortSettings
{
    public class MainFormController : Controller<Form1>
    {
        
        public MainFormController(Form1 view) : base(view)
        {
            View.OpenSettings += OpenSettings;
        }

        protected override void OnClosed()
        {
            View.OpenSettings -= OpenSettings;
        }

        private void OpenSettings()
        {
            var comSettingsController = new ComSettingsController(new ComSettings());
            comSettingsController.Show();
        }

        protected override void OnShown()
        {
            
        }
    }
}