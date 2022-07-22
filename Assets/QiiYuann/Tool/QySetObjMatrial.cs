using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QySetObjMatrial : MonoBehaviour
{
    public Material m_OldMat;
    public Material m_NewMat;
    public bool IsCheck = false;
    private void OnDrawGizmosSelected()
    {
        CheckChildMatrial();
    }

    void CheckChildMatrial()
    {
        if (!IsCheck)
        {
            return;
        }
        IsCheck = false;

        MeshRenderer[] meshArray = GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < meshArray.Length; i++)
        {
            if (string.Compare(meshArray[i].sharedMaterial.name, 0, m_OldMat.name, 0, m_OldMat.name.Length) == 0)
            {
                Debug.Log("name ===== " + meshArray[i].name);
                //meshArray[i].material = m_NewMat;
                meshArray[i].sharedMaterial = m_NewMat;
            }
        }
    }
}
