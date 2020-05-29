
/// <summary>
/// 数学计算类
/// </summary>
public class QyCalculate
{
    /// <summary>
    /// 线性计算数据
    /// </summary>
    [System.Serializable]
    public class LineData
    {
        public float m_MaxValue = 20f, m_MinValue = 3f;
        public float m_MaxDis = 30f, m_MinDis = 3f;
        internal float m_Key;
        internal void CalculateKey()
        {
            m_Key = (m_MaxValue - m_MinValue) / (m_MaxDis - m_MinDis);
        }

        internal float GetCurValue(float curDis)
        {
            return m_Key * (curDis - m_MinDis) + m_MinValue;
        }
    }
}
