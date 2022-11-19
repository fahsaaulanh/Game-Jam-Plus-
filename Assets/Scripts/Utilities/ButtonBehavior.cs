using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
    public static UnityAction OnClickButton;
    Button _button;
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener( OnClickButton);
    }


    void Update()
    {
        
    }
}
