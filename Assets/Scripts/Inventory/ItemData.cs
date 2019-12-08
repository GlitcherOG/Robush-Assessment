using UnityEngine;

public static class ItemData
{
    public static Item CreateItem(int itemId)
    {
        string name = ""; //String for the name
        string description = ""; //String for the description
        int amount = 0; //int for the amount
        int value = 0; //int for the value
        int damage = 0; //int for the damage
        int armour = 0; //Int for the armour
        int heal = 0; //In for how much an item heals
        string iconName = ""; //String for the loctaion of an item icon
        string meshName = ""; //string for the loctaion of an item mesh
        ItemTypes type = ItemTypes.Misc;

        switch (itemId)
        {
            //Case number
            //set the String used for the name
            //Set the string used for the item discripton
            //Set the int for the ammount that can be held
            //Set the int for the value of the item
            //Set the int for the damage that the item can cause
            //Set the int for the amount of health it can restore
            //set the String used to contain the location of the icon
            //Set the string location used for the item
            //Set the type of item it is
            #region Armour 0-99
            case 0:
                name = "Rags";
                description = "Rags that can be used till you get some armour";
                amount = 1;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "armor/armor_19";
                meshName = "";
                type = ItemTypes.Armour;
                break;
            case 1:
                name = "Iron Plate";
                description = "Iron Plate Armour";
                amount = 1;
                value = 10;
                damage = 0;
                armour = 1;
                heal = 0;
                iconName = "Armour_2/heavy_armor/h_a_03/pg_arm_t_01";
                meshName = "";
                type = ItemTypes.Armour;
                break;
            case 2:
                name = "Steel Plate";
                description = "Steel Plate Amour";
                amount = 1;
                value = 10;
                damage = 0;
                armour = 1;
                heal = 0;
                iconName = "Armour_2/heavy_armor/h_a_02/pp_arm_t_01";
                meshName = "";
                type = ItemTypes.Armour;
                break;
            case 3:
                name = "Lether Armour";
                description = "Lether Armour";
                amount = 1;
                value = 10;
                damage = 0;
                armour = 1;
                heal = 0;
                iconName = "Armour_2/light_armor/l_a_01/mgg_arm_t_01";
                meshName = "";
                type = ItemTypes.Armour;
                break;
            #endregion
            #region Weapon 100-199
            case 100:
                name = "Sword";
                description = "Long Sword used to stab things";
                amount = 1;
                value = 10;
                damage = 5;
                armour = 0;
                heal = 0;
                iconName = "Weapons and Armour/swords/swords_t_01";
                meshName = "";
                type = ItemTypes.Weapon;
                break;
            case 101:
                name = "Bow";
                description = "Used to attack enemys at a long range";
                amount = 1;
                value = 10;
                damage = 3;
                armour = 0;
                heal = 0;
                iconName = "Weapons and Armour/bows_and_crossbows/bw_t_02";
                meshName = "";
                type = ItemTypes.Weapon;
                break;
            case 102:
                name = "Dagger";
                description = "Stabby Stabby";
                amount = 1;
                value = 10;
                damage = 3;
                armour = 0;
                heal = 0;
                iconName = "Weapons and Armour/knives/kn_t_02";
                meshName = "";
                type = ItemTypes.Weapon;
                break;
            #endregion
            #region Potion 200-299
            case 200:
                name = "Health Potion";
                description = "Used to Heal";
                amount = 1;
                value = 10;
                damage = 0;
                armour = 0;
                heal = 5;
                iconName = "Potions/10";
                meshName = "";
                type = ItemTypes.Potion;
                break;
            case 201:
                name = "Stanima Potion";
                description = "Used to replenish Stanima faster";
                amount = 1;
                value = 10;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Potions/1";
                meshName = "";
                type = ItemTypes.Potion;
                break;
            case 202:
                name = "Mana Potion";
                description = "Used to replenish mana";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Potions/5";
                meshName = "";
                type = ItemTypes.Potion;
                break;
            #endregion
            #region Food 300-399
            case 300:
                name = "Apple";
                description = "It's an apple";
                amount = 1;
                value = 1;
                damage = 0;
                armour = 0;
                heal = 2;
                iconName = "Food/Apple";
                meshName = "Food/Apple";
                type = ItemTypes.Food;
                break;
            case 301:
                name = "Meat";
                description = "It's some meat";
                amount = 1;
                value = 1;
                damage = 0;
                armour = 0;
                heal = 2;
                iconName = "Food/Meat";
                meshName = "Food/Meat";
                type = ItemTypes.Food;
                break;
            case 302:
                name = "Cabbages";
                description = "Green Water";
                amount = 1;
                value = 1;
                damage = 0;
                armour = 0;
                heal = 2;
                iconName = "Food/cabbage_01";
                meshName = "Food/cabbage_01";
                type = ItemTypes.Food;
                break;
            #endregion
            #region Ingredient 400-499
            case 400:
                name = "Red Flower";
                description = "It's a red flower";
                amount = 1;
                value = 10;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Ingredients/flowers/f_01";
                meshName = "Ingredients/flowers/f_01";
                type = ItemTypes.Ingredient;
                break;
            case 401:
                name = "White Flower";
                description = "It's a White Flower";
                amount = 1;
                value = 10;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Ingredients/flowers/f_02";
                meshName = "Ingredients/flowers/f_02";
                type = ItemTypes.Ingredient;
                break;
            case 402:
                name = "Blue Flower";
                description = "It's a Blue Flower";
                amount = 1;
                value = 10;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Ingredients/flowers/f_03";
                meshName = "Ingredients/flowers/f_03";
                type = ItemTypes.Ingredient;
                break;
            #endregion
            #region Craftable 500-599
            case 500:
                name = "Nails";
                description = "Used for holding stuff together";
                amount = 1;
                value = 10;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Misc/parts/Ni_t_04";
                meshName = "";
                type = ItemTypes.Craftable;
                break;
            case 501:
                name = "Ball of wool";
                description = "Its a ball of wool";
                amount = 1;
                value = 10;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Misc/parts/pt_t_07";
                meshName = "";
                type = ItemTypes.Craftable;
                break;
            case 502:
                name = "Part3";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "pt_t_03";
                meshName = "pt_t_03";
                type = ItemTypes.Craftable;
                break;
            #endregion
            #region Quest 600-699
            case 600:
                name = "Artifact1";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Icons/Magic/artifact_01_t";
                meshName = "Icons/Magic/artifact_01_t";
                type = ItemTypes.Quest;
                break;
            case 601:
                name = "Artifact2";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Icons/Magic/artifact_02_t";
                meshName = "Icons/Magic/artifact_02_t";
                type = ItemTypes.Quest;
                break;
            case 602:
                name = "Artifact3";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Icons/Magic/artifact_03_t";
                meshName = "Icons/Magic/artifact_03_t";
                type = ItemTypes.Quest;
                break;
            #endregion
            #region Misc 700-799
            case 700:
                name = "Gem1";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Misc/Gems/gm_t_01";
                meshName = "Misc/Gems/gm_t_01";
                type = ItemTypes.Misc;
                break;
            case 701:
                name = "Gem2";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Misc/Gems/gm_t_02";
                meshName = "Misc/Gems/gm_t_02";
                type = ItemTypes.Misc;
                break;
            case 702:
                name = "Gem3";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Misc/Gems/gm_t_03";
                meshName = "Misc/Gems/gm_t_03";
                type = ItemTypes.Misc;
                break;
            #endregion
            default:
                itemId = 0;
                name = "";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "";
                meshName = "";
                type = ItemTypes.Misc;
                break;
        }
        //Generate a new temp item
        Item temp = new Item
        {
            //Set the id to the item id
            ID = itemId,
            //Set the name to the name
            Name = name,
            //Set the description to the description
            Description = description,
            //Set the value to the value
            Value = value,
            //Set the amount to the amount
            Amount = amount,
            //Set the damage to the damage
            Damage = damage,
            //Set the armour to the armour
            Armour = armour,
            //Set the healh to the heal
            Heal = heal,
            //Set the icon to load the icon from resources
            IconName = Resources.Load("Icons/" + iconName) as Texture2D,
            //Set the mesh to load the gameobject from resources
            MeshName = Resources.Load("Prefabs/" + meshName) as GameObject,
            //Set the item type
            ItemType = type
        };
        //Return the temp item
        return temp;
    }
}
