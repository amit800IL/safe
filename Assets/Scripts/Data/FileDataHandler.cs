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

    public GameData Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);

        GameData loadedData = null;

        if (File.Exists(fullPath))
        {
            string dataToLoad = "";

            using (FileStream stream = new FileStream(fullPath, FileMode.OpenOrCreate))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    dataToLoad = reader.ReadToEnd();
                }
            }

            loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
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
