using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    AudioSource audioSource;
    public int Coin;
    public Text CoinText;
    
    
    
    private Rigidbody rb;
    public float Hiz = 2.1f;
    public Text zaman, can;
    float zamanSayaci = 150;
    float canSayaci = 100;
    bool oyunDevam = true;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunDevam)
        {
            zamanSayaci -= Time.deltaTime;
            zaman.text = (int)zamanSayaci + "";
        }
        if (zamanSayaci < 0)
        {
            oyunDevam = false;

        }
        if(Coin==5)
            {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        
        
        if (collision.collider.tag == "Düsman")
        {
            
                if(canSayaci>0 || oyunDevam)
            {
                canSayaci -= 5;
                can.text = canSayaci + "";
                audioSource.Play();
                if (canSayaci == 0)
                {
                    oyunDevam = false;

                }
            }
        }

        if (collision.collider.tag == "Coin")
        {
            Coin++;
            Destroy(collision.gameObject);
            CoinText.text = "" + Coin;


        }

        {
            if(collision.collider.tag=="Yemek")
            {
                zamanSayaci+=20;
                Destroy(collision.gameObject);
                
            }
        }
        {
            if(collision.collider.tag=="Ýksir")
            {
                canSayaci+= 15;
                Destroy(collision.gameObject);
                can.text = canSayaci + "";
            }
        }
        
        
        


    }
}
