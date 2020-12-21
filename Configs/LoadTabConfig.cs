using ComPortSettings.MVC;

namespace ComPortSettings
{
    public class LoadTabConfig : Controller<Form1>
    {
        protected LoadTabConfig(Form1 view) : base(view)
        {
        }

        protected LoadTabConfig(Form1 view, IController host) : base(view, host)
        {
        }


    }
}