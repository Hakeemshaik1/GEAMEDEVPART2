using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 7;
    public float leftRightspeed = 4;
    static public bool canMove = false;
    public bool isJumping = false;
    public bool comingDown = false;
    public GameObject playerObject;

    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * Vector3.forward, Space.World);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > Levelboundry.leftSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightspeed);
            }

        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < Levelboundry.rightside)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightspeed * -1);
            }
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (isJumping == false)
            {
                isJumping = true;
                playerObject.GetComponent<Animator>().Play("Jump");
                StartCoroutine(jumpSequance());
            }
        }

        if (isJumping == true)
        {
            if (comingDown == false)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 4, Space.World);
            }
            if (comingDown == true)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -4, Space.World);
            }
        }
    }
    IEnumerator jumpSequance()
    {
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(0.45f);
        isJumping = false;
        comingDown = false;
        playerObject.GetComponent<Animator>().Play("Standard Run");
    }


}

