using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class knife : MonoBehaviour
{
    public int PlayerNumber { get; private set; }
    public Potion_manager PotionManager;
    public int bounce;
    public AudioClip Weapon_SE;
    AudioSource audiosource;


    private void Awake()
    {
        if (PotionManager == null)
        {
            PotionManager = FindObjectOfType<Potion_manager>();
        }
        audiosource = GetComponent<AudioSource>();
    }

    public void setnumber(int playerNumber)
    {
        PlayerNumber = playerNumber;
            // レベルに基づいてバウンス数を設定
            if (PotionManager.player_Lv[PlayerNumber] == 3)
            {
                bounce = 2;
            }
            else
            {
                bounce = 0;
            }

    }

    private void OnCollisionEnter(Collision collision)
    {
        // audiosource.PlayOneShot(Weapon_SE);
        AudioManager.Instance.PlaySound(Weapon_SE);

        if (collision.gameObject.tag != "Attack")
        {
            
            if (bounce > 0)
            {
                bounce--;
            }
            else
            {
                
                Destroy(gameObject);
            }
        }
   
    }
}
