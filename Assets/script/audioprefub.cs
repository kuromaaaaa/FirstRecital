using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioprefub : MonoBehaviour
{
    int timer = 0;
    private void FixedUpdate()
    {
        if(timer > 100)
        {
            Destroy(gameObject);
        }
        timer++;
    }
}
