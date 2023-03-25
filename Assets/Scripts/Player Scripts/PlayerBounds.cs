using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    private float minX, maxX;
    // Start is called before the first frame update
    void Start()
    {
        SetMinAndMaxX();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < minX-0.2f)
        {
            Vector3 temp = transform.position;
            temp.x = minX - 0.2f;
            transform.position = temp;
        }

        if (transform.position.x > maxX+0.2f)
        {
            Vector3 temp = transform.position;
            temp.x = maxX + 0.2f;
            transform.position = temp;
        }
    }
    void SetMinAndMaxX()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
    }
}
