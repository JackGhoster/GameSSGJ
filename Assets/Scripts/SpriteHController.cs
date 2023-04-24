using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private SpriteRenderer _sRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_rb != null)
        {
            if(_rb.velocity.x < 0)
            {
                _sRenderer.flipX = true;
            }
            else
            {
                _sRenderer.flipX = false;
            }
        }
    }
}
