using NSubstitute;
using NUnit.Framework;

public class inventory 
{
    [Test]
    public void only_allows_one_chest_item_to_be_equipped_at_a_time()
    {
        //Arrange
        ICharacter character = Substitute.For<ICharacter>();
        Inventory inventory = new Inventory(character); 
        Item chestItemOne = new Item { EquipSlot = EquipSlots.Chest };
        Item chestItemTwo = new Item { EquipSlot = EquipSlots.Chest };

        //Act
        inventory.EquipItem(chestItemOne);
        inventory.EquipItem(chestItemTwo);

        //Assert
        Item equippedItem = inventory.GetItem(EquipSlots.Chest);
        Assert.AreEqual(chestItemTwo, equippedItem);
    }

    [Test]
    public void tells_character_when_item_was_equipped_successfully()
    {
        //Arrange
        ICharacter character = Substitute.For<ICharacter>();
        Inventory inventory = new Inventory(character); 
        Item chestItem = new Item { EquipSlot = EquipSlots.Chest };

        //Act
        inventory.EquipItem(chestItem);

        //Assert
        character.Received().OnItemEquipped(chestItem);
    }
}
