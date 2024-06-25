using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyManager : MonoBehaviour
{
    public int moneyCount = 0;
    private void OnEnable()
    {
        TriggerEventManager.OnMoneyCollected += IncreaseMoney;
        TriggerEventManager.OnBuyingDesk += buyArea;
    }
    private void OnDisable()
    {
        TriggerEventManager.OnMoneyCollected -= IncreaseMoney;
        TriggerEventManager.OnBuyingDesk -= buyArea;
    }
    
    void buyArea()
    {
        if (TriggerEventManager.areaToBuy != null)
        {
            if (moneyCount >= 1)
            {
                TriggerEventManager.areaToBuy.Buy(1);
                moneyCount -= 1;
            }
        }
    }
    void IncreaseMoney()
    {
        moneyCount += 50;
    }
}
