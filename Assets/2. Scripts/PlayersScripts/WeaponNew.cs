using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponNew : MonoBehaviour
{
    public GameObject Arm;
    public float offset;
    public GameObject projectile;
    public GameObject projectileLVL2;
    public GameObject projectileLVL3;
    public Transform shotpoint;
    public YagoController YC;
    private float timeBTWshots;
    public float startTimeBTWshots;

    public float timeButtonDown;


    //CrossHair
    [Space]
    [Space]
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;



    private void Start()
    {
        Crosshair();
    }
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Arm.transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Arm.transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);


        if (timeBTWshots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(projectile, shotpoint.position, transform.rotation);
                timeBTWshots = startTimeBTWshots;
            }
        }
        else
        {
            timeBTWshots -= Time.deltaTime;
        }

        /********************TESTE********************************
        if (Input.GetKey(KeyCode.F))
        {
            timeButtonDown += Time.deltaTime;
            YC.isMoving = false;

        }
        else if (Input.GetKeyUp(KeyCode.F))
        {  
            if (timeButtonDown <= 1f)
            {
                Instantiate(projectileLVL2, shotpoint.position, transform.rotation);
            }
            if (timeButtonDown > 1f)
            {
                Instantiate(projectileLVL3, shotpoint.position, transform.rotation);
            }
            timeButtonDown = 0;
            YC.isMoving = true;
        }
        */

        if (rotZ > 0f && rotZ < 100f || rotZ < 0f && rotZ > -90f)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<SpriteRenderer>().flipY = false;
            shotpoint.transform.localPosition = new Vector3(Mathf.Abs(shotpoint.transform.localPosition.x), Mathf.Abs(shotpoint.transform.localPosition.y), shotpoint.transform.localPosition.z);
            if (!YC.facingRight)
            {
                YC.Flipp();
            }

        }
        else if (rotZ > 100f && rotZ < 180f || rotZ < -90f && rotZ > -180f)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<SpriteRenderer>().flipY = true;
            shotpoint.transform.localPosition = new Vector3(-Mathf.Abs(shotpoint.transform.localPosition.x), -Mathf.Abs(shotpoint.transform.localPosition.y), shotpoint.transform.localPosition.z);
            if (YC.facingRight)
            {
                YC.Flipp();

            }
        }



    }

    public void Crosshair()
    {
        Cursor.SetCursor(LevelManager.instance.cursorTexture, hotSpot, cursorMode);
    }

    public void CrosshairOFF()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}









