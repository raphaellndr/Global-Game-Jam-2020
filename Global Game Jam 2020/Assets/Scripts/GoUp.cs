using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoUp : MonoBehaviour
{
    Vector2 upPosition;
    public GameObject up;

    // Start is called before the first frame update
    void Start()
    {
        upPosition = up.transform.position;
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            collider.transform.position = upPosition - Vector2.up + Vector2.right;
        }
    }
}
