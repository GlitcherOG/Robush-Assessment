using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
public static class SettingsBinary
{
    public static void SaveSettingData(Settings settings)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Config.cfg";
        FileStream stream = new FileStream(path, FileMode.Create);
        SettingsData data = new SettingsData(settings);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static SettingsData LoadSettingsData()
    {
        string path = Application.persistentDataPath + "/Config.cfg";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SettingsData data = formatter.Deserialize(stream) as SettingsData;
            stream.Close();
            return data;
        }
        else
        {
            return null;
        }
    }
}