using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Runtime.InteropServices.Guid("58510310-48AA-4F8F-BFA1-A5491346A90B")]

public enum Direction
{
    RIGHT,
    LEFT,
}
public class Spwaner : MonoBehaviour
{
    public GameObject m_VeiclePrefab;
   
    public Direction m_direction;

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(SpwanVehicle(m_direction));
    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator SpwanVehicle(Direction direction)
    {
        float spwantime = Random.Range(0.5f, 3.0f);

        yield return new WaitForSeconds(spwantime);

        switch (direction)
        {
            case Direction.RIGHT:
                Instantiate(m_VeiclePrefab, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0.0f), Quaternion.Euler(0.0f, 0.0f, 270.0f));
                break;
            case Direction.LEFT:
                Instantiate(m_VeiclePrefab, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0.0f), Quaternion.Euler(0.0f, 0.0f, 90.0f));
                break;
        }
       

        StartCoroutine(SpwanVehicle(m_direction));

    }
}
