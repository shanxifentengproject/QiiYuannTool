using System;
using UnityEngine;

public class QyFun
{
    public static void SetActive(GameObject obj, bool isActive)
    {
        if (obj != null && obj.activeSelf != isActive)
        {
            obj.SetActive(isActive);
        }
    }

    public static void NormalizeTransform(Transform tr, Transform trParent)
    {
        if (tr != null)
        {
            tr.SetParent(trParent);
            tr.localPosition = Vector3.zero;
            tr.localEulerAngles = Vector3.zero;
            tr.localScale = Vector3.one;
        }
    }

    public static void NormalizeTransform(Transform tr)
    {
        if (tr != null)
        {
            tr.localPosition = Vector3.zero;
            tr.localEulerAngles = Vector3.zero;
            tr.localScale = Vector3.one;
        }
    }
}