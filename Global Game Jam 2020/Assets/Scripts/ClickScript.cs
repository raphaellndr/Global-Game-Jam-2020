
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : ActiveObject 
{
    public static string correctCombination = "6215";
    public static string playerCombination = "";
    public static int totalDigits = 0;
    public bool isSelected = false;
    public bool isTrue = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerCombination);
        if (totalDigits == 4)
        {
            if (playerCombination == correctCombination)
            {
                Debug.Log("Correct");
                isTrue = true;
            }
            else
            {
                playerCombination = "";
                totalDigits = 0;
                Debug.Log("Wrong Combination");
            }
        }

        
    }

    private void OnMouseUp()
    {
        playerCombination += gameObject.name;
        totalDigits += 1;
        isSelected = false;
    }
    private void OnMouseDown()
    {
        isSelected = true;
        if (isTrue)
        {
            switchState();
            foreach (ActiveObject l in Link)
            {
                l.switchState();
            }
        }
    }

    
}   