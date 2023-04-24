using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlingBehavior : MonoBehaviour
{
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //print("I am currently Idling");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        _animator.Play("Base Layer.playerIdle");
    }
}
