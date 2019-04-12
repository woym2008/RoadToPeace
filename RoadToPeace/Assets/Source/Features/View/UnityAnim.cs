using UnityEngine;
using System.Collections;

public class UnityAnim : MonoBehaviour, IAnim
{
    private Animator _animator;
     
    public void PlayAnim(string name)
    {
        if(_animator != null)
        {
            _animator.Play(name);
        }
    }

    private void Awake()
    {
        _animator = this.gameObject.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
