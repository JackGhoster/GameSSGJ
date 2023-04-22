using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class BgPara : MonoBehaviour
{
    //This is the start pos of the Bg. Which will be zero as we want it to start in the centre of the screen. 
    private Vector2 _startPos = Vector2.zero;

    //These variable will tell the minimum and maximum postion the Bg can go to because we don't want to show that default blue unity color to anyone.
    public Vector2 Min_pos;
    public Vector2 Max_pos;

    //This variable is to tell how much the image move.2,4,6 works best for me. try changing and tell me what you think
    public float diff;

    //We makes the starting pos at the centre of the screen.
    private void Start()
    {
        transform.position = _startPos;
    }

    private void Update()
    {
        //first we see where is the mouse on the screen of the game.
        var  pos = Camera.main.ScreenToViewportPoint(InputManager.Instance.MousePos);
        //I wanted the image to move in the oposite dir of the mouse that's why it is -pos here.
        //this give the effect of the parallax
        transform.position = -pos;

        //Then I make this variable basically calculating where the image will be.
        var _pos_n = new Vector2(_startPos.x - (pos.x * diff), _startPos.y - (pos.y * diff));

        //These variable full form is main_x position of the image and main_y positiong of the image.
        var mX = 0f;
        var mY = 0f;

        //Now we sees that if the image will be outside of the window.
        if (_pos_n.x > Max_pos.x)
        {
             mX = Max_pos.x;
        }
        // same as before
        else if(_pos_n.x < Min_pos.x)
        {
            mX = Min_pos.x;
        }
        //If the image will not be outside of the window then the main_x will be _pos_n
        else 
        {
            mX = _pos_n.x;
        }

        //Same thing for the y axis
        if(_pos_n.y > Max_pos.y)
        {
            mY = Max_pos.y;
        }
        else if (_pos_n.y<Min_pos.y)
        {
            mY = Min_pos.y;
        }
        else 
        {
            mY = _pos_n.y;
        }
        
        //Now finally our image will be moved. If this can be optimized, just hit me in my Dm.
        transform.position = new Vector2(mX, mY);
    }
}
