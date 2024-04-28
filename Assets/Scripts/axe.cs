using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axe : MonoBehaviour
{
    // Start is called before the first frame update
    public int PlayerNumber { get; private set; }
    public int bounce = 1;

    public void setnumber(int playerNumber)
    {
        PlayerNumber = playerNumber;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Attack")
        {
            if(bounce != 0)
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
