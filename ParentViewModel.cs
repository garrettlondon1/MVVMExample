namespace MVVMExample
{
    public interface IParentViewModel : IViewModel
    {
        string SelectedSection { get; set; }
    }

    public class ParentViewModel : BaseViewModel, IParentViewModel
    {
        public ParentViewModel(IChildViewModel childViewModel)
        {
            ChildViewModel = childViewModel;
        }

        private string selectedSection = "Parent";

        public string SelectedSection
        {
            get => this.selectedSection;
            set
            {
                this.selectedSection = value;

                if (this.selectedSection != "Information")
                {
                    this.ChildViewModel.Initialize();
                }

                this.NotifyPropertyChanged();
            }
        }

        public IChildViewModel ChildViewModel { get; }
    }
}
