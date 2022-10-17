using NSubstitute;
using NUnit.Framework;

public class character_with_inventory 
{
    [Test]
    public void with_90_armor_takes_10_percent_damage()
    {
        //Arrange
        ICharacter character = Substitute.For<ICharacter>();
        Inventory inventory = new Inventory(character);
        Item pants = new Item() { EquipSlot = EquipSlots.Legs, Armor = 30 };
        Item shield = new Item() { EquipSlot = EquipSlots.LeftHand, Armor = 60 };
        DamageCalculator calculator = new DamageCalculator();

        inventory.EquipItem(pants);
        inventory.EquipItem(shield);
        character.Inventory.Returns(inventory);

        //Act
        int damage = calculator.CalculateDamage(100, character);

        //Assert (Check state)
        Assert.AreEqual(10, damage);
    }
}
