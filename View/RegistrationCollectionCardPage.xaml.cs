using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memorize.ViewModel;

namespace Memorize.View;

public partial class RegistrationCollectionCardPage : ContentPage
{
    public RegistrationCollectionCardPage(RegistrationCollectionCardViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}