using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Save {
    
    public static void SavePlayerData(Player player)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string savePath = Application.persistentDataPath + "player.save";
        FileStream fileStream = new FileStream(savePath, FileMode.Create);

        PlayerData data = new PlayerData(player);
        binaryFormatter.Serialize(fileStream,data);
        Debug.Log(savePath);
        fileStream.Close();
    }

    public static PlayerData LoadPlayerSave()
    {
        string savePath = Application.persistentDataPath + "player.save";
        if (File.Exists(savePath))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(savePath, FileMode.Open);

            PlayerData data = binaryFormatter.Deserialize(fileStream) as PlayerData;
            fileStream.Close();

            return data;
        } else
        {
            Debug.LogError("Save file not found " + savePath);
            return null;
        }
    }


}
