using Microsoft.AspNetCore.Components.Forms;

namespace MVVMExample
{
    public interface IChildViewModel : IViewModel
    {
        void Initialize();
        int RandomNumber { get; set; }
        bool IsLoading { get; }
    }

    public class ChildViewModel : BaseViewModel, IChildViewModel
    {
        private bool isLoading = true;
        public int RandomNumber { get; set; } = 0;

        public bool IsLoading
        {
            get
            {
                return this.isLoading;
            }
            private set
            {
                this.isLoading = value;
                this.NotifyPropertyChanged();
            }
        }

        public async void Initialize()
        {
            try
            {
                this.IsLoading = true;
                //await Task.Delay(10);
                RandomNumber = new Random().Next();
            }
            finally
            {
                this.IsLoading = false;
            }
        }
    }
}
