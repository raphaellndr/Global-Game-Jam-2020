using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingHint : MonoBehaviour
{

    private Vector2 initialPos;
    private Vector2 destination;

    private void Start()
    {
        initialPos = transform.position;
        destination = initialPos + new Vector2(0f, 0.1f);
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {

        transform.position = Vector2.MoveTowards(transform.position, destination, 0.2f/*vitesse*/ * Time.deltaTime);

        if ((Vector2)transform.position == destination)
        {
            if (destination == initialPos) destination = initialPos + new Vector2(0f, 0.1f);
            else destination = initialPos;
        }
    }
}
