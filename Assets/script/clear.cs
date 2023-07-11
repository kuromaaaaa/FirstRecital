using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D.IK;

public class clear : MonoBehaviour
{
    [SerializeField] GameObject gameclear;
    bool _clear = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_clear)
        {
            if (Input.GetButtonDown("start") || Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("stage2");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            gameclear.GetComponent<UnityEngine.UI.Text>().enabled = true;
            _clear = true;
        }

    }
}
