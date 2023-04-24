using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    public GameObject Im1;
    public GameObject Im2;
    public GameObject Im3;
    public GameObject Im4;
    public GameObject Im5;

    private int r = 1;

    private void Start()
    {
        Im1.SetActive(true);
        Im2.SetActive(false);
        Im3.SetActive(false);
        Im4.SetActive(false);
        Im5.SetActive(false);
    }

    public void rightButtonClicked()
    {
        if (r == 1) 
        {
            r++;
            Im1.SetActive(false);
            Im2.SetActive(true);
            Im3.SetActive(false);
            Im4.SetActive(false);
            Im5.SetActive(false);
        }
        else if(r == 2) 
        {
            r++;
            Im1.SetActive(false);
            Im2.SetActive(false);
            Im3.SetActive(true);
            Im4.SetActive(false);
            Im5.SetActive(false);
        }
        else if(r == 3) 
        {
            r++;
            Im1.SetActive(false);
            Im2.SetActive(false);
            Im3.SetActive(false);
            Im4.SetActive(true);
            Im5.SetActive(false);
        }
        else if(r == 4)
        {
            r++;
            Im1.SetActive(false);
            Im2.SetActive(false);
            Im3.SetActive(false);
            Im4.SetActive(false);
            Im5.SetActive(true);
        }
        else if(r ==5) 
        {
            r = 1;
            Im1.SetActive(true);
            Im2.SetActive(false);
            Im3.SetActive(false);
            Im4.SetActive(false);
            Im5.SetActive(false);
        }
    }
    public void leftButtonClicked()
    {
        if (r == 1)
        {
            r = 5;
            Im1.SetActive(false);
            Im2.SetActive(false);
            Im3.SetActive(false);
            Im4.SetActive(false);
            Im5.SetActive(true);
        }
        else if (r == 2)
        {
            r--;
            Im1.SetActive(true);
            Im2.SetActive(false);
            Im3.SetActive(false);
            Im4.SetActive(false);
            Im5.SetActive(false);
        }   
        else if (r == 3)
        {
            r--;
            Im1.SetActive(false);
            Im2.SetActive(true);
            Im3.SetActive(false);
            Im4.SetActive(true);
            Im5.SetActive(false);
        }
        else if (r == 4)
        {
            r--;
            Im1.SetActive(false);
            Im2.SetActive(false);
            Im3.SetActive(true);
            Im4.SetActive(false);
            Im5.SetActive(false);
        }
        else if (r == 5)
        {
            r--;
            Im1.SetActive(false);
            Im2.SetActive(false);
            Im3.SetActive(false);
            Im4.SetActive(true);
            Im5.SetActive(false);
        }
    }
}
