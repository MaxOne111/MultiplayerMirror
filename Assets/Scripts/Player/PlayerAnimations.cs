using Mirror;
using UnityEngine;

public class PlayerAnimations : NetworkBehaviour
{
    private Animator _animator;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void MovementAnimation(bool isRunning)
    {
        if (isRunning)
            _animator.SetBool("IsRun", true);
        else
            _animator.SetBool("IsRun", false);
    }
    
}