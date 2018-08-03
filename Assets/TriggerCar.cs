using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCar : MonoBehaviour
{
    public GameObject car;
    Vector3 prevTPos;
    Vector3 prevPos;
    // Update is called once per frame
    void Update()
    {
        if (car.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("stayReplay"))
        {
            car.GetComponent<Animator>().SetBool("bll", false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            prevPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {

            Vector3 mouseDelta = Input.mousePosition - prevPos;


            if (mouseDelta.x > 0 && Input.mousePosition != prevPos && Input.mousePosition != null)
            {

                car.GetComponent<Animator>().SetBool("bll", true);
                car.GetComponent<Animator>().SetFloat("fl", 1.0f);


            }
            if (mouseDelta.x < 0 && Input.mousePosition != prevPos && Input.mousePosition != null)
            {
                car.GetComponent<Animator>().SetFloat("fl", -1.0f);

            }
            if (Input.mousePosition == prevPos)
            {
                car.GetComponent<Animator>().SetFloat("fl", 0.0f);

            }



            prevPos = Input.mousePosition;

        }
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            switch (Input.GetTouch(0).phase)
            {
                case TouchPhase.Began:
                    prevTPos = Input.GetTouch(0).position;
                    break;
                case TouchPhase.Moved:
                    Vector2 touchDelta = touch.deltaPosition;
                    prevTPos = Input.GetTouch(0).position;
                    if (touch.deltaPosition.x > 0 && touch.deltaPosition.x != prevTPos.x)
                    {

                        car.GetComponent<Animator>().SetBool("bll", true);
                        car.GetComponent<Animator>().SetFloat("fl", 1.0f);
                    }
                    if (touch.deltaPosition.x < 0 && touch.deltaPosition.x != prevTPos.x)
                    {
                        car.GetComponent<Animator>().SetFloat("fl", -1.0f);
                    }
                    if (touch.deltaPosition.x == prevTPos.x)
                    {
                        car.GetComponent<Animator>().SetFloat("fl", 0.0f);

                    }

                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    prevTPos = Input.GetTouch(0).position;
                    break;
            }
            //Debug.Log(Input.touchCount);
            if (istouch()==false)
            {
                
                 Debug.Log("0 tch");
                car.GetComponent<Animator>().SetFloat("fl", 0.0f);

            }
        }
        //car.GetComponent<Animator>().SetFloat("fl", 0.0f);
    }
    public bool istouch()
    {

        foreach (Touch __touch in Input.touches)
        {

            if (__touch.phase == TouchPhase.Moved || __touch.phase == TouchPhase.Began)
            {
                return
                    true;
            }
        }

        return
            false;
    }
}
