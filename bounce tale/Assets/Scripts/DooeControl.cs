using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DooeControl : MonoBehaviour
{
    static public Animator anim;
    void Start()
    {
        anim=GetComponent<Animator>();
    }
    
    static public void ToggleDoor()
    {
        anim.SetTrigger("open");
    }

}
