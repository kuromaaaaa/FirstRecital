using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class GameAll : MonoBehaviour
{
    [SerializeField] GameObject sousa;
    [SerializeField] GameObject m_title;
    [SerializeField] GameObject stage;
    [SerializeField] GameObject player;
    [SerializeField] GameObject Square;
    float ENT = 0;
    // Start is called before the first frame update
    void Start()
    {
        m_title.SetActive(true);
        sousa.SetActive(false);
        stage.SetActive(false);
        player.SetActive(true);
        Square.SetActive(true);
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && ENT == 0 || Input.GetButtonDown("start") && ENT == 0)

        {
            m_title.SetActive(false);
            sousa.SetActive(true);
        }
        if(Input.GetKeyUp(KeyCode.Return) || Input.GetButtonUp("start"))
        {
            ENT++;
        }
        if(Input.GetKeyDown(KeyCode.Return) && ENT == 1 || Input.GetButtonDown("start") && ENT == 1)
        {
            sousa.SetActive(false);
            stage.SetActive(true);
            Square.SetActive(false);

        }
    }
}
