using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QyCopyTransformInfo : MonoBehaviour
{
    [System.Serializable]
    public class Data
    {
        public Transform Obj;
        public Transform Target;
        public void CopyTransformInfo(bool isCopyPos, bool isCopyRot, bool isCopyScale)
        {
            if (Obj == null || Target == null)
            {
                return;
            }

            if (isCopyPos)
            {
                Target.localPosition = Obj.localPosition;
            }

            if (isCopyRot)
            {
                Target.localEulerAngles = Obj.localEulerAngles;
            }

            if (isCopyScale)
            {
                Target.localScale = Obj.localScale;
            }
        }
    }
    public Data[] m_Datas;
    public bool IsEnable = false;
    public bool IsCopyPos = true;
    public bool IsCopyRot = true;
    public bool IsCopyScale = true;

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
		if (IsEnable)
        {
            IsEnable = false;
            for (int i = 0; i < m_Datas.Length; i++)
            {
                if (m_Datas[i] != null)
                {
                    m_Datas[i].CopyTransformInfo(IsCopyPos, IsCopyRot, IsCopyScale);
                }
            }
        }
    }
#endif
}
