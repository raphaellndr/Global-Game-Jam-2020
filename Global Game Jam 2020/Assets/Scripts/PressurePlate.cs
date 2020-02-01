using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool playerIsOnThePlate = false;

    void OnTriggerEnter2D()
    {
        playerIsOnThePlate = !playerIsOnThePlate;
    }

    void OnTriggerExit2D()
    {
        playerIsOnThePlate = !playerIsOnThePlate;
    }
}
