using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVMExample;

public abstract class BaseViewModel : IViewModel
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public virtual void Dispose()
    {
    }
}
