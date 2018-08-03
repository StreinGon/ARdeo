using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Vid : MonoBehaviour {
    public bool playS=false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (playS)
        {
            this.gameObject.GetComponent<VideoPlayer>().Play();
            this.gameObject.GetComponent<AudioSource>().enabled=true;
        }
        else
        {
            this.gameObject.GetComponent<VideoPlayer>().Stop();
           this.gameObject.GetComponent<AudioSource>().enabled = false;
        }
	}
}
