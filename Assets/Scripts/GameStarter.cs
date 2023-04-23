using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script is only in the main scene and it starts the global stopwatch
/// </summary>
public class GameStarter : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartGame", 0.5f);   
    }

    private void StartGame()
    {
        EventManager.Instance.GameStarted();
    }

}
