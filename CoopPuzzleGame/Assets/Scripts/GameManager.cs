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
        if (level != 3)
        {
            SceneManager.LoadScene("Level" + level);
        }
        else
        {
            SceneManager.LoadScene("Levels");
        }
    }
}
