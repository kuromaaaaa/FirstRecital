using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAll : MonoBehaviour
{
    GameObject player;
    GameObject gameoverText;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("ÉvÉåÉCÉÑÅ[");
        gameoverText = GameObject.Find("GAME OVER");
    }

    // Update is called once per frame
    void Update()
    {
        
        if(player == null)
        {
            gameoverText.SetActive(true);
        }
    }
}
