using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public delegate void TutorialDone(int tutorialIndex);
    public event TutorialDone TutorialDoneNotify;

    public GameObject TutorialPanel;
    public GameObject[] WellcomeMessages;
    public GameObject[] RageMessages;
    public GameObject[] SpecialMessages;
    public GameObject[] AchieveMessages;
    public GameObject[] GameOverMessages;

    private void Update()
    {
        if (isShowings[0])
        {
            ShowMessages(0);
        }
        if (isShowings[1])
        {
            ShowMessages(1);
        }
        if (isShowings[2])
        {
            ShowMessages(2);
        }
        if (isShowings[3])
        {
            ShowMessages(3);
        }
        if (isShowings[4])
        {
            ShowMessages(4);
        }
    }

    public void SetModel()
    {
        WellcomeMessages[0].transform.Find("Text").GetComponent<TextMeshProUGUI>().text = LocalizationManager.GetStringByKey("WellcomeMessage1_1");
        WellcomeMessages[0].transform.Find("Text (1)").GetComponent<TextMeshProUGUI>().text = LocalizationManager.GetStringByKey("WellcomeMessage1_2");
        WellcomeMessages[1].transform.Find("Text (1)").GetComponent<TextMeshProUGUI>().text = LocalizationManager.GetStringByKey("WellcomeMessage2");
        WellcomeMessages[2].transform.Find("Text (1)").GetComponent<TextMeshProUGUI>().text = LocalizationManager.GetStringByKey("WellcomeMessage3");
        WellcomeMessages[3].transform.Find("Text (1)").GetComponent<TextMeshProUGUI>().text = LocalizationManager.GetStringByKey("WellcomeMessage4");
        WellcomeMessages[4].transform.Find("Text (1)").GetComponent<TextMeshProUGUI>().text = LocalizationManager.GetStringByKey("WellcomeMessage5");
        WellcomeMessages[5].transform.Find("Text (1)").GetComponent<TextMeshProUGUI>().text = LocalizationManager.GetStringByKey("WellcomeMessage6");

        RageMessages[0].transform.Find("Text (1)").GetComponent<TextMeshProUGUI>().text = LocalizationManager.GetStringByKey("RageMessage1");
        RageMessages[1].transform.Find("Text (1)").GetComponent<TextMeshProUGUI>().text = LocalizationManager.GetStringByKey("RageMessage2");
        RageMessages[2].transform.Find("Text (1)").GetComponent<TextMeshProUGUI>().text = LocalizationManager.GetStringByKey("RageMessage3");

        SpecialMessages[0].transform.Find("Text (1)").GetComponent<TextMeshProUGUI>().text = LocalizationManager.GetStringByKey("SpecialMessage1");
        SpecialMessages[1].transform.Find("Text (1)").GetComponent<TextMeshProUGUI>().text = LocalizationManager.GetStringByKey("SpecialMessage2");
        SpecialMessages[2].transform.Find("Text (1)").GetComponent<TextMeshProUGUI>().text = LocalizationManager.GetStringByKey("SpecialMessage3");
        SpecialMessages[3].transform.Find("Text (1)").GetComponent<TextMeshProUGUI>().text = LocalizationManager.GetStringByKey("SpecialMessage4");
        SpecialMessages[4].transform.Find("Text (1)").GetComponent<TextMeshProUGUI>().text = LocalizationManager.GetStringByKey("SpecialMessage5");

        AchieveMessages[0].transform.Find("Text (1)").GetComponent<TextMeshProUGUI>().text = LocalizationManager.GetStringByKey("AchieveMessage1");
        AchieveMessages[1].transform.Find("Text (1)").GetComponent<TextMeshProUGUI>().text = LocalizationManager.GetStringByKey("AchieveMessage2");
        AchieveMessages[2].transform.Find("Text (1)").GetComponent<TextMeshProUGUI>().text = LocalizationManager.GetStringByKey("AchieveMessage3");

        GameOverMessages[0].transform.Find("Text (1)").GetComponent<TextMeshProUGUI>().text = LocalizationManager.GetStringByKey("GameOverMessage1");
        GameOverMessages[1].transform.Find("Text (1)").GetComponent<TextMeshProUGUI>().text = LocalizationManager.GetStringByKey("GameOverMessage2");
        GameOverMessages[2].transform.Find("Text (1)").GetComponent<TextMeshProUGUI>().text = LocalizationManager.GetStringByKey("GameOverMessage3");
        GameOverMessages[3].transform.Find("Text (1)").GetComponent<TextMeshProUGUI>().text = LocalizationManager.GetStringByKey("GameOverMessage4");
    }

    public void ShowWellcomeMessages()
    {
        Time.timeScale = 0;
        curMessageIndex = 0;
        isShowings[0] = true;
        nextClicked = true;
        TutorialPanel.SetActive(true);
    }

    public void ShowRageMessages()
    {
        Time.timeScale = 0;
        curMessageIndex = 0;
        isShowings[1] = true;
        nextClicked = true;
        TutorialPanel.SetActive(true);
    }

    public void ShowSpecialMessages()
    {
        Time.timeScale = 0;
        curMessageIndex = 0;
        isShowings[2] = true;
        nextClicked = true;
        TutorialPanel.SetActive(true);
    }

    public void ShowAchieveMessages()
    {
        Time.timeScale = 0;
        curMessageIndex = 0;
        isShowings[3] = true;
        nextClicked = true;
        TutorialPanel.SetActive(true);
    }

    public void ShowGameOverMessages()
    {
        Time.timeScale = 0;
        curMessageIndex = 0;
        isShowings[4] = true;
        nextClicked = true;
        TutorialPanel.SetActive(true);
    }

    public void OnNextButton()
    {
        nextClicked = true;
        curMessageIndex++;
    }

    public void OpenVK()
    {
        Application.OpenURL("https://vk.com/penguin_the_narrator");
    }

    public void OpenYouTube()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCdQLufIKQi0HFeZuDg_tNOw/featured");
    }

    private void ShowMessages(int messagesIndex)
    {
        GameObject[] messages = null;

        switch (messagesIndex)
        {
            case 0:
                messages = WellcomeMessages;
                break;
            case 1:
                messages = RageMessages;
                break;
            case 2:
                messages = SpecialMessages;
                break;
            case 3:
                messages = AchieveMessages;
                break;
            case 4:
                messages = GameOverMessages;
                break;
            default:
                messages = WellcomeMessages;
                break;
        }

        if (nextClicked)
        {
            if (curMessageIndex < messages.Length)
            {
                if (curMessageIndex > 0) messages[curMessageIndex - 1].SetActive(false);
                messages[curMessageIndex].SetActive(true);
            }
            else
            {
                messages[curMessageIndex - 1].SetActive(false);
                isShowings[messagesIndex] = false;
                TutorialDoneNotify?.Invoke(messagesIndex);
                TutorialPanel.SetActive(false);
                Time.timeScale = 1;
            }
            nextClicked = false;
        }
    }

    private List<bool> isShowings = new List<bool>() { false, false, false, false, false };
    private bool nextClicked = false;
    private int curMessageIndex = 0;
}
