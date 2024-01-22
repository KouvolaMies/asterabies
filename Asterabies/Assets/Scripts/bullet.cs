using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private float lifetime = 2f;
    private void Awake(){
        Destroy(gameObject, lifetime);
    }
}
