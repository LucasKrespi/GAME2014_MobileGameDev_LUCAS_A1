using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpwaner : MonoBehaviour
{

    public GameObject mosquito;
    public GameObject chicken;
    
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-9.0f, 9.0f);
        float y = Random.Range(0.0f, 2.0f);

        mosquito.transform.position = new Vector2(x, y);

        Instantiate(mosquito);


        x = Random.Range(-9.0f, 9.0f);
        y = Random.Range(0.0f, 2.0f);

        chicken.transform.position = new Vector2(x, y);

        Instantiate(chicken);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
