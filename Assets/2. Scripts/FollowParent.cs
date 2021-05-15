using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowParent : MonoBehaviour {


    Transform target;
    Vector3 offset;

    void Start()
    {
        target = transform.parent;
        offset = transform.localPosition;
        transform.parent = null;
    }

    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
