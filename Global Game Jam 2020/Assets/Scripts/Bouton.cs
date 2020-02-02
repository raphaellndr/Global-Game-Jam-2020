using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouton : ActiveObject
{
    public bool job; //false>mécano         true>scientifique
    void OnMouseDown()
    {
        switchState();
        foreach(ActiveObject l in Link)
        {
            l.switchState();
        }
    }


}
