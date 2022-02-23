using UnityEngine;
using UnityEngine.UI;

public class QyGuiToUGUI : MonoBehaviour
{
#if UNITY_EDITOR
    public bool IsAdd;
    public enum ImgType
    {
        RawImage = 0,
        Text = 1,
    }
    public ImgType m_ImgType;
    //public Color m_Color = Color.white;
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
                {
                    FtUiToUGUI(transform);
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
                //m_Color = textCom.color = textMesh.color;
                DestroyImmediate(textMesh);
            }

            MeshRenderer meshRender = textCom.GetComponent<MeshRenderer>();
            if (meshRender != null)
            {
                DestroyImmediate(meshRender);
            }
        }
    }

    void FtUiToUGUI(Transform tr)
    {
        if (tr == null)
        {
            return;
        }
        ChangeToRawImage(tr);
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
            //GUITexture textureCom = rawImg.GetComponent<GUITexture>();
            //if (textureCom != null && textureCom.texture != null)
            //{
            //    switch (m_ImgType)
            //    {
            //        case ImgType.RawImage:
            //            {
            //                rawImg.uvRect = new Rect(0f, 0f, 1f, 1f);
            //                break;
            //            }
            //    }

                //if (textureCom.texture != null)
                //{
                //    if (m_ImgType == ImgType.RawImage)
                //    {
                //        rawImg.color = textureCom.color;
                //    }
                //    rawImg.texture = textureCom.texture;
                //    rawImg.rectTransform.sizeDelta = new Vector2(rawImg.texture.width, rawImg.texture.height);
                //}
                //DestroyImmediate(textureCom);
            //}
        }
    }
#endif
}
