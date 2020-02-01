using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouton : ActiveObject
{

    void OnMouseDown()
    {
        switchState();
        foreach(ActiveObject l in Link)
        {
            l.switchState();
        }
    }


}
