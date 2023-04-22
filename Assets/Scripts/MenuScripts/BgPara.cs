using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class BgPara : MonoBehaviour
{
    private Vector2 _pos;
    private Vector2 _startPos = Vector2.zero;

    public Vector2 Min_pos;
    public Vector2 Max_pos;


    public float diff;

    private void Start()
    {
        transform.position = _startPos;
    }

    private void Update()
    {
        var  pos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        transform.position = -pos;
        var _pos_n = new Vector2(_startPos.x - (pos.x/10 * diff), _startPos.y - (pos.y/10 * diff));
        var m_x = 0f;
        var m_y = 0f;

        if (_pos_n.x > Max_pos.x)
        {
             m_x = Max_pos.x;
        }
        else if(_pos_n.x < Min_pos.x)
        {
            m_x = Min_pos.x;
        }
        else 
        {
            m_x = _pos_n.x;
        }

        if(_pos_n.y > Max_pos.y)
        {
            m_y = Max_pos.y;
        }
        else if (_pos_n.y<Min_pos.y)
        {
            m_y = Min_pos.y;
        }
        else 
        {
            m_y = _pos_n.y;
        }
        
        transform.position = new Vector2(m_x, m_y);
    }
}
