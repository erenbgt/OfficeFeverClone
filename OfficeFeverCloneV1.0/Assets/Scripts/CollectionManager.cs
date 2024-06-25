using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionManager : MonoBehaviour
{
    public List<GameObject> paperList = new List<GameObject>();
    public GameObject paperPrefab;
    public Transform collectionPoint;

    int paperLimit = 10;

    private void OnEnable()
    {
        TriggerEventManager.OnPaperCollect += getPaper;
        TriggerEventManager.OnPaperGive += GivePaper;
    }

    private void OnDisable()
    {
        TriggerEventManager.OnPaperCollect -= getPaper;
        TriggerEventManager.OnPaperGive -= GivePaper;
    }

    void getPaper()
    {
        if (paperList.Count <= paperLimit)
        {
            GameObject temp = Instantiate(paperPrefab, collectionPoint);
            temp.transform.position = new Vector3(collectionPoint.position.x,
                0.5f+ ((float)paperList.Count/60), 
                collectionPoint.position.z);
            paperList.Add(temp);
            if (TriggerEventManager.printManager != null)
            {
                TriggerEventManager.printManager.RemoveLast();
            }
        }
    }

    public void GivePaper()
    {
        if (paperList.Count > 0)
        {
            TriggerEventManager.workerManager.getPaper();
            RemoveLast();
        }
    }
    public void RemoveLast()
    {
        if (paperList.Count > 0)
        {
            Destroy(paperList[paperList.Count - 1]);
            paperList.RemoveAt(paperList.Count - 1);
        }
    }
}
