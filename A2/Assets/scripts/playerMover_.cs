   using UnityEngine;
using TMPro; 
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class playerMover_ : MonoBehaviour
{




    public int coinCount;
    public Image powerUpIMG;
    public TMP_Text coinCountText;
    public TMP_Text starterText;


    public Animator PUAnim;
    public Animator boxAnim;
    public Animator playerAnim;

    public GameObject powerPanel;

    public float m; 
    public float speed;

    public bool hasPowerUp;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(waiting());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (hasPowerUp)
            {
                usePowerUp();
                powerPanel.SetActive(false);
            }

        }
    }



    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("coin"))
        {
            c.gameObject.SetActive(false);
            coinCount++;
            updateCoinCounter();
        }
        if (c.gameObject.CompareTag("npc")) { 
            Debug.Log("Hit!");
        }
        if (c.gameObject.CompareTag("M_box"))
        {
            powerPanel.SetActive(true);
           
            if (hasPowerUp)
            {
                c.gameObject.SetActive(false);

            }
            else if (!hasPowerUp)
            {
                c.gameObject.SetActive(false);
                hasPowerUp = true;
                powerUpIMG.gameObject.SetActive(true);
            StartCoroutine(spawning());

            }
            if (c.gameObject.CompareTag("NPC"))
            {
                Debug.Log("Hit!!");
                StartCoroutine(frantic());
            }
        }
        
    }
    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("npc"))
        {
            Debug.Log("Hit!!!");
            StartCoroutine(frantic());
        }
    }

    public void updateCoinCounter()
    {
        coinCountText.text = string.Format("{00:0}:0",coinCount);
    }
    void usePowerUp()
    {
        Debug.Log("powerup Used!");
        powerUpIMG.gameObject.SetActive(false);

        hasPowerUp = false;
    }
    IEnumerator waiting()
    {
        yield return new WaitForSeconds(2f);
        boxAnim.SetBool("isClosed",true);
    }
    IEnumerator spawning()
    {
        PUAnim.SetBool("spawned", true);
        yield return new WaitForSeconds(2f);
        PUAnim.SetBool("spawned", false);

    }
    IEnumerator frantic()
    {
        playerAnim.SetBool("isHit", true);
        yield return new WaitForSeconds(3f);
        playerAnim.SetBool("isHit", false);

    }
}
