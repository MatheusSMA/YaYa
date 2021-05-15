using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBehaviour : MonoBehaviour {
    public float timeToShot;
    float currentTimeShoT;
    void OnTriggerStay2D(Collider2D CD) {
        if (CD.tag=="Player")
        {
            print("PLAYERINCIRLCE"); 
            RaycastHit2D hitinfo=Physics2D.Raycast(transform.position,CD.transform.position-transform.position,100);
            Debug.DrawRay(transform.position,CD.transform.position-transform.position);
            if (hitinfo.transform!=null) {
                print(hitinfo.transform.name);
                if (hitinfo.transform.tag == "Player")
                {
                    print("xx");
                }
                }
        }
    }
}
