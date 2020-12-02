using System;
using System.Windows.Forms;

namespace ComPortSettings.MVC
{
    public interface IController
    {

    }
    public class Controller<TView>: IController where TView : View
    {
        
        public TView View { get; }
        protected IController Host { get; }
        protected Controller(TView view)
        {
            View = view;
            View.Shown += View_Shown;
            View.Load += View_Load;
            View.FormClosed += View_Closed;
        }

        protected Controller(TView view, IController host): this(view)
        {
            Host = host;
        }

        private void View_Closed(object sender, FormClosedEventArgs e)
        {
            View.Shown -= View_Shown;
            View.Load -= View_Load;
            View.FormClosed -= View_Closed;

            OnClosed();
        }

        private void View_Shown(object sender, EventArgs e)
        {
            OnShown();
        }

        private void View_Load(object sender, EventArgs e)
        {
            OnLoad();
        }

        protected virtual void OnShown()
        {

        }

        protected virtual void OnLoad()
        {
        }

        protected virtual void OnClosed()
        {
        }

        public void Show()
        {
            View.Show();
        }

        public void ShowDialog()
        {
            View.ShowDialog();
        }
    }


}