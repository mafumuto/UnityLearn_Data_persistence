using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    public TMP_InputField userNameText;
    public string userName = "Please Entry Name";
    public TMP_Text bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (DataPersistence.Instance != null)
        {
            DataPersistence.Instance.LoadDataToJson();
            GetBestScore();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        GetUserName();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }

    public void GetUserName()
    {

        userName = userNameText.text;
        DataPersistence.Instance._userName= userName;
           
    }

    public void GetBestScore()
    {
        if (DataPersistence.Instance.bestscore == 0)
        {
            userNameText.text = userName;
        }

        else
        {
            userNameText.text = DataPersistence.Instance.userName;
            bestScoreText.gameObject.SetActive(true);
            bestScoreText.text = $"Best Score : {DataPersistence.Instance.userName} : {DataPersistence.Instance.bestscore}";
        }
    }
}
