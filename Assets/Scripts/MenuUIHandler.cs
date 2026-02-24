using TMPro;
using Unity.VectorGraphics;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI  bestScoreText;
    public TMP_InputField   inputField;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bestScoreText.text = $"Best Score: {DataManager.Instance.BestPlayerName} : {DataManager.Instance.BestScore}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        DataManager.Instance.CurrentPlayerName = inputField.text;
        DataManager.Instance.SaveGame();
        SceneManager.LoadScene(1);
    }

//    public void QuitButton()
//    {
//        DataManager.Instance.SaveName();
//#if UNITY_EDITOR
//        EditorApplication.ExitPlaymode();
//#else
//        Application.Quit();
//#endif
//    }
}
