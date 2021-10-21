using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoopBehavior : MonoBehaviour
{
    public GameObject sprite;
    public bool isOccupied;
    // Start is called before the first frame update
    void Start()
    {
        sprite.SetActive(false);
        isOccupied = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        sprite.SetActive(true);
    }
}
