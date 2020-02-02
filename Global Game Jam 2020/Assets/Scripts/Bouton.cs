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

    IEnumerator detectKey(GameObject player)
    {
        while (1==1) {
            if (Input.GetKeyDown(KeyCode.E) && job == player.GetComponent<PlayerController>().job && job == !GameObject.Find("Canvas").GetComponent<SwitchingPlayer>().player1IsActivated)
            {
                switchState();
                foreach (ActiveObject l in Link)
                {
                    l.switchState();
                }
            }
            yield return new WaitForSeconds(0.0005f);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactIcone.SetActive(true);
        StartCoroutine("detectKey",collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactIcone.SetActive(false);
        StopCoroutine("detectKey");
    }
}
