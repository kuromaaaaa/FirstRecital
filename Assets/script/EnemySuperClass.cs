using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemySuperClass : MonoBehaviour
{
    public abstract void Damage();

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "shell")
        {
            Damage();
        }
    }
}
