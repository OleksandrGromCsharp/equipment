namespace equipment.Services.DialogService.Interface
{
    interface IDialogService
    {
        bool Interaction(ref object Variable, object[] Parameters = null);

        void ShowInformation(string Message, string Caption);

        void ShowWarning(string Message, string Caption);

        void ShowError(string Message, string Caption);

        bool Confirm(string Message, string Caption, bool Exclamation = false);
    }
}
