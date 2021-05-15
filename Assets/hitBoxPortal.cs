using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBoxPortal : MonoBehaviour {
    public bool top;
    public PortalSpawnCheck psc;
	// Use this for initialization
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 13)
        {
            if (top)
            {
                psc.canPortalUP = true;
            }
            else if(!top)
            {
                psc.canPortalDown = true;
            }
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer==13)
        {
            if (top)
            {
                psc.canPortalUP = false;
            }
            else if(!top)
            {
                psc.canPortalDown = false;
            }
        }
    }
}
