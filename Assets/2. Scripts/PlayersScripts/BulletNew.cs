using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletNew : MonoBehaviour
{

    public float speed;
    public float lifetime;

    public GameObject destroyEffect;

    private void Start()
    {
        Invoke("DestroyProjectile", lifetime);
    }

    private void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        
    }

}
