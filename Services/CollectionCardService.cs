using Memorize.Model;
using SQLite;

namespace Memorize.Services;

public class CollectionCardService : ICollectionCardService
{
    public SQLiteAsyncConnection dbConnection;

    private async Task SetupDatabaseCollection()
    {
        if (dbConnection == null)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CollectionCard.db3");
            dbConnection = new SQLiteAsyncConnection(dbPath);
            await dbConnection.CreateTableAsync<CollectionCard>();
        }
    }

    public async Task<List<CollectionCard>> GetCollectionCardList()
    {
        await SetupDatabaseCollection();
        var collectioncardlist = await dbConnection.Table<CollectionCard>().ToListAsync();
        return collectioncardlist;
    }

    public async Task<int> AddCollectionCard(CollectionCard collectionCard)
    {
        await SetupDatabaseCollection();
        return await dbConnection.InsertAsync(collectionCard);
    }

    public async Task<int> DeleteCollectionCard(CollectionCard collectionCard)
    {
        await SetupDatabaseCollection();
        return await dbConnection.DeleteAsync(collectionCard);
    }
    
    public async Task<int> UpdateCollectionCard(CollectionCard collectionCard)
    {
        await SetupDatabaseCollection();
        return await dbConnection.UpdateAsync(collectionCard);
    }

}