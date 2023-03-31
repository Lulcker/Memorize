using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Memorize.Model;
using Memorize.Services;

namespace Memorize.ViewModel;

public partial class LearningLevel1ViewModel : ObservableObject
{
    public ObservableCollection<CollectionCard> Collection { get; set; } = new ObservableCollection<CollectionCard>();

    private int index = 0;
    public CollectionView cv = new CollectionView();
    

    private readonly ICollectionCardService collectionCardService;

    public LearningLevel1ViewModel(ICollectionCardService collectionCardService)
    {
        this.collectionCardService = collectionCardService;
    }
    
    [RelayCommand]
    public async void SelectCollection()
    {
        Collection.Clear();
        var collectioncards = await collectionCardService.GetCollectionCardList();

        if (collectioncards?.Count > 0)
        {
            collectioncards = collectioncards.OrderBy(f => f.InitalSide).ToList();
            foreach (var card in collectioncards)
            {
                Collection.Add(card);
            }
        }
    }
    
    [RelayCommand]
    private void ScrollRight()
    {
        if (index < Collection.Count)
        {
            index++;
            cv.ScrollTo(index, animate: false);
        }
    }

    
}