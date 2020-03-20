using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QyCloneObjTool : MonoBehaviour
{
    public Transform[] m_Objs;
    public Transform[] m_Targets;
    [System.Serializable]
    public class Data
    {
        [Range(0, 100)]
        public int Index = 0;
        public bool IsEnable = false;
    }
    public Data m_CloneData;
    public Data m_ClearData;

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        if (m_CloneData.IsEnable)
        {
            m_CloneData.IsEnable = false;
            for (int i = 0; i < m_Objs.Length; i++)
            {
                if (m_Objs[i] != null && m_Objs[i].childCount > m_CloneData.Index)
                {
                    if (m_Targets.Length > i && m_Targets[i] != null)
                    {
                        Transform objTr = m_Objs[i].GetChild(m_CloneData.Index);
                        GameObject objClone = Instantiate(objTr.gameObject);
                        objClone.name = objTr.name;

                        Transform ObjCloneTr = objClone.transform;
                        ObjCloneTr.SetParent(m_Targets[i]);
                        ObjCloneTr.localPosition = objTr.localPosition;
                        ObjCloneTr.localEulerAngles = objTr.localEulerAngles;
                        ObjCloneTr.localScale = objTr.localScale;
                    }
                }
            }
        }

        if (m_ClearData.IsEnable)
        {
            m_ClearData.IsEnable = false;
            for (int i = 0; i < m_Targets.Length; i++)
            {
                if (m_Targets[i] != null && m_Targets[i].childCount > m_ClearData.Index)
                {
                    DestroyImmediate(m_Targets[i].GetChild(m_ClearData.Index).gameObject);
                }
            }
        }
    }
#endif
}
