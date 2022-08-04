using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QyDrawCircle : MonoBehaviour
{
    //��Բ
    //radius = 1; // Բ���İ뾶
    //thetaVal = 0.1f; // ֵԽ��Բ��Խƽ��
    //color = Color.green; // �߿���ɫ
    public static void DrawCircle(Transform tr, float radius, Color color, float thetaVal = 0.2f)
    {
        //Transform tr = this.transform;
        if (tr == null) return;
        if (thetaVal < 0.0001f) thetaVal = 0.0001f;

        // ���þ���
        Matrix4x4 defaultMatrix = Gizmos.matrix;
        //Gizmos.matrix = tr.localToWorldMatrix;
        Matrix4x4 tmpMatrix = tr.localToWorldMatrix;
        Vector4 RowVal0 = tmpMatrix.GetRow(0);
        Vector4 RowVal2 = tmpMatrix.GetRow(2);
        RowVal0.x = RowVal2.z;
        tmpMatrix.SetRow(0, RowVal0);
        Gizmos.matrix = tmpMatrix;

        // ������ɫ
        Color defaultColor = Gizmos.color;
        Gizmos.color = color;

        // ����Բ��
        Vector3 beginPoint = Vector3.zero;
        Vector3 firstPoint = Vector3.zero;
        for (float theta = 0; theta < 2 * Mathf.PI; theta += thetaVal)
        {
            float x = radius * Mathf.Cos(theta) * 0.5f;
            float z = radius * Mathf.Sin(theta) * 0.5f;
            Vector3 endPoint = new Vector3(x, 0, z);
            if (theta == 0)
            {
                firstPoint = endPoint;
            }
            else
            {
                Gizmos.DrawLine(beginPoint, endPoint);
            }
            beginPoint = endPoint;
        }

        // �������һ���߶�
        Gizmos.DrawLine(firstPoint, beginPoint);

        // �ָ�Ĭ����ɫ
        Gizmos.color = defaultColor;

        // �ָ�Ĭ�Ͼ���
        Gizmos.matrix = defaultMatrix;
    }
}
