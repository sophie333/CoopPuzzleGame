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
        SceneManager.LoadScene("Level" + level);
    }

    public void NextLevel()
    {
        level++;
        Debug.Log(level);
        if (level < 4)
        {
            SceneManager.LoadScene("Level" + level);
        }
        else
        {
            SceneManager.LoadScene("Levels");
        }
    }

    public void LoadScene(int _level)
    {
        level = _level;
        SceneManager.LoadScene("Level" + level);
    }

    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(0.001f);
        SceneManager.LoadScene("Level" + level);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
