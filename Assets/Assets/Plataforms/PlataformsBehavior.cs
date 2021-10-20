using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformsBehavior : MonoBehaviour
{
    private float velocity = 3;
    public Direction direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.right * Time.deltaTime * velocity);

        if (this.transform.position.x > 15 || this.transform.position.x < -15)
        {
            Destroy(this.gameObject);
        }
    }
}
