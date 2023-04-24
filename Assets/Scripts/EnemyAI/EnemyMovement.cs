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

    private Animator _animator;
    [SerializeField]
    private AudioSource _walkingSound;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        //_walkingSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, _pos[index], Time.deltaTime * _speed);
            _animator.SetTrigger("Run");
            //_walkingSound.Play();
            if (transform.position.x == _pos[index].x && transform.position.y == _pos[index].y)
            {
                if (k == 0)
                {
                    transform.localRotation = Quaternion.Euler(0, -180, 0);
                    k = 1f;
                    _animator.ResetTrigger("Run");
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
        else if (state == 1)
        {
            Debug.Log("Agri boi!!! caught");
            _animator.SetTrigger("Angry");
            EventManager.Instance.GameLost();
            state++;
        }
    }


    IEnumerator WaitFiveSeconds()
    {
        state = 2;
        _animator.SetTrigger("Idle");
        
        yield return new WaitForSecondsRealtime(_waitTime);
        state = 0;
        _animator.ResetTrigger("Idle");
    }
}