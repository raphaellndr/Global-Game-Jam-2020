using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleConditions : ActiveObject
{
    [SerializeField]
    private bool[] combination;   //la combinaison à mettre en entré pour activer la sortie

    [SerializeField]
    private ActiveObject[] output;   //les autres objets qui sont commandés par cet objet

    public ActiveObject[] Output
    {
        get { return output; }
    }
    public override void checkConditions()
    {
        int nbOfValidCondition = 0;
        for (int i = 0; i < Link.Length; i++)
        {
            if (Link[i].State && combination[i]) nbOfValidCondition++;
        }
        if (nbOfValidCondition == Link.Length)
        {
            switchState();
            foreach (ActiveObject l in output)
            {

                l.switchState();
            }
        }
        else
        {
            State = false;
            foreach (ActiveObject l in output)
            {
                l.switchState(false);
            }
        }
    }

}
