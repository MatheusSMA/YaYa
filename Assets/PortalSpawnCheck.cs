using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawnCheck : MonoBehaviour {
    public bool canPortalUP;
    public bool canPortalDown;
    public GameObject portal;
    public bool right;

    // Use this for initialization
	// Update is called once per frame
	void Update () {

        if (canPortalUP && canPortalDown)
        {
            portal.transform.position = transform.position;
            portal.SetActive(true);
            portal.GetComponent<PortalBehaviour>().right = right;
        }
       
        
	}
    public void Clean() {
        canPortalDown = false;
        canPortalUP = false;
        right = false;
    }
}
