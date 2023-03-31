using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Memorize.Model;

public class CollectionCard
{
    [AutoIncrement, PrimaryKey]
    public int Id { get; set; }
    public string InitalSide { get; set; }
    public string ReverseSide { get; set; }

}