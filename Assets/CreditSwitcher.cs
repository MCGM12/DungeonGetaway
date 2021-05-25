using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CreditSwitcher : MonoBehaviour
{
    private static int nScreens = 5;
    public GameObject background;
    private static int swapCount = 0;

    public GameObject[] creditScreens = new GameObject[nScreens];
   

    private void Start()
    {
        for (int i = 0; i < nScreens; i++)
        {
            creditScreens[i].SetActive(false);
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            background.SetActive(false);
            //Toggle
            int currentScene = swapCount % nScreens;
            creditScreens[currentScene].SetActive(false);
            swapCount++;
            currentScene = swapCount % nScreens;
            creditScreens[currentScene].SetActive(true);
            Debug.Log(currentScene);
        }
    }
}
