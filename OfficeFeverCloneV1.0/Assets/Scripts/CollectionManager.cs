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
    }

    private void OnDisable()
    {
        TriggerEventManager.OnPaperCollect -= getPaper;
    }

    void getPaper()
    {
        if (paperList.Count <= paperLimit)
        {
            GameObject temp = Instantiate(paperPrefab, collectionPoint);
            temp.transform.position = new Vector3(collectionPoint.position.x,
                ((float)paperList.Count/20), 
                collectionPoint.position.z);
        }
    }
}
