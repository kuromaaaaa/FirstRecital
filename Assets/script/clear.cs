using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class clear : MonoBehaviour
{
    [SerializeField] GameObject gameclear;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("start") || Input.GetKeyDown(KeyCode.Return))
        {
            gameclear.GetComponent<UnityEngine.UI.Text>().enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            gameclear.GetComponent<UnityEngine.UI.Text>().enabled = true;

        }

    }
}
