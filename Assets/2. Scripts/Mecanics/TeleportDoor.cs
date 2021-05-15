using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportDoor : MonoBehaviour {

    public GameObject otherDoor;
    void OnTriggerStay2D(Collider2D CD) {
        if (CD.CompareTag("Player")&&Input.GetKeyDown(KeyCode.T)) {
            CD.transform.position = otherDoor.transform.position;
        }
    }
}
