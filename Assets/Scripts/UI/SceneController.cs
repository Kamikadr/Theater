using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    
    public GameObject panel;
    public GameObject sceneManager; // нужен для запуска следующей сцены
    private void Awake()
    {
        //Если спектакль идет нужно запустить последнюю сцену
    }
    public void OpenScenePanel()
    {
        panel.SetActive(true);
    }


}
