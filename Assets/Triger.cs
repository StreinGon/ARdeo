using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triger : MonoBehaviour {
    public GameObject Hobit;
    int i = 0;
    private void Update()
       
    {
        if (Hobit.activeInHierarchy == false)
        {
            i = 0;
        }
        if (Hobit.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("anim-2") && Input.touchCount == 1 && Input.touchCount < 2)

        {
            i = 1;

        }
        if (Input.touchCount == 1 && Input.touchCount < 2 && i > 0)
        {

            Hobit.GetComponent<Animator>().SetBool("Bool", true);
            Hobit.GetComponent<Animator>().SetBool("Bool2", true);
            Hobit.GetComponent<Animator>().SetBool("Bool3", true);
        }
        if(Input.touchCount == 1 && Input.touchCount < 2 && i == 0)
        {
            
            Hobit.GetComponent<Animator>().SetBool("Start", true);
        }
        if (Hobit.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("afk"))

        {
            Hobit.GetComponent<Animator>().SetBool("Bool2", false);
            Hobit.GetComponent<Animator>().SetBool("Bool", false);

        }
        if (Hobit.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("afk2"))

        {
            Hobit.GetComponent<Animator>().SetBool("Bool3", false);
            Hobit.GetComponent<Animator>().SetBool("Bool2", false);

        }
        if (Hobit.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("afk3"))

        {
            Hobit.GetComponent<Animator>().SetBool("Bool", false);
            Hobit.GetComponent<Animator>().SetBool("Bool3", false);

        }
        if (Hobit.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("afk2") && Input.touchCount == 1 && Input.touchCount < 2)

        {
            i = 1;

        }
    }
}
