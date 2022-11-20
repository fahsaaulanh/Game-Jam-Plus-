using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CutSceneStory : MonoBehaviour
{
    public GameObject parent;
    public Sprite[] theImage;
    public int onPage;
    public Image ImageOnUI;

    public TextMeshProUGUI dialogue;
    public string[] textnya;

    public int LastPage;

    void Awake()
    {
        onPage = 1;
        ImageOnUI.sprite = theImage[onPage];
        dialogue.text = textnya[onPage];
    }
    public void Start()
    {
        onPage = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnClickEvent();
        } 
    }
    public void OnClickEvent()
    {
        if (onPage <= LastPage-1)
        {
            onPage += 1;
            ImageOnUI.sprite = theImage[onPage];
            dialogue.text = textnya[onPage];
        }
        else
        {
            parent.SetActive(false);
        }
    }
}
