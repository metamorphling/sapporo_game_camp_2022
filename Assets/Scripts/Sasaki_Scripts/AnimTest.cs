using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTest : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetBool("IsAttack", true);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.SetBool("IsAttack", false);
        }
    }
}
