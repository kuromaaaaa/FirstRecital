using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    //弾のプレハブ取得
    [SerializeField] GameObject m_tamaPrehub = default;
    //まずるの位置取得
    [SerializeField] Transform m_mz = default;

    //キャラクタースピード
    [SerializeField] float m_speed = 1f;
    [SerializeField] float LimitSpeed ;
    //ジャンプ高さ
    [SerializeField] float m_jump = 1f;
    float m_jumpCount = 0;
    //球を打った時のクールタイム
    [SerializeField] float m_cooltime = 20;
    Rigidbody2D m_rb;
    float m_h;
    Transform m_tf;
    float m_scalex;
    float m_scaleminus;
    float m_flip;
    float m_timer = 30;
    //マガジンの中の弾数
    public static int mag = 0;
    //射撃可能タイミング
    bool m_reload = false;
    float m_reloadtimer;

    //操作可能
    bool sousa = false;
    float sousaO = 0;

    //Audio
    bool sound = true;
    [SerializeField] GameObject m_bakuha = default;

    //ゲームオ－バー
    bool m_gameover = false;
    [SerializeField]GameObject gameoverText;
    [SerializeField] GameObject gameoverText2;
    GameObject stage;
    GameObject stageC;
    [SerializeField] GameObject NewStage;
    [SerializeField] Transform stagePosi;

    //クロスヘア
    GameObject m_cross;


    //public int maga { get { return m_mag; } }//見る用新しい変数をつくる



    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_tf = GetComponent<Transform>();
        m_scalex = m_tf.localScale.x;
        m_scaleminus = m_scalex * -1;


        m_cross = GameObject.Find("crosshair");


    }
    void Update()
    {
        if (sousa)
        {
            //キャラクターの横移動
            m_h = Input.GetAxisRaw("Horizontal");
            //反転用クロスヘアと自分の位置
            //Vector3 mousePosi = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            if(m_cross)
            {
                m_flip = m_tf.position.x - m_cross.transform.position.x;
            }
            //m_flip = m_tf.position.x - m_cross.transform.position.x;


            //Debug.Log(Input.GetAxisRaw("JumpLTR"));
            //ジャンプの処理

            if (Input.GetButtonDown("Jump") && m_jumpCount == 0 || Input.GetAxisRaw("JumpLTR") > 0 && m_jumpCount == 0 || Input.GetAxisRaw("Vertical") > 0 && m_jumpCount == 0)
            {
                m_rb.AddForce(Vector2.up * m_jump, ForceMode2D.Impulse);
                m_jumpCount = 1;

            }
            //銃を撃つ処理
            if (m_reload == false)
            {
                if (Input.GetButtonDown("Fire1") && m_timer > m_cooltime && mag < 10)
                {
                    Instantiate(m_tamaPrehub).transform.position = m_mz.position;
                    m_timer = 0;
                    mag++;
                    //Debug.Log("弾を打つ処理");
                }
            }
            //リロードの処理
            if (Input.GetButtonDown("reload") || Input.GetAxisRaw("reloadRTR") > 0)
            {
                m_reload = true;
            }


            //キャラを反転させる処理
            if (m_flip > 0)
            {
                m_tf.localScale = new Vector2(m_scaleminus, m_tf.localScale.y);

            }
            if (m_flip < 0)
            {
                m_tf.localScale = new Vector2(m_scalex, m_tf.localScale.y);
            }

        }
        //穴に落ちるとゲームオーバー
        if(this.transform.position.y < -7)
        {
            m_gameover = true;
            sousa = false;
            Debug.Log("gameover");
        }
        //ゲームオーバーの処理
        if (m_gameover == true)
        {
            gameoverText.GetComponent<Text>().enabled = true;
            gameoverText2.GetComponent<Text>().enabled = true;
        }
        else
        {
            gameoverText.GetComponent<Text>().enabled=false;
            gameoverText2.GetComponent<Text>().enabled = false;
        }

        
        if(m_gameover == true)
        {
            //ゲームオーバー音
            if (sound == true)
            {
                Instantiate(m_bakuha).transform.position = transform.position;
                sound = false;
            }
            //リトライの処理

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("start"))
            {
                stage = GameObject.Find("stage");
                stageC = GameObject.Find("stage(Clone)");
                Destroy(stage);
                Destroy(stageC);
                Instantiate(NewStage).transform.position = stagePosi.position;
                this.transform.position = new Vector3(0, -1, 0);

                GetComponent<AudioSource>().Play();
                m_gameover = false;
                sound = true;

            }
        }



        //ゲームスタートするまで動かない
        if(Input.GetKeyUp(KeyCode.Return) && sousaO == 0 || Input.GetButtonUp("start") && sousaO == 0)
        {
            sousaO++;
        }
        if(Input.GetKeyDown(KeyCode.Return) &&sousaO == 1 || Input.GetButtonDown("start") && sousaO == 1)
        {
            sousa = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (sousa)
        {
            //キャラの左右移動
            m_rb.AddForce(Vector2.right * m_h * m_speed, ForceMode2D.Force);

            if (m_rb.velocity.magnitude > LimitSpeed)
            {
                m_rb.velocity = new Vector2(m_rb.velocity.x / 1.1f, m_rb.velocity.y);
            }
            //クールタイム用タイマー
            m_timer++;
            if (m_reload == true)
            {
                m_reloadtimer++;
                if (m_reloadtimer >= 45)
                {
                    m_reload = false;
                    mag = 0;
                    m_reloadtimer = 0;
                }
            }
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        m_jumpCount = 0;
        if (collision.gameObject.tag == "enemy")
        {
            m_gameover = true;
            sousa = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        m_jumpCount = 1;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            m_gameover = true;
            sousa = false;
        }
    }
}
