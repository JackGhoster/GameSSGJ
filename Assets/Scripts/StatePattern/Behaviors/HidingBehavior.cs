using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingBehavior : MonoBehaviour
{
    [SerializeField]
    private Minigame _minigame;
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        //print("SNEAKY");
        _animator.Play("Base Layer.playerEnteringHiding");
        Invoke("StartMinigame", 0.7f);
    }
    private void OnDisable()
    {
    }
    private void StartMinigame()
    {
        Instantiate(_minigame);
    }
}
