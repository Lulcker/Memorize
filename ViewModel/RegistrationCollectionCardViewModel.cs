using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Memorize.Model;
using Memorize.Services;


namespace Memorize.ViewModel;

[QueryProperty(nameof(RegistrationCollectionCard), "RegistrationCollectionCard")]
public partial class RegistrationCollectionCardViewModel : ObservableObject
{
    [ObservableProperty] private CollectionCard _registrationCollectionCard = new CollectionCard();

    private readonly ICollectionCardService collectionCardService;

    public RegistrationCollectionCardViewModel(ICollectionCardService collectionCardService)
    {
        this.collectionCardService = collectionCardService;
    }
    
    
    [RelayCommand]
    public async void AddUpdateCollectionCard()
    {
        int response = -1;
        if (RegistrationCollectionCard.Id > 0)
        {
            response = await collectionCardService.UpdateCollectionCard(RegistrationCollectionCard);
        }
        else
        {
            response = await collectionCardService.AddCollectionCard(new CollectionCard
            {
                InitalSide = RegistrationCollectionCard.InitalSide.Trim(),
                ReverseSide = RegistrationCollectionCard.ReverseSide.Trim()
            });
        }
        await AppShell.Current.GoToAsync("..");
    }

}