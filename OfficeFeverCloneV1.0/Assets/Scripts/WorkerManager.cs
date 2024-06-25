using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerManager : MonoBehaviour
{
    public List<GameObject> paperList = new List<GameObject>();
    List<GameObject> moneyList = new List<GameObject>();

    public GameObject paperPrefab, moneyPrefab;
    public Transform paperPoint, moneyPoint;

    private void Start()
    {
        StartCoroutine(printMoney());
    }

    IEnumerator printMoney()
    {
        while (true)
        {
            if (paperList.Count > 0)
            {
                GameObject temp = Instantiate(moneyPrefab);
                temp.transform.position = new Vector3(moneyPoint.position.x,
                    (float)moneyList.Count / 30,
                    moneyPoint.position.z);
                moneyList.Add(temp);
                RemoveLast();
            }

            yield return new WaitForSeconds(1f);
        }
    }
    public void getPaper()
    {
        GameObject temp = Instantiate(paperPrefab);
        temp.transform.position = new Vector3(paperPoint.position.x, 
            0.8f + (float)paperList.Count / 60, 
            paperPoint.position.z);
        paperList.Add(temp);
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
