using UnityEngine;

public class PortalBehaviour : MonoBehaviour {
    public GameObject player;
    public GameObject pair;
    public bool right;
    //ADICIONAR PORTAL SPEED QUANDO ESTA UM RIGHT E OUTRO LEFT
	// Update is called once per frame
	void Update () {
        if (LevelManager.instance.timePortalPlayer < 0.3f)
        {
            LevelManager.instance.timePortalPlayer += Time.deltaTime;
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (pair.gameObject.activeInHierarchy && LevelManager.instance.timePortalPlayer >= 0.3f && collision.tag != "Portal" && collision.tag != "PortalCheck" && collision.tag != "NonTeleportable")
        {
            LevelManager.instance.timePortalPlayer = 0;
            collision.transform.position = pair.transform.position;
            if (pair.GetComponent<PortalBehaviour>().right != right)
            {
                if (right)
                {
                    if ((collision.tag == "Player" || collision.tag == "DinoPlayer"))
                    {

                        collision.GetComponent<PlayerController>().portalspeed = 15;
                        collision.GetComponent<PlayerController>().portalSpeedPositive = true;
                        print("a");

                    }
                    else
                    {
                        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(15, 0), ForceMode2D.Impulse);
                        print("base");
                    }

                }
                else
                {
                    if ((collision.tag == "Player" || collision.tag == "DinoPlayer"))
                    {

                        collision.GetComponent<PlayerController>().portalspeed =-15;
                        collision.GetComponent<PlayerController>().portalSpeedPositive = false;
                        print("b");

                    }
                    else
                    {
                        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-15, 0), ForceMode2D.Impulse);
                        print("base");
                    }
                }
            } else if (pair.GetComponent<PortalBehaviour>().right == right) {            
                
                    if (collision.tag == "Player" || collision.tag == "DinoPlayer")
                    {

                        collision.GetComponent<PlayerController>().portalspeed = 15;
                    collision.GetComponent<PlayerController>().portalSpeedPositive = true;

                    print("t");


                        collision.GetComponent<PlayerController>().portalSpeedPositive = true;
                    }
                    else
                    {
                        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(15, 0), ForceMode2D.Impulse);

                    }
                   print(right);
                
            } 
        }

    }
}
