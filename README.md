# Monday

A minimal C# MVVM framework.
Yes, created on a monday.

## Base

### ViewModelBase-Class

A base class for view-models.
You can create properties with the `OnPropertyChanged` event.

Implementation:

```CSharp

public class <Classname>ViewModel : ViewModelBase
{
    private string propertyName;
    public string PropertyName
    {
        get => propertyName;
        set
        {
            if (propertyName == value)
                return;

            propertyName = value;
            OnPropertyChanged();
        }
    }
}

```

## Command

### ActionCommand-Class

Implementation:

```CSharp

public class <Classname>ViewModel : ViewModelBase 
{
	public ICommand Command { get; set; }
	public ICommand GetCommand => Command = new ActionCommand(() => GetAction());
	private void GetAction() { }
}

```

## Extension

### CollectionExtension-Class

```CSharp

ObservableCollection<T>().AddRange();
ObservableCollection<T>().AddRangeCleared();

```

### LiveShapingExtension-Class

```CSharp

EnableLiveSorting(this ICollectionView collectionView)

```

## Helper

### MouseDoubleClickHelper-Class

Helper to enable mouse double click on WPF-UI.

## Messenger

```CSharp

// Subscribe with name of event ("MessageEvent").
PublishSubscribe<object>.Subscribe("MessageEvent", OnPropertyChanged);

// Method to be fired.
private void OnPropertyChanged(object sender, PublishSubscribeEventArgs<object> args) { }

// Raised event with message content.
var args = new PublishSubscribeEventArgs<object>("message content");
PublishSubscribe<object>.RaiseEvent("MessageEvent", this, args);

```
