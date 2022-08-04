using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QyDrawCircle : MonoBehaviour
{
    //画圆
    //radius = 1; // 圆环的半径
    //thetaVal = 0.1f; // 值越低圆环越平滑
    //color = Color.green; // 线框颜色
    public static void DrawCircle(Transform tr, float radius, Color color, float thetaVal = 0.2f)
    {
        //Transform tr = this.transform;
        if (tr == null) return;
        if (thetaVal < 0.0001f) thetaVal = 0.0001f;

        // 设置矩阵
        Matrix4x4 defaultMatrix = Gizmos.matrix;
        //Gizmos.matrix = tr.localToWorldMatrix;
        Matrix4x4 tmpMatrix = tr.localToWorldMatrix;
        Vector4 RowVal0 = tmpMatrix.GetRow(0);
        Vector4 RowVal2 = tmpMatrix.GetRow(2);
        RowVal0.x = RowVal2.z;
        tmpMatrix.SetRow(0, RowVal0);
        Gizmos.matrix = tmpMatrix;

        // 设置颜色
        Color defaultColor = Gizmos.color;
        Gizmos.color = color;

        // 绘制圆环
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

        // 绘制最后一条线段
        Gizmos.DrawLine(firstPoint, beginPoint);

        // 恢复默认颜色
        Gizmos.color = defaultColor;

        // 恢复默认矩阵
        Gizmos.matrix = defaultMatrix;
    }
}
