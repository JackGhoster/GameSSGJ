using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryUI : MonoBehaviour
{

    public void BackButtonClicked()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
