using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLouder: MonoBehaviour
{
    public GameObject scenePanel;
    public void LoadSceneByName (string nextScene)
    {
        SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);
        Destroy(scenePanel);
        Destroy(this);
    }
}
