using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformSpwaner : MonoBehaviour
{
    public GameObject m_PlataformPrefab;

    public Direction m_direction;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(SpwanPlataform(m_direction));
    }


    public IEnumerator SpwanPlataform(Direction direction)
    {
        float spwantime = Random.Range(2.0f, 5.0f);
        GameObject temp = null;
        yield return new WaitForSeconds(spwantime);

        switch (direction)
        {
            case Direction.RIGHT:
                temp = Instantiate(m_PlataformPrefab, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0.0f), Quaternion.Euler(0.0f, 0.0f, 0.0f));
                temp.GetComponent<PlataformsBehavior>().direction = direction;
                break;
            case Direction.LEFT:
                temp = Instantiate(m_PlataformPrefab, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0.0f), Quaternion.Euler(0.0f, 0.0f, 180.0f));
                temp.GetComponent<PlataformsBehavior>().direction = direction;
                break;
        }


        StartCoroutine(SpwanPlataform(m_direction));

    }
}
