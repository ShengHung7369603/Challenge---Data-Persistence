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




    //�o�Ӥ@�w�n����
    [System.Serializable]

    //�����@��class�ŧi�n�x�s����T
    class SaveData
    {
        public string BestPlayer;
        public int BestScore;
    }

    //�A���@��method�����x�s
    public void SaveBestScore()
    {
        Debug.Log(GameObject.Find("MainManager").GetComponent<MainManager>().m_Points);
        //�����n�x�s�����e
        SaveData data = new SaveData();
        data.BestPlayer = currentPlayerName;
        data.BestScore = GameObject.Find("MainManager").GetComponent<MainManager>().m_Points;

        //�x�s
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
