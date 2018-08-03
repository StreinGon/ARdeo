using System;
using System.Collections;
using UnityEngine.EventSystems;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RotateNew : MonoBehaviour//, IPointerClickHandler, IDragHandler, IBeginDragHandler
{
    public bool rotate = false;
    public GameObject map;
    private float speed = .1f;
    private float fl = 30;

    public void OnMouseDown()
    {

        rotate = true;
    }
    public void OnMouseUp()
    {

        rotate = false;
    }

    private bool canRotate = false;

    private Vector2 _t0;
    private Vector3 prevPos;

    float coord;
    private Vector2 prevTPos;
    private Quaternion _initialRotation;

    int k = -1;

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            prevPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
         
            Vector3 mouseDelta = Input.mousePosition - prevPos;
 
            coord = k * mouseDelta.x / fl * Screen.currentResolution.width * 0.002f;

            if (rotate == false)
            {

                map.transform.Rotate(new Vector3(0, -mouseDelta.x / fl * 2.2f, 0));
            }



            prevPos = Input.mousePosition;

        }
#else
		/*if(Input.touchCount == 1){
			Touch touch = Input.GetTouch(0);
			
			switch(Input.GetTouch(0).phase){
			case TouchPhase.Began:
				if(VerifyTouch(touch))
					canRotate = true;
				break;
			case TouchPhase.Moved:
				if(canRotate)
					rotateGameObject(touch);
				break;
			case TouchPhase.Ended:
				canRotate = false;
				break;
			case TouchPhase.Canceled:
				canRotate = false;
				break;
			}
		}*/
		if(Input.touchCount == 1){
			Touch touch = Input.GetTouch(0);
			switch(Input.GetTouch(0).phase){
			case TouchPhase.Began:
				prevTPos = Input.GetTouch(0).position;
				break;
			case TouchPhase.Moved:
				Vector2 touchDelta = touch.deltaPosition;
					if(map.transform.rotation.y<-0.7f) {
					k=1;

					}
					if(map.transform.rotation.y>-0.7f) {
					k=-1;

					}
					if(map.transform.rotation.y>0.7f) {
					k=1;

					}
					if(rotate==false){
						map.transform.Rotate(new Vector3(0, -touchDelta.x/fl*2.2f, 0));
					}

				
			

				prevTPos = Input.GetTouch(0).position;
				break;
			
			case TouchPhase.Ended:
			case TouchPhase.Canceled:
				prevTPos = Input.GetTouch(0).position;
				break;
			}
		}
#endif
    }

    public bool CanRotate
    {
        get { return canRotate; }
        set { canRotate = value; }
    }

    bool VerifyTouch(Touch touch)
    {
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == this.gameObject)
            {
                return true;
            }
        }
        return false;
    }

    //	void rotateGameObject(Touch touch){
    //		//this.transform.Rotate(new Vector3(0,-touch.deltaPosition.x,0) * speed,Space.World);	
    //
    //			if (rotate==false) {
    //				map.transform.Rotate (new Vector3 (0, -touch.deltaPosition.x/fl, 0));
    //			} else {
    //				
    //				clubeHouse.transform.localEulerAngles=new Vector3(clubeHouse.transform.localEulerAngles.x,clubeHouse.transform.localEulerAngles.y,-touch.deltaPosition.x/fl);
    //
    //			}
    //	}

    public void getRotation()
    {
        _initialRotation = this.transform.rotation;
    }

    public void reset()
    {
        this.transform.rotation = _initialRotation;
    }

}
