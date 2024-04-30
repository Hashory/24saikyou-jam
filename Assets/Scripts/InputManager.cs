using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public static bool GetKeyDown(int input)
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            if((input == 1 && touch.position.x > Screen.width / 2) || (input == -1 && touch.position.x < Screen.width / 2))
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        return true;
                }
            }
        }

        return (input == 1 && Input.GetKeyDown(KeyCode.D)) || (input == -1 && Input.GetKeyDown(KeyCode.K));
    }

    public static bool GetKeyUp(int input)
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            if ((input == 1 && touch.position.x > Screen.width / 2) || (input == -1 && touch.position.x < Screen.width / 2))
            {
                switch (touch.phase)
                {
                    case TouchPhase.Ended:
                        return true;
                }
            }
        }

        return (input == 1 && Input.GetKeyUp(KeyCode.D)) || (input == -1 && Input.GetKeyUp(KeyCode.K));
    }

    public static bool GetKey(int input)
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            if ((input == 1 && touch.position.x > Screen.width / 2) || (input == -1 && touch.position.x < Screen.width / 2))
            {
                switch (touch.phase)
                {
                    case TouchPhase.Moved:
                        return true;

                    case TouchPhase.Stationary:
                        return true;
                }
            }
        }

        return (input == 1 && Input.GetKey(KeyCode.D)) || (input == -1 && Input.GetKey(KeyCode.K));
    }


}
