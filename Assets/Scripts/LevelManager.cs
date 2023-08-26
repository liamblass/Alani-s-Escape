using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;

    private int currentScene;

    void Awake()
    {
        if (levelManager != null)
        {
            Destroy(levelManager);
        }
        else
        {
            levelManager = this;
        }
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        currentScene = GetActiveScene();
    }

    private int GetActiveScene()
    {
        int scene;
        scene = SceneManager.GetActiveScene().buildIndex;
        return scene;
    }

    public void LoadNextScene()
    {
        int scene = currentScene;
        scene++;
        SceneManager.LoadScene(scene);
    }

    public void LoadLastScene()
    {
        int scene = currentScene;
        scene--;
        SceneManager.LoadScene(scene);
    }

    
}
