using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    //[Header("Controller Settings")]
    //public bool keyboardXY = true;
    //public bool keyboardZ = true;
    //public bool grid = true;

    public GameObject playerFrag;
    private float moveSpeed = 0.5f;
    private bool dead;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Controls.gameOver == false)
        {
            #region Z Control
            if (Controls.keyboardZ)
            {
                if (Input.GetKey(KeyCode.Alpha1))
                {
                    Move(gameObject.transform.position.x, gameObject.transform.position.y, 1); // FOREGROUND
                }
                else if (Input.GetKey(KeyCode.Alpha3))
                {
                    Move(gameObject.transform.position.x, gameObject.transform.position.y, 3); // BACKGROUND
                }
                else
                {
                    Move(gameObject.transform.position.x, gameObject.transform.position.y, 2); // MIDDLE
                }
            }
            else // Joystick Z
            {
                if (Input.GetAxis("rJoy_h") > 0.5f)
                {
                    Move(gameObject.transform.position.x, gameObject.transform.position.y, 1); // FOREGROUND
                }
                else if (Input.GetAxis("rJoy_h") < -0.5f)
                {
                    Move(gameObject.transform.position.x, gameObject.transform.position.y, 3); // BACKGROUND
                }
                else
                {
                    Move(gameObject.transform.position.x, gameObject.transform.position.y, 2); // MIDDLE
                }
            }
            #endregion

            #region XY Control
            if (Controls.keyboardXY)
            {
                if (Controls.grid)
                {
                    #region Keyboard Grid Controls
                    if (Input.GetKey(KeyCode.Keypad1) || Input.GetKey(KeyCode.M)) // Bottom left
                    {
                        Move(1, 1, gameObject.transform.position.z);
                    }
                    else if (Input.GetKey(KeyCode.Keypad2) || Input.GetKey(KeyCode.Comma)) // Bottom middle
                    {
                        Move(2, 1, gameObject.transform.position.z);
                    }
                    else if (Input.GetKey(KeyCode.Keypad3) || Input.GetKey(KeyCode.Period)) // Bottom right
                    {
                        Move(3, 1, gameObject.transform.position.z);
                    }
                    else if (Input.GetKey(KeyCode.Keypad4) || Input.GetKey(KeyCode.J)) // Middle left
                    {
                        Move(1, 2, gameObject.transform.position.z);
                    }
                    else if (Input.GetKey(KeyCode.Keypad6) || Input.GetKey(KeyCode.L)) // Middle right
                    {
                        Move(3, 2, gameObject.transform.position.z);
                    }
                    else if (Input.GetKey(KeyCode.Keypad7) || Input.GetKey(KeyCode.U)) // Top left
                    {
                        Move(1, 3, gameObject.transform.position.z);
                    }
                    else if (Input.GetKey(KeyCode.Keypad8) || Input.GetKey(KeyCode.I)) // Top middle
                    {
                        Move(2, 3, gameObject.transform.position.z);
                    }
                    else if (Input.GetKey(KeyCode.Keypad9) || Input.GetKey(KeyCode.O)) // Top right
                    {
                        Move(3, 3, gameObject.transform.position.z);
                    }
                    else
                    {
                        Move(2, 2, gameObject.transform.position.z);
                    }
                    #endregion
                }
                else
                {
                    #region Keyboard Arrow / Game Controller Controls
                    if (Input.GetAxis("Alt_h") < -0.05f)
                    {
                        Move(1, gameObject.transform.position.y, gameObject.transform.position.z); // LEFT
                    }
                    else if (Input.GetAxis("Alt_h") > 0.05f)
                    {
                        Move(3, gameObject.transform.position.y, gameObject.transform.position.z); // RIGHT
                    }
                    else
                    {
                        Move(2, gameObject.transform.position.y, gameObject.transform.position.z); // CENTRE
                    }
                    if (Input.GetAxis("Alt_v") < -0.05f)
                    {
                        Move(gameObject.transform.position.x, 1, gameObject.transform.position.z); // TOP
                    }
                    else if (Input.GetAxis("Alt_v") > 0.05f)
                    {
                        Move(gameObject.transform.position.x, 3, gameObject.transform.position.z); // BOTTOM
                    }
                    else
                    {
                        Move(gameObject.transform.position.x, 2, gameObject.transform.position.z); // CENTRE
                    }
                    #endregion
                }
            }
            else
            {
                #region Joystick Controls
                #region Keyboard Arrow Controls
                if (Input.GetAxis("lJoy_h") < -0.05f)
                {
                    Move(1, gameObject.transform.position.y, gameObject.transform.position.z); // LEFT
                }
                else if (Input.GetAxis("lJoy_h") > 0.05f)
                {
                    Move(3, gameObject.transform.position.y, gameObject.transform.position.z); // RIGHT
                }
                else
                {
                    Move(2, gameObject.transform.position.y, gameObject.transform.position.z); // CENTRE
                }
                if (Input.GetAxis("lJoy_v") < -0.05f)
                {
                    Move(gameObject.transform.position.x, 1, gameObject.transform.position.z); // TOP
                }
                else if (Input.GetAxis("lJoy_v") > 0.05f)
                {
                    Move(gameObject.transform.position.x, 3, gameObject.transform.position.z); // BOTTOM
                }
                else
                {
                    Move(gameObject.transform.position.x, 2, gameObject.transform.position.z); // CENTRE
                }
                #endregion
                #endregion
            }
            #endregion
        } // end of if !noControl
        else
            GameOver();
    }

    /// <summary>
    /// moves the player from current position to pos x, y, z using MoveTowards
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    void Move(float x, float y, float z)
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(x, y, z), moveSpeed);
    }

    void GameOver()
    {
        if (!dead)
        {
            Instantiate(playerFrag, transform.position, Quaternion.identity);
            Destroy(gameObject);
            dead = true;
        }
    }
}
