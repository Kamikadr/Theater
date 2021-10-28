using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public SettingsController settingsController;
    public Canvas mainMenuScreen;

    public GameObject mainPrefab;
    public RectTransform content;
    public InputField delayInputField;

    void Awake()
    {
        List<string> sceneNameList = Schedule.getScene();
        foreach (Transform child in content) Destroy(child.gameObject);

        for (int i = 0; i < sceneNameList.Count; i++) 
        {
            GameObject obj = Instantiate(mainPrefab.gameObject);
            obj.transform.SetParent(content, false);
            MenuItem item = new MenuItem(obj.transform);
            item.sceneName.text = sceneNameList[i];
            item.index = i;
            item.settingButton.onClick.AddListener(delegate {
                settingsController.createSettingsScreen(item.index);
                settingsController.turnOnSettings();
                turnOffMainMenu();
            });
        }

        delayInputField.onValueChanged.AddListener(delegate
        {
            int delay;
            if (int.TryParse(delayInputField.text, out delay)) Schedule.setDelay(delay);
            else if (delayInputField.text.Length > 0)
                delayInputField.text = delayInputField.text.Remove(delayInputField.text.Length - 1);
        });

    }
    public void turnOffMainMenu() 
    {
        mainMenuScreen.enabled = false;
    }
    public void turnOnMainMenu() 
    {
        mainMenuScreen.enabled = true;
    }
    
    public class MenuItem
    {
        public Text sceneName;
        public Button settingButton;
        public int index;

        public MenuItem(Transform view)
        {
            sceneName = view.Find("SceneName").GetComponent<Text>();
            settingButton = view.Find("SettinngsButton").GetComponent<Button>();
        }
    }
}
