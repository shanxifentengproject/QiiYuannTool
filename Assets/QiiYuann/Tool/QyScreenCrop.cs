using UnityEngine;
using System.Collections;
using System.IO;
 
public class QyScreenCrop : MonoBehaviour
{
    Texture2D cutImage;
    Rect rect;

    private void Start()
    {
        string path = Application.dataPath + "/../ScreenCrop";
        if (!Directory.Exists(path))
        {
            Debug.Log("create ScreenCrop fold..............");
            Directory.CreateDirectory(path);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            //截图
            StartCoroutine(CutImage());
        }
    }

    public string m_ImgName = "CurImage";
    //截图
    IEnumerator CutImage()
    {
        //图片大小
        cutImage = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);
 
        //坐标左下角为0点
        rect = new Rect(0f, 0f, Screen.width, Screen.height);
 
        yield return new WaitForEndOfFrame();
        cutImage.ReadPixels(rect, 0, 0, true); 
        
        cutImage.Apply();
        yield return cutImage;
        byte[] byt = cutImage.EncodeToPNG();
        //保存截图Project面板下要创建StreamingAssets文件夹，保存文件后要刷新Project面板图片才会显示出来
        //string path = Application.streamingAssetsPath + "/ScreenCrop/CutImage.png";
        //Assets文件夹外创建ScreenCrop文件夹
        string path = Application.dataPath + "/../ScreenCrop/" + m_ImgName + ".png";
        Debug.Log("path ==== " + path);
        File.WriteAllBytes(path, byt);
    }
}