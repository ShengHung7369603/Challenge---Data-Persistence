using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    
    public void GameStartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SetNameText()
    {
        InputField Input = GameObject.Find("Name Input").GetComponent<InputField>();
        NameText.Instance.currentPlayerName = Input.text;

        Debug.Log(NameText.Instance.currentPlayerName);
    }

}
