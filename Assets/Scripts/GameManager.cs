using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score;
    public string playerName = "HumanEngine";
    public SaveData currentHighscore = new SaveData();

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [System.Serializable]
    public  class SaveData
    {
        public string PlayerName;
        public int HighScore;
    }
    public void SaveGame()
        {
            if (score > currentHighscore.HighScore) {
                SaveData data = new SaveData();
                data.PlayerName = playerName;
                data.HighScore = score;

                string json = JsonUtility.ToJson(data);
            
                File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
            }
        }

    public void LoadGame()
        {
            string path = Application.persistentDataPath + "/savefile.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                SaveData data = JsonUtility.FromJson<SaveData>(json);

                currentHighscore = data;
                playerName = data.PlayerName;
            }
        }
}
