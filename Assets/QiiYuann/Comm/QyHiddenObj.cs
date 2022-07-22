using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QyHiddenObj : MonoBehaviour
{
    public GameObject[] m_Objs;
    // Start is called before the first frame update
    void Awake()
    {
        HiddenObjs();
    }

    void HiddenObjs()
    {
        for (int i = 0; i < m_Objs.Length; i++)
        {
            m_Objs[i].SetActive(false);
        }
    }
}
