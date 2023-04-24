using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerDetection : MonoBehaviour
{
    public EnemyMovement _e_M;
    Collider2D _collider;
    
    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }
    private void Start()
    {
        InvokeRepeating("RecastCollider2D", 0.5f, 0.5f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (GameManager.Instance.Hiding == true) return;
        if (col.gameObject.tag == "Player")
        {
            _e_M.state = 1;
        }
    }

    private void RecastCollider2D()
    {
        _collider.enabled = false;
        _collider.enabled = true;
    }
}