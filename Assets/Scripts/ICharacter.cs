
public interface ICharacter
{
    public void OnItemEquipped(Item item);

    public Inventory Inventory { get; }
    public int Health { get; }
    public int Level { get; }
}
