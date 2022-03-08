using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtons : MonoBehaviour
{
    [SerializeField] private string animPointerOn;
    [SerializeField] private string animPointerOff;
    Animator anim;
    [SerializeField] GameObject canvas;

    private void Start()
    {
        anim = GetComponent<Animator>();
        
    }
    public void MousePointerOn()
    {
        if(!canvas.GetComponent<ModelMovement>().isMoving)
        {
            anim.enabled = true;
            anim.CrossFade(animPointerOn, 0.1f);
        }
    
    }

    public void MousePointerOff()
    {
        if (!canvas.GetComponent<ModelMovement>().isMoving)
        {
            anim.CrossFade(animPointerOff, 0.1f);
        }
           
    }

    public void MousePointerClickBack()
    {
        canvas.GetComponent<ChangeModel>().PreviousModel();
    }

    public void MousePointerClickForward()
    {
        canvas.GetComponent<ChangeModel>().NextModel();
    }

    public void MousePointerClickPhoto()
    {
        canvas.GetComponent<TakePhoto>().Photo();
    }

    public void CloseApp()
    {
        Application.Quit();
    }

    public void OpenBackgroundList()
    {
        if (!canvas.GetComponent<ModelMovement>().isMoving)
        {
            anim.enabled = true;
            anim.CrossFade(animPointerOn, 0.1f);
        }
            
    }

    public void CloseBackgroundList()
    {
        if (!canvas.GetComponent<ModelMovement>().isMoving)
        {
            anim.CrossFade(animPointerOff, 0.1f);
        }
            
    }
}
