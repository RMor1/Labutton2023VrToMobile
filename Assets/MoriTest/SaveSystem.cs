using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    public static bool FileExist()
    {
        string path = Application.persistentDataPath + "/StoreData.info";
        return File.Exists(path);
    }
    public static void SaveStorePurchase(InGamePurchase inGamePurchase)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/StoreData.info";
        FileStream stream = new FileStream(path, FileMode.Create);

        InGamePurchaseData data = new InGamePurchaseData(inGamePurchase);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static InGamePurchaseData LoadData()
    {
        string path = Application.persistentDataPath + "/StoreData.info";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            InGamePurchaseData data = formatter.Deserialize(stream) as InGamePurchaseData;
            stream.Close();
            return data;

        }
        else
        {
            Debug.Log("Save file not found");
            return null;
        }
    }
}
