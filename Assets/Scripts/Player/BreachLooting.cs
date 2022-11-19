using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreachLooting : MonoBehaviour
{
    [Header("gravity & ground Component")]
    public Transform PlayerCheck;
    public float Playerdistance = 0.4f;
    public LayerMask PlayerMask;
    public bool IsDetect;

    void Update()
    {
        IsDetect = Physics.CheckSphere(PlayerCheck.position, Playerdistance, PlayerMask);

        if (IsDetect)
        {
            FindObjectOfType<CharacterMovement>().AddBreach();
            Destroy(this.gameObject);
        }
    }
}
