using System.Collections.Generic;
using System.Linq;

public class Inventory 
{
    private Dictionary<EquipSlots, Item> _equippedItems = new Dictionary<EquipSlots, Item>();
    private List<Item> _unequippedItems = new List<Item>();
    private readonly ICharacter _character;

    public Inventory(ICharacter character)
    {
        _character = character;
    }

    public void EquipItem(Item item)
    {
        if(_equippedItems.ContainsKey(item.EquipSlot))
        {
            _unequippedItems.Add(_equippedItems[item.EquipSlot]);
        }

        _equippedItems[item.EquipSlot] = item;
        _character.OnItemEquipped(item);
    }

    public Item GetItem(EquipSlots slot)
    {
        if(_equippedItems.ContainsKey(slot))
        {
            return _equippedItems[slot];
        }

        return null;
    }

    public int GetArmor()
    {
        int totalArmor = _equippedItems.Values.Sum(item => item.Armor);
        return totalArmor;
    }
}
