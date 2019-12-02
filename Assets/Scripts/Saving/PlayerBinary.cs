using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
public static class PlayerBinary 
{
   public static void SavePlayerData(PlayerHandler player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + PlayerData.saveSlot + ".sav";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static PlayerData LoadData()
    {
        string path = Application.persistentDataPath + "/" + PlayerData.saveSlot + ".sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            return null;
        }
    }
}
