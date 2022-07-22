using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QySetTransform : QyRoot
{
    [System.Serializable]
    public class TranData
    {
        public bool IsEnable = false;
        public bool IsAllChild = false;
        public float m_Width = 100f;
        public float m_Height = 100f;
        public float offDisX = 0f;
        //一行排几个元素
        public int numX = 0;
        public float offDisY = 0f;
        public float offDisZ = 0f;
        public bool IsOnlyChangeName = false;
        public string nameHead = "";
        public Transform[] trArray;

        public void TestTr(Transform parentTr)
        {
            if (IsEnable == false)
            {
                return;
            }
            IsEnable = false;

            if (IsAllChild == true && parentTr != null)
            {
                trArray = new Transform[parentTr.childCount];
                for (int i = 0; i < trArray.Length; i++)
                {
                    trArray[i] = parentTr.GetChild(i);
                }
            }
            //Debug.Log("count ======== " + parentTr.childCount);

            if (trArray.Length < 1)
            {
                return;
            }

            Vector3 startPos = Vector3.zero;
            float indexStartPos = -0.5f * (trArray.Length - 1);
            if (numX > 0)
            {
                startPos.x = offDisX * indexStartPos;
                startPos.y = 0f;
                startPos.z = 0f;
            }
            else
            {
                startPos.x = offDisX * indexStartPos;
                startPos.y = offDisY * indexStartPos;
                startPos.z = offDisZ * indexStartPos;
            }

            if (!IsOnlyChangeName)
            {
                trArray[0].localPosition = startPos;
            }
            
            RectTransform rectTr = trArray[0].GetComponent<RectTransform>();
            if (rectTr != null)
            {
                rectTr.sizeDelta = new Vector2(m_Width, m_Height);
            }

            float startX = trArray[0].localPosition.x;
            float startY = trArray[0].localPosition.y;
            float startZ = trArray[0].localPosition.z;
            for (int i = 1; i < trArray.Length; i++)
            {
                if (IsOnlyChangeName)
                {
                    break;
                }

                Vector3 lp = Vector3.zero;
                if (numX > 0)
                {
                    lp.x = startX + (i % numX) * offDisX;
                    lp.y = (i / numX) * offDisY;
                    lp.z = (i / numX) * offDisZ;
                }
                else
                {
                    lp.x = startX + i * offDisX;
                    lp.y = startY + i * offDisY;
                    lp.z = startZ + i * offDisZ;
                }
                trArray[i].localPosition = lp;

                rectTr = trArray[i].GetComponent<RectTransform>();
                if (rectTr != null)
                {
                    rectTr.sizeDelta = new Vector2(m_Width, m_Height);
                }
            }

            if (nameHead != "" && IsOnlyChangeName)
            {
                for (int i = 0; i < trArray.Length; i++)
                {
                    trArray[i].name = nameHead + (i + 1).ToString();
                }
            }
        }
    }
    public TranData m_TranData;

    [System.Serializable]
    public class MatData
    {
        public bool IsEnable = false;
        public Material[] matArray;
        public void Init()
        {
            for (int i = 0; i < matArray.Length; i++)
            {
                matArray[i].mainTextureOffset = Vector2.zero;
                matArray[i].mainTextureScale = Vector2.one;
            }
        }

        public void TestMat()
        {
            if (IsEnable == false)
            {
                return;
            }
            IsEnable = false;

            for (int i = 0; i < matArray.Length; i++)
            {
                matArray[i].mainTextureOffset = new Vector2(0.8f, 0f);
                matArray[i].mainTextureScale = new Vector2(0.1f, 1f);
            }
        }
    }
    public MatData m_MatData;

    void Awake()
    {
        m_MatData.Init();
        Destroy(this);
    }

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        if (m_MatData != null)
        {
            m_MatData.TestMat();
        }

        if (m_TranData != null)
        {
            m_TranData.TestTr(transform);
        }
    }
#endif
}
