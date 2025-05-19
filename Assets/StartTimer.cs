using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StartTimer : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI timerText;

    private void Start()
    {
        StartCoroutine(Countdown(4f));
    }

    private IEnumerator Countdown(float countdown)
    {

        while (countdown > 0)
        {
            countdown -= Time.deltaTime;
            if (countdown > 3f)
            {
                timerText.text = "3";
            }else if (countdown > 2f)
            {
                timerText.text = "2";
            } else if (countdown > 1f)
            {
                timerText.text = "1";
            }
            else if(countdown <= 1f)
            {
                timerText.text = "JOUST!!!";
            }

            if (countdown <= 0)
            {
                ACharacter.canMove = true;
                timerText.gameObject.SetActive(false);
            }
            yield return null;
        }
    }
}
