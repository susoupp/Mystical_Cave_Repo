using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimTrigger : MonoBehaviour
{
    public Animator anim;
  

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Spider()
    {
         anim.SetTrigger("onStep");
         
    }
    public void ExitSpider()
    {
        anim.SetTrigger("ExitStep");
         
    }

}
