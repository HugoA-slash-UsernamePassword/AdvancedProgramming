using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    public GameObject weapon;
    public int range = 3;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private float knifeMove;
    private bool isAttacking;
    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Hit
        //}
        //if (isAttacking)
        //{

        //}
        if (Input.GetKeyDown(KeyCode.Mouse0) && isAttacking == false)
        {
            isAttacking = true;
        }
        if (isAttacking)
        {
            float distanceMove = Mathf.Sin(knifeMove);
            weapon.transform.localPosition = (distanceMove * range + 1) * Vector3.forward;
            knifeMove += Mathf.PI * Time.deltaTime * 1.6f;
            //Debug.Log(knifeMove);
            if(knifeMove >= Mathf.PI)
            {
                knifeMove = 0;
                isAttacking = false;
            }
        }
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump")) moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
