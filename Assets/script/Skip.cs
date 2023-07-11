using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skip : MonoBehaviour
{
    [SerializeField] GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _player.transform.position = new Vector2(115 , 0);
            GameObject _enemys = GameObject.Find("“G");
            Destroy(_enemys);

        }

    }

}
