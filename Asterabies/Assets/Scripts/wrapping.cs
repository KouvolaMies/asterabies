using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrapping : MonoBehaviour
{
    void Update()
    {
        Vector3 viewportpos = Camera.main.WorldToViewportPoint(transform.position);

        Vector3 moveadjustment = Vector3.zero;

        if(viewportpos.x < 0){
            moveadjustment.x += 1;
        }
        else if(viewportpos.x > 1){
            moveadjustment.x -= 1;
        }
        else if(viewportpos.y < 0){
            moveadjustment.y += 1;
        }
        else if(viewportpos.y > 1){
            moveadjustment.y -= 1;
        }

        transform.position = Camera.main.ViewportToWorldPoint(viewportpos + moveadjustment);
    }
}
