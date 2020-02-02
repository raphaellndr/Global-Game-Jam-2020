using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoDown : MonoBehaviour
{
    Vector2 downPosition;
    public GameObject down;

    // Start is called before the first frame update
    void Start()
    {
        downPosition = down.transform.position;
    }

    IEnumerator detectKey(GameObject player)
    {
        while (1 == 1)
        {
            if (Input.GetKeyDown(KeyCode.E) && player.tag == "Player")
            {
                player.transform.position = downPosition - Vector2.up;
            }
            yield return new WaitForSeconds(0.0005f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine("detectKey", collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopCoroutine("detectKey");
    }
}
