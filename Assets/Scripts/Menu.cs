using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private ControlAnswer _controlAnswer;

    public void CloseOpenPanel()
    {
        _panel.SetActive(!_panel.activeInHierarchy);
    }

    public void ClearProgress()
    {
        YandexGame.savesData.YesAnswerCount = 0;
        YandexGame.savesData.NoAnswerCount = 0;
        YandexGame.SaveProgress();
        _controlAnswer.ChangeStats();
    }
}
