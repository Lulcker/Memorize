using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Memorize.Model;
using Memorize.Services;
using Memorize.View;


namespace Memorize.ViewModel;

public partial class CollectionCardPageViewModel : ObservableObject
{
    public static List<CollectionCard> CollectionCardForSearch { get; private set; } = new List<CollectionCard>();
    public ObservableCollection<CollectionCard> CollectionCards { get; set; } = new ObservableCollection<CollectionCard>();

    private readonly ICollectionCardService collectionCardService;

    public CollectionCardPageViewModel(ICollectionCardService collectionCardService)
    {
        this.collectionCardService = collectionCardService;
    }
    

    [RelayCommand]
    public async void GetCollectionCardList()
    {
        CollectionCards.Clear();
        var collectioncards = await collectionCardService.GetCollectionCardList();

        if (collectioncards?.Count > 0)
        {
            collectioncards = collectioncards.OrderBy(f => f.InitalSide).ToList();
            foreach (var card in collectioncards)
            {
                CollectionCards.Add(card);
            }
            CollectionCardForSearch.Clear();
            CollectionCardForSearch.AddRange(collectioncards);
        }
    }
    
    [RelayCommand]
    public async void AddUpdateCollectionCard()
    {
        await AppShell.Current.GoToAsync(nameof(RegistrationCollectionCardPage));
    }


    [RelayCommand]
    public async void RouteToLevel1()
    {
        await AppShell.Current.GoToAsync(nameof(LearningLevel1));
    }


    [RelayCommand]
    public async void DeleteCard(CollectionCard collectionCard)
    {
        var delResponse = await collectionCardService.DeleteCollectionCard(collectionCard);
        if (delResponse > 0)
        {
            GetCollectionCardList();
        }
    }
    
    
    [RelayCommand]
    public async void EditCard(CollectionCard collectionCard)
    {
        var navParam = new Dictionary<string, object>();
        navParam.Add("RegistrationCollectionCard", collectionCard);
        await AppShell.Current.GoToAsync(nameof(RegistrationCollectionCardPage), navParam);
    }
}