﻿namespace RPGCharacters
{
    public enum Slot
    {
        SLOT_HEADER,
        SLOT_BODY,
        SLOT_LEGS,
        SLOT_WEAPON
    }
    abstract class Item
    {
        public string ItemName { get; set; }
        public int ItemLevel { get; set; }
        public Slot ItemSlot { get; set; }
    }
}
