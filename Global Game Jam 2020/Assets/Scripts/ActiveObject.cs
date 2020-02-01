using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveObject : MonoBehaviour
{
    [SerializeField]
    private bool state;     //état de l'objet

    public bool State
    {
        get { return state; }
        set { state = value; }
    }

    [SerializeField]
    private Sprite [] skin;   //la liste des skins, dépend de la valeur de state

    [SerializeField]
    private ActiveObject [] link;   //les autres objets qui sont reliés à celui-ci

    public ActiveObject [] Link
    {
        get { return link; }
    }

    public void switchSkin()
    {
        if (skin.Length > 1)
        {
            if (!state)
            {
                transform.GetComponent<SpriteRenderer>().sprite = skin[0];
            }
            else
            {
                transform.GetComponent<SpriteRenderer>().sprite = skin[1];
            }
        }
    }

    public virtual void switchState()
    {
        state = !state;
        switchSkin();
    }

    public virtual void switchState(bool ChoosenState)
    {
        state = ChoosenState;
        switchSkin();
    }

    public virtual void checkConditions()
    {
        return;
    }
}
