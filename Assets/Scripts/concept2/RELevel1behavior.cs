using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RELevel1behavior : MonoBehaviour
{
    public Sprite[] sprites;
    public GameObject bulbPrefab;
    private Vector3 screenPoint;
    private Vector3 offsite;
    private float firstY;

    // Start is called before the first frame update
    void Start()
    {
        AssignRandomSprite();
    }

    void AssignRandomSprite()
    {
        int index = Random.Range(0, sprites.Length);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[index];
    }

    void OnMouseDown()
    {
        firstY = transform.position.y;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offsite = gameObject.transform.position - Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z)
        );

        // Instantiate a new bulb at the same position
        Vector3 newPosition = transform.position;
        GameObject newBulb = Instantiate(bulbPrefab, newPosition, Quaternion.identity);
        newBulb.GetComponent<RELevel1behavior>().AssignRandomSprite(); // Assign a random sprite to the new bulb
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offsite;
        transform.position = curPosition;
    }

    void OnMouseUp()
    {
        transform.position = new Vector3(transform.position.x, firstY, transform.position.z);
    }
}
