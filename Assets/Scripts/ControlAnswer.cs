using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlAnswer : MonoBehaviour
{
    [SerializeField] private Text _answerText;

    public bool CanCheck = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (CanCheck)
        {
            _answerText.text = collision.gameObject.name;

            CanCheck = false;
            Debug.Log(collision.gameObject.name);
        }
        
    }
}
