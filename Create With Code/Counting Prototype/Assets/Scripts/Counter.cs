using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public GameManager GameManager;
    public Text CounterText;
    public Text TimerText;

    int Count = 0;
    float targetTime = 10f;
    int coinPrice = 1;

    bool isDoubleCoins = false;

    private void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        Count = 0;
    }

    private void Update()
    {
        if(isDoubleCoins)
        {
            DoubleCoins();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            CountText(coinPrice);
        }
        if (other.gameObject.CompareTag("Decrease Coins"))
        {
            CountText(-Count/2);
        }
        if (other.gameObject.CompareTag("Coin Double"))
        {
            isDoubleCoins = true;
        }
        if (other.gameObject.CompareTag("Game Over"))
        {
            GameManager.GameOver();
        }
    }

    public void CountText(int count)
    {
        Count += count;
        CounterText.text = "Count : " + Count;
    }

    void DoubleCoins()
    {
        targetTime -= Time.deltaTime;
        TimerText.gameObject.SetActive(true);
        TimerText.text = "Timer : " + Mathf.RoundToInt(targetTime);
        coinPrice = 2;
        if (targetTime <= 0)
        {
            TimerEnd();
        }
    }

    void TimerEnd()
    {
        TimerText.gameObject.SetActive(false);
        coinPrice = 1;
        isDoubleCoins = false;
        targetTime = 10;
    }
}
