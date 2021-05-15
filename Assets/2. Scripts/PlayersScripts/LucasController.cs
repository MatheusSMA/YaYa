using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucasController : PlayerController
{
    RaycastHit2D rh;
    [Header("Portals")]
    public GameObject portal1;
    public GameObject portal2;
    public PortalSpawnCheck portalCheck1;
    public PortalSpawnCheck portalcheck2;
	// Use this for initialization
	void Start () {
        base.Start();
	}

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if(isMoving){
            if (Input.GetKeyDown(KeyCode.R))
            {
                portalCheck1.gameObject.SetActive(false);
                portalcheck2.gameObject.SetActive(false);
                portal1.SetActive(false);
                portal2.SetActive(false);
            }
        if (Input.GetMouseButtonDown(0))
        {
            ThrowRay();
            if (rh.collider != null)
                {
                    if (!portalcheck2.gameObject.activeInHierarchy ||( portalcheck2.gameObject.activeInHierarchy&& Vector2.Distance(portalcheck2.transform.position, rh.point) > 2))
                    {
                        portalCheck1.Clean();
                        portalCheck1.gameObject.transform.position = rh.point;
                        portalCheck1.gameObject.SetActive(true);
                        checkSide(portalCheck1); ;
                    }                                                           
                }

        }
         if (Input.GetMouseButtonDown(1))
        {
            ThrowRay();
            if (rh.collider != null)
                {
                    if (!portalCheck1.gameObject.activeInHierarchy || (portalCheck1.gameObject.activeInHierarchy && Vector2.Distance(portalCheck1.transform.position, rh.point) > 2))
                    {
                        portalcheck2.Clean();
                        portalcheck2.gameObject.transform.position = rh.point;
                        portalcheck2.gameObject.SetActive(true);
                        checkSide(portalcheck2);
                    }
               
            }
            // rb.velocity = -rb.velocity;
        }
    }
	}
    void ThrowRay() {
        rh = Physics2D.Raycast(transform.position, sr.transform.right, 20, hasStrutureOnTop);     
    }
    void checkSide(PortalSpawnCheck psc) {
        if (rh.point.x - transform.position.x >= 0)
        {
            psc.right = true;

        }
        else if (rh.point.x - transform.position.x < 0)
        {
            psc.right = false;

        }
    }
}
