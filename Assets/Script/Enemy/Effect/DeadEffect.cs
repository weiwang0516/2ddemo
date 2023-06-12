using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEffect : MonoBehaviour
{
    // Start is called before the first frame update
    private float time = 0.5f;
    void Start()
    {
        Destroy(gameObject,time);
    }

}
