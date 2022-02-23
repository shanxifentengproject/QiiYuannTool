using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QyRandomAnimation : MonoBehaviour
{
	public Animator m_Animator;
	[System.Serializable]
	public class AniData
    {
		public string aniName;
		/// <summary>
		/// 动画特效
		/// </summary>
		public GameObject effect;
		public void PlayAnimation(Animator animator)
        {
			if (animator != null)
            {
				animator.Play(aniName);
			}
			SetActiveEffect(true);
		}

		public void SetActiveEffect(bool isActive)
        {
			if (effect != null)
            {
				effect.SetActive(isActive);
            }
        }
    }
	public AniData[] m_AniDatas;

	void OnEnable()
	{
		m_IndexStart = Random.Range(0, 100) % m_AniDatas.Length;
		StartCoroutine(RandomAnimation());
	}
	
	void OnDisable()
	{
		StopAllCoroutines();
	}

	internal void ChangeAnimation()
    {
		StopAllCoroutines();
		StartCoroutine(RandomAnimation());
    }

	void PlayAnimation()
	{
		for (int i = 0; i < m_AniDatas.Length; i++)
		{
			if (m_IndexStart == i)
			{
				m_AniDatas[i].PlayAnimation(m_Animator);
			}
			else
			{
				m_AniDatas[i].SetActiveEffect(false);
			}
		}
		m_IndexStart = (m_IndexStart + 1) % m_AniDatas.Length;
	}

	int m_IndexStart = 0;
	IEnumerator RandomAnimation()
    {
        do
        {
			PlayAnimation();
			yield return new WaitForSeconds(Random.Range(8f, 12f));
        } while (this.enabled);
    }
}
