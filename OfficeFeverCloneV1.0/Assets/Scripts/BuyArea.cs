using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyArea : MonoBehaviour
{
    public GameObject deskGameObject;
    public GameObject buyGameObject;
    public float cost;
    public float currentMoney;
    public float progress;
    public Image progressImage;
    public void Buy(int moneyAmount)
    {
        currentMoney += moneyAmount;
        progress = currentMoney / cost;
        progressImage.fillAmount = progress;
        if (progress >= 1)
        {
            buyGameObject.SetActive(false);
            deskGameObject.SetActive(true);
            this.enabled = false;
        }

    }
}
