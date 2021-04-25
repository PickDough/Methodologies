using System.Windows;

namespace WpfApp1.View
{
    public partial class FrameParametersDialog : Window, IDialogWindow
    {
        public FrameParametersDialog()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.CanMinimize;
        }
    }
}