using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemySuperClass : MonoBehaviour
{
    public abstract void Damage();
    cross _cross;
    void OnEnable()
    {
        _cross = GameObject.FindObjectOfType<cross>();
        _cross.Enemy.Add(this.gameObject);
    }

    private void OnDisable()
    {
        _cross.Enemy.Remove(this.gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "shell")
        {
            Damage();
        }
    }
}
