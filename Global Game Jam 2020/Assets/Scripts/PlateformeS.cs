using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformeS : ActiveObject
{

    private bool moving;
    private Vector2 initialPos;
    private Vector2 destination;

    private void Start()
    {
        moving = false;
        initialPos = transform.position;
    }

    void Update()
    {
        if (moving) Move();
    }

    public void switchDestination()
    {
        if (!moving) moving = true;
        if (State) destination = initialPos + new Vector2(0.5f, 0f);
        else destination = initialPos;
    }

    private void Move()
    {

        transform.position = Vector2.MoveTowards(transform.position, destination, 1/*vitesse*/ * Time.deltaTime);

        if ((Vector2)transform.position == destination)
        {
            moving = !moving;
        }
    }

    public override void switchState()
    {
        base.switchState();
        switchDestination();
    }

    public override void switchState(bool ChoosenState)
    {
        base.switchState(ChoosenState);
        switchDestination();
    }

}
