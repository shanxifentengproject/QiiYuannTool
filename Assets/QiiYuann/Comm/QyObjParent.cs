using UnityEngine;

public class QyObjParent : MonoBehaviour
{
    Transform ObjParentTr;
    internal void InitParentTr(string parentName)
    {
        if (ObjParentTr != null)
        {
            return;
        }
        GameObject obj = new GameObject(parentName);
        ObjParentTr = obj.transform;
    }

    internal void AddToParent(Transform tr)
    {
        if (ObjParentTr != null && tr != null)
        {
            tr.SetParent(ObjParentTr);
        }
    }

    internal void HiddenParent()
    {
        if (ObjParentTr != null)
        {
            QyFun.SetActive(ObjParentTr.gameObject, false);
        }
    }
}
