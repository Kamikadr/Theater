using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingsController : MonoBehaviour
{
    public MainMenuController menuController;
    public Canvas settingsScreen;

    public GameObject settingsPrefab;
    public GameObject backButtonPrefab;
    public RectTransform content;

    private List<SettingsForm> formList;
    private int index;

    public void createSettingsScreen(int index)
    {    
        this.index = index;
        formList = new List<SettingsForm>();
        List<SettingsModel> itemList = getSettingsModels();
        createFormSettings(itemList);
        createBackButton();
    }

    private void createBackButton() 
    {
        GameObject obj = Instantiate(backButtonPrefab.gameObject);
        obj.transform.SetParent(content, false);
        obj.transform.GetComponent<Button>().onClick.AddListener(delegate {
            saveSettings();
            menuController.turnOnMainMenu();
            turnOffSettings();
        });
    }

    //не используется
    /*private void createDelaySettings() 
    {
        GameObject obj = Instantiate(settingsPrefab.gameObject);
        obj.transform.SetParent(content, false);
        SettingsForm view = new SettingsForm(obj.transform);
        view.actName.text = "Задержка перед началом";
        view.inputText.text = Schedule.getDelayScene(index).ToString();
        delaySetting = Schedule.getDelayScene(index);
        view.inputText.onValueChanged.AddListener(delegate { delaySetting = int.Parse(view.inputText.text); });
    }*/

    private List<SettingsModel> getSettingsModels() 
    {
        var modelList = new List<SettingsModel>();
        var nameList = Schedule.getSceneActName(index);
        var timingsList = Schedule.getSceneTiming(index);

        for (int i = 0; i < nameList.Count; i++)
        {
            modelList.Add(new SettingsModel());
            modelList[i].actName = nameList[i];
            modelList[i].offset = timingsList[i];
        }
        return modelList;
    }

    private void createFormSettings(List<SettingsModel> items) 
    {
        foreach (Transform child in content) Destroy(child.gameObject);
        formList.Clear();

        foreach (SettingsModel item in items) 
        {
            GameObject obj = Instantiate(settingsPrefab.gameObject);
            obj.transform.SetParent(content, false);
            itemInitialization(item, obj);
        }
    }
    private void itemInitialization(SettingsModel item, GameObject obj)
    {
        SettingsForm view = new SettingsForm(obj.transform);
        view.actName.text = item.actName;
        view.inputText.text = item.offset.ToString();
        formList.Add(view);
    }
    public void saveSettings() 
    {
        List<int> newTimings = new List<int>();
        foreach (SettingsForm item in formList) {
            int offset;
            int.TryParse(item.inputText.text, out offset);
            newTimings.Add(offset);
        }
        Schedule.setSceneTiming(index, newTimings);
        Schedule.saveChanges();
    }

    public void turnOffSettings() {
        settingsScreen.enabled = false;
    }
    public void turnOnSettings() {
        settingsScreen.enabled = true;
    }



    public class SettingsModel 
    {
        public string actName;
        public int offset;
    }
    public class SettingsForm
    {
        public Text actName;
        public InputField inputText;
        public SettingsForm(Transform view) 
        {
            actName = view.Find("ActName").GetComponent<Text>();
            inputText = view.Find("InputField").GetComponent<InputField>();
        }
    }
}
