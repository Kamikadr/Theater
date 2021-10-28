using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PositioningSystemController : MonoBehaviour
{
    public GameObject sceneButtonPref;
    public RectTransform content;
    public Canvas sceneSettingsScreen;

    void Start()
    {
        
    }
    public void createScreen() 
    {
        List<string> scenes = Placement.GetScenes();
        for (int i = 0; i < scenes.Count; i++) 
        {
            GameObject obj = Instantiate(sceneButtonPref.gameObject);
            obj.transform.SetParent(content, false);
            SceneButton item = new SceneButton(obj.transform);
            item.name.text = scenes[i];
            item.button.onClick.AddListener(delegate {
                PlayerPrefs.SetString("SceneName", scenes[i]);
                SceneManager.LoadScene(scenes[i] + "Placement");
                turnOffSceneSettings();
            });
        }
        
    }
    public void turnOffSceneSettings()
    {
        sceneSettingsScreen.enabled = false;
    }
    public void turnOnSceneSettings()
    {
        sceneSettingsScreen.enabled = true;
    }
    class SceneButton 
    {
        public Button button;
        public Text name;
        public SceneButton(Transform view) 
        {
            button = view.Find("Button").GetComponent<Button>();
            name = button.transform.Find("Text").GetComponent<Text>();
        }
    }

}
