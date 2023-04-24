using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranpaScript : MonoBehaviour
{

    //[SerializeField]
    private Vector2 _value = new Vector2(190f,1);
    private float _speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeDirection", 2, 2);
        gameObject.GetComponent<Animator>().Play("Base Layer.grandpacrowRunning");
        EventManager.Instance.OnGameFinished += Happy;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, _value, _speed * Time.deltaTime);
    }

    private void ChangeDirection()
    {
        gameObject.GetComponent<SpriteRenderer>().flipX = !gameObject.GetComponent<SpriteRenderer>().flipX;
        _value.x = -1 * _value.x;
    }

    private void Happy()
    {
        CancelInvoke("ChangeDirection");
        gameObject.GetComponent<Animator>().Play("Base Layer.grandpacrowHappy");
    }
}
