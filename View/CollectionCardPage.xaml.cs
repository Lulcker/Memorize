using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memorize.ViewModel;

namespace Memorize.View;

public partial class CollectionCardPage : ContentPage
{
    private CollectionCardPageViewModel _viewModel;
    
    public CollectionCardPage(CollectionCardPageViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        this.BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetCollectionCardListCommand.Execute(null);
    }
    
}