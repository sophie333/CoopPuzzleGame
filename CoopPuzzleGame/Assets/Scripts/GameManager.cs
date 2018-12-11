using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    private int level = 0;
    
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
        SceneManager.LoadScene("Level" + level);
    }
}
