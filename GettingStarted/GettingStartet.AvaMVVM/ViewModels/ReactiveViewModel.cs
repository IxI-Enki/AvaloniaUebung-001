  
namespace GettingStartet.AvaMVVM.ViewModels;

// Instead of implementing "INotifyPropertyChanged" on our own we use "ReactiveObject" as
// our base class. Read more about it here: https://www.reactiveui.net
public class ReactiveViewModel : ReactiveObject
{
  public ReactiveViewModel()
  {
    // We can listen to any property changes with "WhenAnyValue" and do whatever we want in "Subscribe".
    this.WhenAnyValue(o => o.Name)
        .Subscribe(o => this.RaisePropertyChanged(nameof(Greeting)));
  }

  private string? _Name; // This is our backing field for Name

  public string? Name
  {
    get
    {
      return _Name;
    }
    set
    {
      // We can use "RaiseAndSetIfChanged" to check if the value changed and automatically notify the UI
      this.RaiseAndSetIfChanged(ref _Name , value);
    }
  }
  // Greeting will change based on a Name.
  public string Greeting
  {
    get => string.IsNullOrEmpty(Name) ? "Name your Caravan" : $"Is  {Name}  the correct Name?";
  }

  public Button? AcceptButton { get; set; }
  public object? CamelPicture { get; set; }
}
