using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingManager : MonoBehaviour
{
    [SerializeField]
    private Image _img;
    [SerializeField]
    private List<Sprite> _spriteList = new List<Sprite>();
    private int _index = 0;

    public void NextButtonPressed()
    {
        _index++;
        if (_index < _spriteList.Count)
        {
            _img.sprite = _spriteList[_index];
        }
        else
        {
            SceneManager.LoadScene("MenuScene");
        }
    }

}
