using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouton : ActiveObject
{
    public bool job; //false>mécano         true>scientifique

    void OnTriggerStay2D(Collider2D collider)
    {
        if (job == collider.gameObject.GetComponent<PlayerController>().job && job == !GameObject.Find("Canvas").GetComponent<SwitchingPlayer>().player1IsActivated)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                switchState();
                foreach (ActiveObject l in Link)
                {
                    l.switchState();
                }
            }
        }
    }

    /*void OnMouseDown()
    {
        
    }*/


}
