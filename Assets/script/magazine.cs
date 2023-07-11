using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class magazine : MonoBehaviour
{
    public static int inMag;

    float m_timer = 100;
    GameObject[] mag;
    GameObject bullet1;
    GameObject bullet2;
    GameObject bullet3;
    GameObject bullet4;
    GameObject bullet5;
    GameObject bullet6;
    GameObject bullet7;
    GameObject bullet8;
    GameObject bullet9;
    GameObject bullet10;

    GameObject RELOAD;
    GameObject gauge;
    [SerializeField] float m_cooltime = 15;
    bool m_reload = false;
    float m_gaugeX = 0;

    bool sousa = false;
    float sousaO = 0;

    [SerializeField] GameObject m_audioprefub;
    AudioSource m_audio = default;
    RectTransform reTr;

    void Start()
    {
         
        mag = new GameObject[10];
        bullet1 = GameObject.Find("bullet1");
        bullet2 = GameObject.Find("bullet2");
        bullet3 = GameObject.Find("bullet3");
        bullet4 = GameObject.Find("bullet4");
        bullet5 = GameObject.Find("bullet5");
        bullet6 = GameObject.Find("bullet6");
        bullet7 = GameObject.Find("bullet7");
        bullet8 = GameObject.Find("bullet8");
        bullet9 = GameObject.Find("bullet9");
        bullet10 = GameObject.Find("bullet10");
        mag[0] = bullet1;
        mag[1] = bullet2;
        mag[2] = bullet3;
        mag[3] = bullet4;
        mag[4] = bullet5;
        mag[5] = bullet6;
        mag[6] = bullet7;
        mag[7] = bullet8;
        mag[8] = bullet9;
        mag[9] = bullet10;

        RELOAD = GameObject.Find("RELOAD");
        gauge = GameObject.Find("gauge");
        m_audio = GetComponent<AudioSource>();
        
        reTr = gauge.GetComponent<RectTransform>();
        
        for(int i = 1 ; i < inMag+1; i++)
        {
            mag[inMag - i].GetComponent<UnityEngine.UI.Image>().enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (sousa)
        {
            if (m_reload == false)
            {
                if (Input.GetButtonDown("Fire1") && m_timer > m_cooltime && inMag < 10)
                {
                    //Debug.Log(i);
                    mag[inMag].GetComponent<UnityEngine.UI.Image>().enabled = false;
                    inMag++;
                    m_timer = 0;

                }
            }
            if (Input.GetButtonDown("reload") || Input.GetAxisRaw("reloadRTR") > 0)
            {
                m_reload = true;
                foreach (GameObject tama in mag)
                {
                    tama.GetComponent<UnityEngine.UI.Image>().enabled = true;
                    m_audio.Play();
                    inMag = 0;
                }
            }
            if (inMag == 10)
            {
                RELOAD.GetComponent<Text>().enabled = true;
                if (Input.GetButtonDown("Fire1") && m_timer > m_cooltime)
                {
                    Instantiate(m_audioprefub).transform.position = transform.position;
                    m_timer = 0;
                }
            }
            else
            {
                RELOAD.GetComponent<Text>().enabled = false;
            }


            reTr.sizeDelta = new Vector2(m_gaugeX, 100);
            reTr.position = new Vector2(m_gaugeX / 2 + 40, this.transform.position.y);
        }
        if (Input.GetKeyUp(KeyCode.Return) && sousaO == 0 || Input.GetButtonUp("start") && sousaO == 0)
        {
            sousaO++;
        }
        if (Input.GetKeyDown(KeyCode.Return) && sousaO == 1 || Input.GetButtonDown("start") && sousaO == 1)
        {
            sousa = true;
        }
    }
    private void FixedUpdate()
    {
        m_timer++;
        
        if (m_reload == true )
        {
            m_gaugeX += 20;
            //Debug.Log(m_gaugeX);
            if(m_gaugeX >= 900)
            {
                m_reload=false;
                m_gaugeX = 0;

            }
        }
        
    }
}
