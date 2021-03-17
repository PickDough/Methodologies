﻿using WpfApp1.View;

namespace WpfApplication1.ViewModel.Abstract
{
    public abstract class DialogViewModelBase<T>: BaseViewModel 
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public T DialogResult { get; set; }

        public DialogViewModelBase(): this(string.Empty, string.Empty) {}
        public DialogViewModelBase(string title) : this(title, string.Empty) {}
        public DialogViewModelBase(string title, string message)
        {
            Title = title;
            Message = message;
        }

        public void CloseDialogWithResult(IDialogWindow dialog, T result)
        {
            DialogResult = result;

            if (dialog != null)
                dialog.DialogResult = true;
        }
    }
}