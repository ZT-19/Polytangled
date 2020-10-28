using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorPos : MonoBehaviour
{
    void Start()
    {
        var nextPos = new Vector3(0, 1, 1);
        transform.position = Camera.main.ViewportToWorldPoint(nextPos);

        Vector3 startPos = transform.position;
        float x = transform.position.x;
        float y = transform.position.y;
        startPos = new Vector3(x, y, 0);
        transform.position = startPos;
    }
}
