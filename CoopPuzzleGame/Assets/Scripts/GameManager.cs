using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    private int level = 1;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
                
        DontDestroyOnLoad(gameObject);
    }

    public void Restart()
    {
        StartCoroutine(ChangeScene());
    }

    public void NextLevel()
    {
        level++;
        Debug.Log(level);
        if (level != 3)
        {
            StartCoroutine(ChangeScene());
        }
        else
        {
            SceneManager.LoadScene("Levels");
        }
    }

    public void LoadScene(int _level)
    {
        level = _level;
        StartCoroutine(ChangeScene());
    }

    private IEnumerator ChangeScene()
    {
        yield return new WaitForEndOfFrame();
        SceneManager.LoadScene("Level" + level);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
