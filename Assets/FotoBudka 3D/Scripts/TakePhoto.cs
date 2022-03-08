using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class TakePhoto : MonoBehaviour
{
    public GameObject[] hideButtons;
    public GameObject photoFlash;
    bool canTakePhoto;

    int resX;
    int resY;
    void Start()
    {
        resX = Screen.width;
        resY = Screen.height;
        canTakePhoto = true;
    }

    public void Photo()
    {
        if(canTakePhoto)
        {
            StartCoroutine(TakeSnapshot());
        }
    }

    IEnumerator TakeSnapshot()
    {
        canTakePhoto = false;
        photoFlash.SetActive(true);
        photoFlash.GetComponent<Animator>().Play("photoFlashAnim");

        for(int i = 0; i < hideButtons.Length; i++)
        {
            hideButtons[i].SetActive(false);
        }

        yield return new WaitForEndOfFrame();

        Texture2D photo = new Texture2D(resX, resY, TextureFormat.RGB24, false);
        photo.ReadPixels(new Rect(0, 0, resX, resY), 0, 0);
        byte[] bytes = photo.EncodeToJPG();
        string fileName = PhotoData();
        
        if(!Directory.Exists(Application.dataPath + "/Output"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Output");
        }
        System.IO.File.WriteAllBytes(fileName, bytes);


        yield return new WaitForSeconds(1);

        
        photoFlash.SetActive(false);
        for (int i = 0; i < hideButtons.Length; i++)
        {
            hideButtons[i].SetActive(true);
        }
        canTakePhoto = true;
    }

    string PhotoData()
    {
        return string.Format("{0}/Output/photo_{1}x{2}_{3}.jpg",
            Application.dataPath,
            resX,
            resY,
            System.DateTime.Now.ToString("yyyy-MM-dd-HH-MM-ss"));
    }
}
