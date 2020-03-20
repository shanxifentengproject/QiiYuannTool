using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QyChangeObjPos : QyRoot
{
    public float offDisX = 0f;

    public void SetPosition(int max)
    {
        if (max < 0)
        {
            return;
        }

        if (max > transform.childCount)
        {
            max = transform.childCount;
        }

        int count = 0;
        Transform[] trArray = new Transform[max];
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            if (count < max)
            {
                trArray[count] = transform.GetChild(i);
            }
            QyFun.SetActive(transform.GetChild(i).gameObject, count < max ? true : false);
            count++;
        }

        List<Transform> listTr = new List<Transform>(trArray);
        listTr.Reverse();
        trArray = listTr.ToArray();

        Vector3 startPos = Vector3.zero;
        float indexStartX = -0.5f * (trArray.Length - 1);
        startPos.x = offDisX * indexStartX;
        trArray[0].localPosition = startPos;

        float startX = trArray[0].localPosition.x;
        for (int i = 1; i < trArray.Length; i++)
        {
            Vector3 lp = Vector3.zero;
            lp.x = startX + i * offDisX;
            trArray[i].localPosition = lp;
        }
    }
}
