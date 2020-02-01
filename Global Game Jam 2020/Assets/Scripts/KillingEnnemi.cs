using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingEnnemi : MonoBehaviour
{
    public PressurePlate[] pressurePlates;
    public GameObject ennemi;

    // Update is called once per frame
    void Update()
    {
        if (pressurePlates[0].playerIsOnThePlate == true && pressurePlates[1].playerIsOnThePlate == true)
        {
            Destroy(ennemi);
        }
    }
}
