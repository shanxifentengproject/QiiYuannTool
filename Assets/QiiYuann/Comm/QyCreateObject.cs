using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 动态创建预制脚本
/// </summary>
class QyCreateObject
{
    /// <summary>
    /// 产生预制.
    /// </summary>
    public static GameObject Instantiate(GameObject prefab, Transform parent, Transform trPosRot = null)
    {
        if (prefab == null)
        {
            QyDebug.LogWarning("Instantiate -> prefab was null");
            return null;
        }

        GameObject obj = (GameObject)Object.Instantiate(prefab);
        if (parent != null)
        {
            obj.transform.SetParent(parent);
            if (trPosRot == null)
            {
                obj.transform.localScale = prefab.transform.localScale;
                obj.transform.localPosition = prefab.transform.localPosition;
                obj.transform.localEulerAngles = prefab.transform.localEulerAngles;
            }
            else
            {
                obj.transform.position = trPosRot.position;
                obj.transform.rotation = trPosRot.rotation;
            }
        }
        return obj;
    }

    /// <summary>
    /// 产生预制.
    /// </summary>
    public static GameObject Instantiate(string prefabPath, Transform parent, Transform trPosRot = null)
    {
        GameObject prefab = (GameObject)Resources.Load(prefabPath);
        if (prefab == null)
        {
            QyDebug.LogWarning("Instantiate -> prefab was null");
            return null;
        }
        return Instantiate(prefab, parent, trPosRot);
    }
}
