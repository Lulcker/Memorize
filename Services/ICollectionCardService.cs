using Memorize.Model;

namespace Memorize.Services;

public interface ICollectionCardService
{
    Task<List<CollectionCard>> GetCollectionCardList();

    Task<int> AddCollectionCard(CollectionCard collectionCard);
    
    Task<int> DeleteCollectionCard(CollectionCard collectionCard);
    
    Task<int> UpdateCollectionCard(CollectionCard collectionCard);
}