using Memorize.ViewModel;
using Memorize.Model;

namespace Memorize.View;

public partial class LearningLevel1 : ContentPage
{
    private LearningLevel1ViewModel _viewModel;

    public LearningLevel1(LearningLevel1ViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        this.BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.SelectCollectionCommand.Execute(null);
    }

    private int index = 0;
    private void ScrollRight(object sender, EventArgs e)
    {
        if (index < _viewModel.Collection.Count)
        {
            index++;
            CView.ScrollTo(index, animate: false);
        }
    }

    private void ScrollLeft(object sender, EventArgs e)
    {
        if (index > 0)
        {
            index--;
            CView.ScrollTo(index, animate: false);
        }
    }
}