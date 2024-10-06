using System.IO;
using UnityEngine;

public class FileDataHandler
{
    private string dataDirPath = "";
    private string dataFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public void Save(GameData gameData)
    {
        string FullPath = Path.Combine(dataDirPath, dataFileName);

        Directory.CreateDirectory(Path.GetDirectoryName(FullPath));

        string DataToStore = JsonUtility.ToJson(gameData, true);

        using (FileStream stream = new FileStream(FullPath, FileMode.Create))
        {
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.Write(DataToStore);
            }
        }
    }

    public T Load<T>() where T : GameData
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);

        T loadedData = null;

        if (File.Exists(fullPath))
        {
            string dataToLoad = "";

            using (FileStream stream = new FileStream(fullPath, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    dataToLoad = reader.ReadToEnd();
                }
            }

            loadedData = JsonUtility.FromJson<T>(dataToLoad);
        }

        return loadedData;
    }

    public void Delete()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);

        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }
    }
}
