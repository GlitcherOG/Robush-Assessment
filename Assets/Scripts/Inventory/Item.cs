using UnityEngine;

public class Item
{
    #region Variales
    //Id of the item
    private int _id;
    //String for the name of the item
    private string _name;
    //String for the description
    private string _description;
    //Int for the amount of items of that can be heal
    private int _amount;
    //Int for the buy and sell values
    private int _value;
    //Int for the damage the item can cause
    private int _damage;
    //Int for the armour defence 
    private int _armour;
    //Int for the ammount the item can heal
    private int _heal;
    //Texture2D icon for the item
    private Texture2D _iconName;
    //GameObject for the items mesh
    private GameObject _meshName;
    //Type of item
    private ItemTypes _type;
    #endregion
    #region Properties
    public int ID //Int of the item ID
    {
        get { return _id; }
        set { _id = value; }
    }
    public string Name //String containing the name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string Description //String containing the descripton
    {
        get { return _description; }
        set { _description = value; }
    }
    public int Amount //Int containing the amount  
    {
        get { return _amount; }
        set { _amount = value; }
    }
    public int Value //Int containing the value of the item
    {
        get { return _value; }
        set { _value = value; }
    }
    public int Damage //Int containing the damage the item can do
    {
        get { return _damage; }
        set { _damage = value; }
    }
    public int Armour //Int containing the armour defence amount
    {
        get { return _armour; }
        set { _armour = value; }
    }
    public int Heal //Int containing how much the item heals 
    {
        get { return _heal; }
        set { _heal = value; }
    }
    public Texture2D IconName //Texture2D for the item icon
    {
        get { return _iconName; }
        set { _iconName = value; }
    }
    public GameObject MeshName //GameObject for the item
    {
        get { return _meshName; }
        set { _meshName = value; }
    }
    public ItemTypes ItemType //
    {
        get { return _type; }
        set { _type = value; }
    }
    #endregion
}

public enum ItemTypes //Enum containing the ItemTypes
{
    Armour,
    Weapon,
    Potion,
    Money,
    Quest,
    Food,
    Ingredient,
    Craftable,
    Misc
}

