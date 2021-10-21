using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CobraBehavior : MonoBehaviour
{

    public float screenBoundX;
    public float screenBoundY;
    public float velocity;
    public GameObject cobra;
    private GameObject player;
   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        cobra.transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if (cobra.transform.position.x > screenBoundX)
        {
            cobra.transform.rotation = Quaternion.Euler(180.0f, 0.0f, 180.0f);
        }
        else if (cobra.transform.position.x < -screenBoundX)
        {
            cobra.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }

        if (player.transform.position.y >= cobra.transform.position.y && player.transform.position.y < cobra.transform.position.y + 0.5)
        {
            if (player.transform.position.x >= cobra.transform.position.x)
            {
                velocity = 4;
                cobra.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }
            else if (player.transform.position.x < cobra.transform.position.x)
            {
                velocity = 4;
                cobra.transform.rotation = Quaternion.Euler(180.0f, 0.0f, 180.0f);
            }

        }
        else
        {
            velocity = 1;
        }
    }
}
