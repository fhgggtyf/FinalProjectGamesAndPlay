using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AnimationController
{
    Animator _ctxAnim;

    string _currentAnim = "";

    public void SetAnim(Animator anim)
    {
        _ctxAnim = anim;
    }

    public void SetAnim(string animBool)
    {
        if (_currentAnim != animBool)
        {
            _currentAnim = animBool;
            _ctxAnim.Play(animBool);
        }

    }

    public string GetCurrentAnim()
    {
        return _currentAnim;
    }


    public bool IsAnimFinished()
    {
        return _ctxAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1;
    }


}
