using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    /// <summary>
    /// This code basically takes an array of positions and moves towards the postion.
    /// </summary>
    public float _speed;
    public float _waitTime;
    public Vector2[] _pos;

    private int index;

    private float k = 0;
    public float state = 0;

    private IEnumerator coroutine;

    // Update is called once per frame
    void Update()
    {
        if (state == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, _pos[index], Time.deltaTime * _speed);
            if (transform.position.x == _pos[index].x && transform.position.y == _pos[index].y)
            {
                if (k == 0) 
                { 
                    transform.localRotation = Quaternion.Euler(0, -180, 0);
                    k = 1f;
                    StartCoroutine("WaitFiveSeconds");
                }
                else if (k == 1)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                    k = 0f;
                }

                if (index == _pos.Length - 1) { index = 0; }
                else { index++; }
            }
        }
        else if(state == 1) 
        {
            Debug.Log("Agri boi!!! caught");
            state++;
        }
    }


    IEnumerator WaitFiveSeconds()
    {
        state = 2;
        yield return new WaitForSecondsRealtime(_waitTime);
        state = 0;
    }
}
