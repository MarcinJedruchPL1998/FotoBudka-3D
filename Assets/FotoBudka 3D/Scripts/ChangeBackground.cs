using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeBackground : MonoBehaviour
{
    [SerializeField] private Button[] backgroundBtns;
    [SerializeField] private Sprite[] backgrounds;
    [SerializeField] private Image background;

    void Start()
    {
        backgroundBtns[0].onClick.AddListener(() => ToggleBackground(0));
        backgroundBtns[1].onClick.AddListener(() => ToggleBackground(1));
        backgroundBtns[2].onClick.AddListener(() => ToggleBackground(2));
    }

    public void ToggleBackground(int backgroundNumber)
    {
        background.sprite = backgrounds[backgroundNumber];
    }
   
}
