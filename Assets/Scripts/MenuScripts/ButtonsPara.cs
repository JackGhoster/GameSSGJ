using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsPara : MonoBehaviour
{
    //This works almost exactly as the bg without the if statement because these buttons can't be outside the window. 
    
    private Vector2 _pos;
    private Vector2 _startPos;

    public float diff;


    private void Start()
    {
        //The start positon will be the position that I have set.
        _startPos = transform.position;
    }

    void Update()
    {
        //Just the same code as BgPara.cs
        var pos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        transform.position = pos;
        transform.position = new Vector2(_startPos.x + (pos.x * diff), _startPos.y + (pos.y + diff));
    }
}
