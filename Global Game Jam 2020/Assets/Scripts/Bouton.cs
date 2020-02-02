using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouton : ActiveObject
{
    public bool job; //false>mécano         true>scientifique
    
    [SerializeField]
    public GameObject interactIcone;

    void Start()
    {
        interactIcone = Instantiate(interactIcone);
        interactIcone.transform.position = transform.position + new Vector3(0f, 1.5f, 0f);
        interactIcone.SetActive(false);
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        switchState();
        foreach(ActiveObject l in Link)
        {
            l.switchState();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactIcone.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactIcone.SetActive(false);
    }
}
