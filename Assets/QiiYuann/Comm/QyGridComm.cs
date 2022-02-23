using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QyGridComm : MonoBehaviour
{
    public GameObject m_Prefab;
    public int m_HorVal = 6;
    public int m_VerVal = 3;
    public int m_With = 60;
    public int m_Height = 120;
    public Vector2 m_StartPos;
    public GameObject m_GridParent;
    [HideInInspector]
    public GameObject[] m_GridUiList;
    // Start is called before the first frame update
    void Start()
    {
        CreateGridUi();
    }

    void CreateGridUi()
    {
        m_GridUiList = new GameObject[m_HorVal * m_VerVal];
        int index = 0;
        for (int i = 0; i < m_VerVal; i++)
        {
            for (int j = 0; j < m_HorVal; j++)
            {
                float px = j * m_With + m_StartPos.x;
                float py = - i * m_Height + m_StartPos.y;
                Vector3 pos = new Vector3(px, py, 0f);
                m_GridUiList[index] = (GameObject)GameObject.Instantiate(m_Prefab, Vector3.zero, Quaternion.identity);
                m_GridUiList[index].transform.SetParent(m_GridParent.transform);
                m_GridUiList[index].transform.localPosition = pos;
                m_GridUiList[index].transform.localScale = Vector3.one;
                index++;
            }
        }
    }
}
