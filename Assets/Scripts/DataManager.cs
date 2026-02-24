using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;
using TMPro;
using System.IO;

[System.Serializable]
class SaveData
{
    public string currentPlayerName;
    public string bestPlayerName;
    public int bestScore;
}

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string CurrentPlayerName;
    public string BestPlayerName;
    public int BestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadGame();
    }
    public void SaveGame()
    {
        SaveData data = new SaveData
        {
            currentPlayerName = CurrentPlayerName,
            bestPlayerName = BestPlayerName,
            bestScore = BestScore
        };

        string json = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + "/savefile.json";

        File.WriteAllText(path, json);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (!File.Exists(path))
            return;

        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        if (data != null)
        {
            CurrentPlayerName = data.currentPlayerName;
            BestPlayerName = data.bestPlayerName;
            BestScore = data.bestScore;
        }
    }
}
