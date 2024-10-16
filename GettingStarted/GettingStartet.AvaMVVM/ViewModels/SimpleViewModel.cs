
namespace GettingStartet.AvaMVVM.ViewModels;

public class SimpleViewModel : INotifyPropertyChanged
{
  public string? Name
  {
    get => _Name;
    set
    {
      if (_Name != value)
      {
        _Name = value;
        RaisePropertyChanged();
        RaisePropertyChanged(nameof(Greeting));
      }
    }
  }

  public string Greeting
  {
    get => string.IsNullOrEmpty(Name) ? "Name your PackAnimal" : $"Is  {Name}  the correct Name?";
  }
  public Button? AcceptButton { get; set; } 
  public object? CamelPicture { get; set; }

  public event PropertyChangedEventHandler? PropertyChanged;

  private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
    => PropertyChanged?.Invoke(this , new PropertyChangedEventArgs(propertyName));

  private string? _Name;
}
