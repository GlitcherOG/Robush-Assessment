using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
public static class PlayerBinary 
{
   public static void SavePlayerData(PlayerHandler player)
    {
        //New Binary Formatter
        BinaryFormatter formatter = new BinaryFormatter();
        //New string path for the application saving location
        string path = Application.persistentDataPath + "/" + PlayerData.saveSlot + ".sav";
        //New file stream using path
        FileStream stream = new FileStream(path, FileMode.Create);
        //New PlayerData called data
        PlayerData data = new PlayerData(player);
        //Serialize the stream
        formatter.Serialize(stream, data);
        //Close the stream
        stream.Close();
    }
    public static PlayerData LoadData()
    {
        //New string path for the application loading location
        string path = Application.persistentDataPath + "/" + PlayerData.saveSlot + ".sav";
        //If the path exists
        if (File.Exists(path))
        {
            //New Binary Formatter
            BinaryFormatter formatter = new BinaryFormatter();
            //New file stream using path
            FileStream stream = new FileStream(path, FileMode.Open);
            //Deserialize the stream into data
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            //Close the stream
            stream.Close();
            //Return data
            return data;
        }
        else
        {
            return null;
        }
    }
}
