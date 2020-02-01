using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformeAR : ActiveObject
{

    private bool moving;
    private Vector2 initialPos;
    private Vector2 destination;

    private void Start()
    {
        initialPos = transform.position;
        destination = initialPos + new Vector2(0.5f, 0f);
    }

    void Update()
    {
        if (State) Move();
    }

    public void switchDestination()
    {
        if (!State) State = true;
        
        else destination = initialPos;
    }

    private void Move()
    {

        transform.position = Vector2.MoveTowards(transform.position, destination, 1/*vitesse*/ * Time.deltaTime);

        if ((Vector2)transform.position == destination)
        {
            if (destination == initialPos) destination = initialPos + new Vector2(0.5f, 0f);
            else destination = initialPos;
        }
    }
}
