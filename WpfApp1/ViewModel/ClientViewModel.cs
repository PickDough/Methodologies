using System.Windows.Input;
using Domain;
using Model;
using WpfApp1.View;
using WpfApplication1.ViewModel.Abstract;
using WpfApplication1.ViewModel.Command;

namespace WpfApp1.ViewModel
{
    public class ClientViewModel: DialogViewModelBase<ClientModel>
    {
        public ClientModel Client { get; set; }

        public ClientViewModel(string title, string message) : base(title, message)
        {
            Client = new ClientModel();
        }
        
        public ICommand Ok => new RelayCommand(o =>
        {
            IDialogWindow window = o as IDialogWindow;
            CloseDialogWithResult(window, Client);
        }, _ => Client.Validate());
    }
}