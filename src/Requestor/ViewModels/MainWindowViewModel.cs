using System;
using System.Collections;
using System.Collections.Generic;
using System.Reactive;
using System.Windows.Input;
using ReactiveUI;

namespace Requestor.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private string _method = "GET";
    private string _url = string.Empty;

    public MainWindowViewModel()
    {
        var isUrlValid = this.WhenAnyValue(
            x => x.Url,
            x => !string.IsNullOrWhiteSpace(x) && Uri.TryCreate(x, UriKind.Absolute, out _)
        );
        SendCommand = ReactiveCommand.Create(() => { }, isUrlValid);
    }

    public string SelectedMethod 
    {
        get => _method;
        set => this.RaiseAndSetIfChanged(ref _method, value);
    }

    public string Url 
    {
        get => _url;
        set => this.RaiseAndSetIfChanged(ref _url, value);
    }

    public ReactiveCommand<Unit, Unit> SendCommand { get; init; }
}
