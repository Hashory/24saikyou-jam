using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : MonoBehaviour
{
    public int PlayerNumber { get; private set; }

    public void setnumber(int playerNumber)
    {
        PlayerNumber = playerNumber;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Attack")
        {
            Destroy(gameObject);
        }
    }

}
