using Memorize.Model;

namespace Memorize.SearchHandlers;

public class CollectionCardSearchHandler : SearchHandler
{
    public IList<CollectionCard> CollectionCards { get; set; }
    public string NavigationRoute { get; set; }
    public Type NavigationType { get; set; }
    
    protected override void OnQueryChanged(string oldValue, string newValue)
    {
        base.OnQueryChanged(oldValue, newValue);

        if (string.IsNullOrWhiteSpace(newValue))
        {
            ItemsSource = null;
        }
        else
        {
            ItemsSource = CollectionCards.Where(student => student.InitalSide.ToLower().Contains(newValue.ToLower())).ToList();
        }
    }
    
    protected override async void OnItemSelected(object item)
    {
        base.OnItemSelected(item);
        var navParam = new Dictionary<string, object>();
        navParam.Add("CollectionCardDetail", item);
        if (!string.IsNullOrWhiteSpace(NavigationRoute))
        {
            await Shell.Current.GoToAsync(NavigationRoute, navParam);
        }
    }
}