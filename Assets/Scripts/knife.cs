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

    private void Start()
    {
        if (PotionManager == null)
        {
            PotionManager = FindObjectOfType<Potion_manager>();
            bounce = 1;
        }
    }
    public void setnumber(int playerNumber)
    {
        PlayerNumber = playerNumber;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Attack")
        {
            if (PotionManager.player_Lv[PlayerNumber] == 2)
            {
                if (bounce != 0)
                {
                    bounce--;
                }
                else
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

}
