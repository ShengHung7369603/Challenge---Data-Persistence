using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class NameText : MonoBehaviour
{
    public static NameText Instance;
    public string currentPlayerName;


    public string bestPlayer;
    public int bestScore;

    public Text BestPlayerText;
    

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadBestScore();
        BestPlayerText.text = $"{bestPlayer}";
    }




    //這個一定要先有
    [System.Serializable]

    //先做一個class宣告要儲存的資訊
    class SaveData
    {
        public string BestPlayer;
        public int BestScore;
    }

    //再做一個method執行儲存
    public void SaveBestScore()
    {
        Debug.Log(GameObject.Find("MainManager").GetComponent<MainManager>().m_Points);
        //指派要儲存的內容
        SaveData data = new SaveData();
        data.BestPlayer = currentPlayerName;
        data.BestScore = GameObject.Find("MainManager").GetComponent<MainManager>().m_Points;

        //儲存
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayer = data.BestPlayer;
            bestScore = data.BestScore;
        }
    }
}
