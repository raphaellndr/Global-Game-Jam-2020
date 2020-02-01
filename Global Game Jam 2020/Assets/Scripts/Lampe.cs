using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lampe : ActiveObject
{
    public override void switchState()
    {
        base.switchState();
        //Debug.Log("Etat de la lampe:" + State);
        if(Link.Length>0)
        {
            foreach (ActiveObject l in Link)
            {
                l.checkConditions();
            }
        }
    }
}
