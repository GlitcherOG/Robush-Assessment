using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
public static class PlayerBinary 
{
   public static void SavePlayerData(PlayerHandler player)
    {
        //Reference a Binary Formatter
        BinaryFormatter formatter = new BinaryFormatter();
        //Location to Save
        string path = Application.persistentDataPath + "/" + PlayerData.saveSlot;
        //Create File at file path
        FileStream stream = new FileStream(path, FileMode.Create);
        //What Data to write to the file
        PlayerData data = new PlayerData(player);
        //write it and convert to bytes for writing to binary
        formatter.Serialize(stream, data);
        //and we are done
        stream.Close();
    }
    public static PlayerData LoadData()
    {
        //Location to Save
        string path = Application.persistentDataPath + "/" + PlayerData.saveSlot;
        //if we have the file at that path
        if (File.Exists(path))
        {
            //get our binary formatter
            BinaryFormatter formatter = new BinaryFormatter();
            //and read the data from the path
            FileStream stream = new FileStream(path,FileMode.Open);
            //set the data from what it is back to usable variables
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            //we are done
            stream.Close();
            //send usable data back to the PlayerDataToSave Script
            return data;
        }
        else
        {
            return null;
        }
    }
}
