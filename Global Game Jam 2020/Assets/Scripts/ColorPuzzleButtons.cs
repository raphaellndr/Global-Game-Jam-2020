using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPuzzleButtons : MonoBehaviour
{
    public static string correctCombination = "6215";
    public static string playerCombination = "";
    public static int totalDigits = 0;
    public ClickScript[] buttons;
    public Color[] colors;
    private float rdmR;
    private float rdmG;
    private float rdmB;
    // Start is called before the first frame update
    void Start()
    {
        rdmR = Random.Range(0.0f, 1.0f);
        rdmG = Random.Range(0.0f, 1.0f);
        rdmB = Random.Range(0.0f, 1.0f);
        Debug.Log(rdmR);
        Debug.Log(rdmG);
        Debug.Log(rdmB);
        if (buttons.Length == 0) Debug.Log("No button detected");
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<SpriteRenderer>().color = colors[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        activeColor();

    }

    public void activeColor()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].isSelected)
            {
                buttons[i].GetComponent<SpriteRenderer>().color = new Color(rdmR, rdmG, rdmB);
            }
            else
            {
                buttons[i].GetComponent<SpriteRenderer>().color = colors[i];
            }
        }

    }


}
