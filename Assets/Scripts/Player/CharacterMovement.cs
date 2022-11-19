using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController CC;

    [Header("Horizontal Component")]
    public float Speed;
    public float turnSmoothTime = 0.1f;
    float turnSmoothvelocity;
    float PlayerFacing;

    Vector3 moveDir;
    Vector3 direction;

    [Header("gravity & ground Component")]
    public float gravity;
    Vector3 Velocity;
    public Transform groundCheck;
    public float GroudDistance = 0.4f;
    public LayerMask groundMask;
    public bool IsGrounded;

    [Header("Breathing Component")]
    public bool needToBreath;
    public float AirCapacity;
    public float AirAdder;
    public float MaxAir;

    [Header("Heat Component")]
    public float HeatMeter;
    public float HeatAdder;
    public float MaxHeat;

    [Header("Branch Component")]
    public int AmountBranch;

    void Awake()
    {
        AirCapacity = MaxAir;
    }

    void Update()
    {

        //Horizontal Input...........................................

        float horizontalSpeed = Input.GetAxisRaw("Horizontal");
        direction = new Vector3(horizontalSpeed, 0, 0).normalized;

        if (horizontalSpeed >= 0)
        {
            moveDir = new Vector3 (Speed, 0f, 0f);
            PlayerFacing = 0f;
        }
        else
        {
            moveDir = new Vector3(-Speed, 0f, 0f);
            PlayerFacing = 180f;
        }

        if (direction.magnitude >= 0.1f)
        {
            float targerAngle = PlayerFacing;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targerAngle, ref turnSmoothvelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            CC.Move(moveDir.normalized * Speed * Time.deltaTime);
        }




        // Grounded Checking ..................................

        IsGrounded = Physics.CheckSphere(groundCheck.position, GroudDistance, groundMask);
        if (IsGrounded && Velocity.y < 0)
        {
            Velocity.y = -2f;
        }
        // gravity control ....................................
        else
        {
            Velocity.y += gravity * Time.deltaTime;
        }
        if (Velocity.y <= -3)
        {
            //playerGraph.SetBool("fall", true);
        }
        else
        {
           // playerGraph.SetBool("fall", false);
        }
        CC.Move(Velocity * Time.deltaTime);


        // Oxygen Capacity.......................................
        if (needToBreath)
        {
            if (AirCapacity >= 0)
            {
                AirCapacity -= AirAdder / 4 * Time.deltaTime;
            }
            else
            {
                Debug.Log("meninggal");
            }
            if (AirCapacity >= MaxAir)
            {
                Debug.Log("meninggal");
            }

            if (Input.GetButton("breath"))
            {
                if (AirCapacity <= MaxAir)
                {
                    AirCapacity += AirAdder * Time.deltaTime;
                }
            }
        }

        // Heat Capacity .................................................

        if(HeatMeter >= 0)
        {
            HeatMeter -= Time.deltaTime;
        }
        else
        {
            Debug.Log("meninggal");
        }

        if(HeatMeter >= MaxHeat)
        {
            HeatMeter = MaxHeat;
        }

        // breach component

        if (Input.GetButtonDown("BurnBrach"))
        {
            if (AmountBranch >= 1)
            {
                AddHeatMeter();
                AmountBranch -= 1;
            }
        }
    }


    public void AddHeatMeter()
    {
        HeatMeter += HeatAdder;
    }

    public void AddBreach()
    {
        AmountBranch += 1;
    }
}
