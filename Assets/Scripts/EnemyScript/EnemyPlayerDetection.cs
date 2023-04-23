using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerDetection : MonoBehaviour
{
    public EnemyMovement _e_M;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && GameManager.Instance.Hiding == false)
        {
            _e_M.state = 1;
        }
    }
}
