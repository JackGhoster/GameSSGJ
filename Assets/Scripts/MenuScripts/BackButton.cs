using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class BackButton : MonoBehaviour
{
    public void Clicked()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
