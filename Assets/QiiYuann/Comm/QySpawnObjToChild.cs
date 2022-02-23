using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QySpawnObjToChild : MonoBehaviour
{
	[System.Serializable]
	public class SpawnData
    {
		public GameObject prefab;
		public Transform parent;
		internal void SpawnObj()
        {
			if (prefab == null || parent == null)
            {
				return;
            }

			Transform tr = Instantiate(prefab).transform;
			tr.SetParent(parent);
			tr.localPosition = Vector3.zero;
			tr.localEulerAngles = Vector3.zero;
        }
    }
	public SpawnData[] m_SpawnDatas;

	// Use this for initialization
	void Start()
	{
		SpawnObj();
	}
	
	void SpawnObj()
	{
        for (int i = 0; i < m_SpawnDatas.Length; i++)
        {
			m_SpawnDatas[i].SpawnObj();
		}
	}
}
