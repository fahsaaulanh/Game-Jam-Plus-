using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class player_debug : MonoBehaviour
{
    public UnityEvent afterTag;
    public void OnTriggerEntered()
    {
            afterTag.Invoke();
            Debug.Log("to be continue");
    }
}
