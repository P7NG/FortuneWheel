using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class ControlAnswer : MonoBehaviour
{
    [SerializeField] private Text _answerText;

    [SerializeField] private Text _yesCountText;
    [SerializeField] private Text _noCountText;
    [SerializeField] private AudioSource _player;
    [SerializeField] private AudioClip _afterResult;

    public bool CanCheck = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (CanCheck)
        {
            _answerText.text = collision.gameObject.transform.GetChild(0).GetComponent<Text>().text;

            CanCheck = false;
            _player.PlayOneShot(_afterResult);
            if(collision.gameObject.name == "Yes")
            {
                YandexGame.savesData.YesAnswerCount++;
            }
            else if (collision.gameObject.name == "No")
            {
                YandexGame.savesData.NoAnswerCount++;
            }
            YandexGame.SaveProgress();
            ChangeStats();
        }
    }

    private void Start()
    {
        ChangeStats();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _player.Play();
    }

    public void ChangeStats()
    {
        if (YandexGame.savesData.YesAnswerCount + YandexGame.savesData.NoAnswerCount > 0)
        {
            _yesCountText.text = YandexGame.savesData.YesAnswerCount + " - " + (YandexGame.savesData.YesAnswerCount * 100 / (YandexGame.savesData.YesAnswerCount + YandexGame.savesData.NoAnswerCount)) + "%";
            _noCountText.text = YandexGame.savesData.NoAnswerCount + " - " + (YandexGame.savesData.NoAnswerCount * 100 / (YandexGame.savesData.YesAnswerCount + YandexGame.savesData.NoAnswerCount)) + "%";
        }

        if(YandexGame.savesData.YesAnswerCount + YandexGame.savesData.NoAnswerCount == 0)
        {
            _yesCountText.text = "0";
            _noCountText.text = "0";
        }

        YandexGame.FullscreenShow();
    }
}
