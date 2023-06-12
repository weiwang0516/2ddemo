﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoiunt : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.GetComponent<IDamageable>().GetHit(3);
    }
}
