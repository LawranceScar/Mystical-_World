using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateScript : MonoBehaviour
{
    public Animator MyAnimator;

    public bool IsActiveIdle = true;


    // Update is called once per frame
    void Update()
    {
      //  IdleAnimation(IsActiveIdle);
    }

    public void IdleAnimation(bool IsActive)
    {
        MyAnimator.SetBool("Idle", IsActive);
    }

    public void AttackOneAnimation()
    {
        MyAnimator.SetTrigger("Attack1");
    }

    public void RunAnimation(bool IsActive)
    {
        MyAnimator.SetBool("Run Forward", IsActive);
    }

    public void WalkAnimation(bool IsActive)
    {
        MyAnimator.SetBool("WalkForward", IsActive);
    }
}
