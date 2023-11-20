using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace MVVMExample;

public partial class BaseViewModelView<TViewModel> : IAsyncDisposable
    where TViewModel : IViewModel
{
    [Inject]
    public TViewModel ViewModel { get; set; }

    public async virtual ValueTask DisposeAsync()
    {
        ViewModel.PropertyChanged -= this.OnViewModelPropertyChanged;
        ViewModel.Dispose();
    }

    protected override void OnInitialized()
    {
        ViewModel.PropertyChanged += this.OnViewModelPropertyChanged;
    }

    protected virtual void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        InvokeAsync(StateHasChanged);
    }
}
