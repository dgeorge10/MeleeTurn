using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectGems : MonoBehaviour
{

    public InputField input;
    public static int Gems = 10;

    //   private void Awake()
    //   {
    //       input = GameObject.Find("GemInput").GetComponent<InputField>();

    //}
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public void GetInput(string gems)
    {
        Debug.Log("You entered " + gems);
        input.text = "";
        if (Int32.Parse(gems) > 20)
        {
            input.text = "Too many gems!";
        }
        else if (Int32.Parse(gems) <= 0)
        {
            input.text = "Not enough gems!";
        }
        else
        {
            input.text = "Current game set to " + gems + " gems!";
            Gems = Int32.Parse(gems);
            Debug.Log(Gems);
        }
    }
}