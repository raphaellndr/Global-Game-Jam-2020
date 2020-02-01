using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformeAR : ActiveObject
{

    private bool moving;
    private Vector2 initialPos;
    private Vector2 destination;

    [SerializeField]
    private float mouvementX;   //le mouvement en X

    [SerializeField]
    private float mouvementY;   //le mouvement en Y

    private void Start()
    {
        initialPos = transform.position;
        destination = initialPos + new Vector2(mouvementX, mouvementY);
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
            if (destination == initialPos) destination = initialPos + new Vector2(mouvementX, mouvementY);
            else destination = initialPos;
        }
    }
}
