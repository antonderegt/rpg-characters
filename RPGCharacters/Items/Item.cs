namespace RPGCharacters.Items
{
    /// <summary>
    /// Lists all available slots where items can be equipped.
    /// </summary>
    public enum Slot
    {
        SLOT_HEADER,
        SLOT_BODY,
        SLOT_LEGS,
        SLOT_WEAPON
    }

    /// <summary>
    /// Defines the base of an item.
    /// </summary>
    public abstract class Item
    {
        public string ItemName { get; set; }
        public int ItemLevel { get; set; }
        public Slot ItemSlot { get; set; }

        public abstract string ItemDescription();
    }
}
