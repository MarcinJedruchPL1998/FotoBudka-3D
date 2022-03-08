using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeModel : MonoBehaviour
{
    public GameObject[] models;
    public int modelNumber;

    [SerializeField] Transform modelPos;

    private void Start()
    {
        models = Resources.LoadAll<GameObject>("Input");
        modelNumber = PlayerPrefs.GetInt("ModelNumber", 0);
        Instantiate(models[modelNumber], modelPos.position, Quaternion.identity, modelPos);
    }

    public void NextModel()
    {
        if(modelNumber < models.Length - 1)
        {
            modelNumber++;
           
        }
        else
        {
            modelNumber = 0;
           
        }
        StartCoroutine(LoadNewModel());
    }

    public void PreviousModel()
    {
        if (modelNumber > 0)
        {
            modelNumber--;
            
        }
        else
        {
            modelNumber = models.Length - 1;
           
        }
        StartCoroutine(LoadNewModel());
    }

    IEnumerator LoadNewModel()
    {
        modelPos.GetComponent<Animator>().enabled = true;
        modelPos.GetComponent<Animator>().CrossFade("modelPosAnimUp", 0.1f);
        yield return new WaitForSeconds(0.4f);
        GameObject model = modelPos.transform.GetChild(0).gameObject;
        Destroy(model);
        Instantiate(models[modelNumber], modelPos.position, Quaternion.identity, modelPos);
        modelPos.GetComponent<Animator>().CrossFade("modelPosAnimDown", 0.1f);
        
    }

}
