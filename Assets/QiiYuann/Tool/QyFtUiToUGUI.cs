#if PLATFORM_COMMON || _GameType_BaoYue  //纷腾互动单机版或包月版
#define FENTENG_PROJECT //纷腾互动工程
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QyFtUiToUGUI : MonoBehaviour
{
#if UNITY_EDITOR && FENTENG_PROJECT
    public bool IsAdd;
    public enum ImgType
    {
        RawImage = 0,
        NunRawImage = 1,
        Text = 2,
        Image = 3,
    }
    public ImgType m_ImgType;
    public Sprite m_ImgSprite;
    public Color m_Color = Color.white;
    void OnDrawGizmosSelected()
    {
        if (IsAdd)
        {
            IsAdd = false;
            FtUiToUGUI();
        }
    }

    void FtUiToUGUI()
    {
        switch (m_ImgType)
        {
            case ImgType.RawImage:
            case ImgType.Image:
                {
                    FtUiToUGUI(transform);
                    break;
                }
            case ImgType.NunRawImage:
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        FtUiToUGUI(transform.GetChild(i));
                    }
                    transform.localPosition = Vector3.zero;
                    transform.localEulerAngles = Vector3.zero;
                    transform.localScale = Vector3.one;
                    break;
                }
            case ImgType.Text:
                {
                    FtUiTextMeshToTextUi(transform);
                    break;
                }
        }
    }

    void FtUiTextMeshToTextUi(Transform tr)
    {
        if (tr == null)
        {
            return;
        }

        Text textCom = tr.GetComponent<Text>();
        if (textCom == null)
        {
            textCom = tr.gameObject.AddComponent<Text>();
            textCom.rectTransform.localPosition = Vector3.zero;
            textCom.rectTransform.localEulerAngles = Vector3.zero;
            textCom.rectTransform.localScale = Vector3.one;
            TextMesh textMesh = textCom.GetComponent<TextMesh>();
            if (textMesh != null)
            {
                textCom.text = textMesh.text;
                m_Color = textCom.color = textMesh.color;
                DestroyImmediate(textMesh);
            }

            MeshRenderer meshRender = textCom.GetComponent<MeshRenderer>();
            if (meshRender != null)
            {
                DestroyImmediate(meshRender);
            }
        }

        Text3dEx text3dCom = textCom.GetComponent<Text3dEx>();
        if (text3dCom == null)
        {
            textCom.gameObject.AddComponent<Text3dEx>();
        }
    }

    void FtUiToUGUI(Transform tr)
    {
        if (tr == null)
        {
            return;
        }

        if (m_ImgType == ImgType.Image)
        {
            ChangeToImage(tr);
        }
        else
        {
            ChangeToRawImage(tr);
        }
    }

    void ChangeToImage(Transform tr)
    {
        Image img = tr.GetComponent<Image>();
        if (img == null && m_ImgSprite != null)
        {
            img = tr.gameObject.AddComponent<Image>();
            img.rectTransform.localPosition = Vector3.zero;
            img.rectTransform.localEulerAngles = Vector3.zero;
            img.rectTransform.localScale = Vector3.one;
            img.type = Image.Type.Filled;
            img.fillMethod = Image.FillMethod.Horizontal;
            MeshRenderer meshRender = img.GetComponent<MeshRenderer>();
            if (meshRender != null)
            {
                img.sprite = m_ImgSprite;
                img.rectTransform.sizeDelta = new Vector2(m_ImgSprite.rect.width, m_ImgSprite.rect.height);
                DestroyImmediate(meshRender);
            }

            MeshFilter meshFilter = img.GetComponent<MeshFilter>();
            if (meshFilter != null)
            {
                DestroyImmediate(meshFilter);
            }
        }
    }

    void ChangeToRawImage(Transform tr)
    {
        RawImage rawImg = tr.GetComponent<RawImage>();
        if (rawImg == null)
        {
            rawImg = tr.gameObject.AddComponent<RawImage>();
            rawImg.rectTransform.localPosition = Vector3.zero;
            rawImg.rectTransform.localEulerAngles = Vector3.zero;
            rawImg.rectTransform.localScale = Vector3.one;
            MeshRenderer meshRender = rawImg.GetComponent<MeshRenderer>();
            if (meshRender != null && meshRender.sharedMaterial != null)
            {
                float rectWidthOffset = 1f;
                switch (m_ImgType)
                {
                    case ImgType.RawImage:
                        {
                            rawImg.uvRect = new Rect(0f, 0f, 1f, 1f);
                            break;
                        }
                    case ImgType.NunRawImage:
                        {
                            rectWidthOffset = 0.1f;
                            rawImg.uvRect = new Rect(0f, 0f, 0.1f, 1f);
                            break;
                        }
                }

                if (meshRender.sharedMaterial.mainTexture != null)
                {
                    if (m_ImgType == ImgType.RawImage)
                    {
                        rawImg.color = m_Color;
                    }
                    rawImg.texture = meshRender.sharedMaterial.mainTexture;
                    rawImg.rectTransform.sizeDelta = new Vector2(rectWidthOffset * rawImg.texture.width, rawImg.texture.height);
                }
                DestroyImmediate(meshRender);
            }

            MeshFilter meshFilter = rawImg.GetComponent<MeshFilter>();
            if (meshFilter != null)
            {
                DestroyImmediate(meshFilter);
            }
        }
    }
#endif
}
