using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsPara : MonoBehaviour
{
    private Vector2 _pos;
    private Vector2 _startPos;

    public float diff;


    private void Start()
    {
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        transform.position = pos;
        transform.position = new Vector2(_startPos.x + (pos.x * diff), _startPos.y + (pos.y + diff));
    }
}
