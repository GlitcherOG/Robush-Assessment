using UnityEngine;

public static class ItemData
{
    public static Item CreateItem(int itemId)
    {
        string name = "";
        string description = "";
        int amount = 0;
        int value = 0;
        int damage = 0;
        int armour = 0;
        int heal = 0;
        string iconName = "";
        string meshName = "";
        ItemTypes type = ItemTypes.Misc;

        switch(itemId)
        {
            #region Armour 0-99
            case 0:
                name = "Rags";
                description = "";
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
               description = "ITS SOME ARMOR BOI";
               amount = 10;
               value = 10;
               damage = 0;
               armour = 1;
               heal = 0;
               iconName = "";
               meshName = "";
               type = ItemTypes.Armour;
            break;
            case 2:
                name = "Iron Plate";
                description = "ITS SOME ARMOR BOI";
                amount = 10;
                value = 10;
                damage = 0;
                armour = 1;
                heal = 0;
                iconName = "";
                meshName = "";
                type = ItemTypes.Armour;
                break;
            case 3:
                name = "Steel Plate";
                description = "ITS SOME ARMOR BOI";
                amount = 10;
                value = 10;
                damage = 0;
                armour = 1;
                heal = 0;
                iconName = "";
                meshName = "";
                type = ItemTypes.Armour;
                break;
            #endregion
            #region Weapon 100-199
            case 100:
                name = "Sword";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "";
                meshName = "";
                type = ItemTypes.Weapon;
                break;
            case 101:
                name = "Bow";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "";
                meshName = "";
                type = ItemTypes.Weapon;
                break;
            case 102:
                name = "Dagger";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "";
                meshName = "";
                type = ItemTypes.Weapon;
                break;
            #endregion
            #region Potion 200-299
            case 200:
                name = "Potion1";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "";
                meshName = "";
                type = ItemTypes.Potion;
                break;
            case 201:
                name = "Potion2";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "";
                meshName = "";
                type = ItemTypes.Potion;
                break;
            case 202:
                name = "Potion3";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "";
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
                name = "flower1";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Ingredients/flowers/f_01";
                meshName = "Ingredients/flowers/f_01";
                type = ItemTypes.Ingredient;
                break;
            case 401:
                name = "flower2";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Ingredients/flowers/f_02";
                meshName = "Ingredients/flowers/f_02";
                type = ItemTypes.Ingredient;
                break;
            case 402:
                name = "flower3";
                description = "";
                amount = 0;
                value = 0;
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
                name = "Part1";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "pt_t_01";
                meshName = "pt_t_01";
                type = ItemTypes.Craftable;
                break;
            case 501:
                name = "Part2";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "pt_t_02";
                meshName = "pt_t_02";
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
        Item temp = new Item
        {
            ID = itemId,
            Name = name,
            Description = description,
            Value = value,
            Amount = amount,
            Damage = damage,
            Armour = armour,
            Heal = heal,
            IconName = Resources.Load("Icons/" + iconName) as Texture2D,
            MeshName = Resources.Load("Prefabs/" + meshName) as GameObject,
            ItemType = type
        };
        return temp;
    }
}
