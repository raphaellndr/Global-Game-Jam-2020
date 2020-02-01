using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchingPlayer : MonoBehaviour
{
    int numberOfPlayers = 2;

    public GameObject[] players;
    public PlayerController[] playersController;
    Transform followTarget;
    public bool player1IsActivated;

    public Rigidbody2D rb1;
    public Rigidbody2D rb2;

    public CinemachineVirtualCamera cam;

    // Start is called before the first frame update
    void Start()
    {
        followTarget = players[0].transform;
        cam.Follow = followTarget;

        //rb1 = players[0].GetComponent<Rigidbody2D>();
        //rb2 = players[1].GetComponent<Rigidbody2D>();

        rb1.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb2.constraints = RigidbodyConstraints2D.FreezePositionX;

        player1IsActivated = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && player1IsActivated == true)
        {
            rb1.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb2.constraints = RigidbodyConstraints2D.FreezeRotation;

            followTarget = players[1].transform;
            cam.Follow = followTarget;

            player1IsActivated = !player1IsActivated;
        }
        else if (Input.GetKeyDown(KeyCode.F) && player1IsActivated == false)
        {
            rb1.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb2.constraints = RigidbodyConstraints2D.FreezePositionX;

            followTarget = players[0].transform;
            cam.Follow = followTarget;

            player1IsActivated = !player1IsActivated;
        }        
        if (player1IsActivated == true && playersController[1].isGrounded == true)
        {
            rb2.constraints = RigidbodyConstraints2D.FreezePositionY;
            rb2.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
        if (player1IsActivated == false && playersController[0].isGrounded == true)
        {
            rb1.constraints = RigidbodyConstraints2D.FreezePositionY;
            rb1.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }

}
