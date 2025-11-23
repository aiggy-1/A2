   using UnityEngine;
using TMPro; 

public class playerMover_ : MonoBehaviour
{




    public int coinCount;

    public TMP_Text coinCountText;
    public TMP_Text starterText;

    public float m; 
    public float speed; 
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("coin"))
        {
            c.gameObject.SetActive(false);
            coinCount++;
            updateCoinCounter();
        }
        
    }

    public void updateCoinCounter()
    {
        coinCountText.text = string.Format("{0:0}:",coinCount);
    }
}
