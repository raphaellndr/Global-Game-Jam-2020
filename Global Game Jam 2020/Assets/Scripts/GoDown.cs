using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoDown : MonoBehaviour
{
    Vector2 upPosition;
    public GameObject up;

    // Start is called before the first frame update
    void Start()
    {
        upPosition = up.transform.position;
    }

    IEnumerator detectKey(GameObject player)
    {
        while (1 == 1)
        {
            if (Input.GetKeyDown(KeyCode.E) && player.tag == "Player")
            {
                player.transform.position = upPosition - Vector2.up;
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
