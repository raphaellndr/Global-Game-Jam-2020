using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoDown : MonoBehaviour
{
    Vector2 downPosition;
    public GameObject down;

    // Start is called before the first frame update
    void Start()
    {
        downPosition = down.transform.position;
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            collider.transform.position = downPosition - Vector2.up + Vector2.right;
        }
    }
}
