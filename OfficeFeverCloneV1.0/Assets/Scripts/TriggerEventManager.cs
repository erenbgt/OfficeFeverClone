using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventManager : MonoBehaviour
{

    public delegate void OnCollectArea();
    public static event OnCollectArea OnPaperCollect;

    bool isCollecting;
    void Start()
    {
        StartCoroutine(collectEnum());
    }

    IEnumerator collectEnum()
    {
        while (true)
        {
            if (isCollecting == true)
            {
                OnPaperCollect();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            isCollecting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            isCollecting = false;
        }
    }
}
