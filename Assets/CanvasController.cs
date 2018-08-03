using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {
    public bool n1 = false;
    public bool n2 = false;
    public bool n3 = false;
    public GameObject n1b;
    public GameObject n2b;
    public GameObject n3b;
    int i = 0;
    // Update is called once per frame
    void Update () {
        if (n1)
        {
            n1b.SetActive(true);
            n2b.SetActive(false);
            n3b.SetActive(false);
            i = 0;
        }
        if (n2)
        {
            n1b.SetActive(false);
            n2b.SetActive(true);
            n3b.SetActive(false);
            i = 0;
        }
        if (n3)
        {
            n1b.SetActive(false);
            n2b.SetActive(false);
            n3b.SetActive(true);
            if (i == 0)
            {
                n3b.GetComponent<Animator>().Play("Fade");
                i = 1;
            }
        }
        if (n3b.activeInHierarchy == false)
        {
            i = 0;
        }

    }
}
