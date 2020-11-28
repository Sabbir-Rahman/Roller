using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour
{
    [SerializeField] private float m_MovePower = 5;
    [SerializeField] private float m_JumpPower = 12;


    protected Joystick joystick;
    protected Joybutton joybutton;

    protected bool jump;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<Joybutton>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var rigidbody = GetComponent<Rigidbody>();


        float joystickHorizontal;
        float joystickVertical;

        if (joystick.Vertical > 0 && joystick.Horizontal < 0)
        {
            joystickHorizontal = joystick.Horizontal - .72f;
            joystickVertical = joystick.Vertical - .72f;
        }
        else if (joystick.Vertical > 0 && joystick.Horizontal > 0)
        {
            joystickHorizontal = joystick.Horizontal - .72f;
            joystickVertical = joystick.Vertical + .72f;
        }
        else if (joystick.Vertical < 0 && joystick.Horizontal > 0)
        {
            joystickHorizontal = joystick.Horizontal + .72f;
            joystickVertical = joystick.Vertical + .72f;
        }
        else if (joystick.Vertical < 0 && joystick.Horizontal < 0)
        {
            joystickHorizontal = joystick.Horizontal + .72f;
            joystickVertical = joystick.Vertical - .72f;
        }
        else
        {
            joystickHorizontal = joystick.Horizontal;
            joystickVertical = joystick.Vertical;

        }
            rigidbody.AddForce(new Vector3((joystickHorizontal * 10f) + Input.GetAxis("Horizontal") * 10f,
                                             0,
                                             joystickVertical * 10f + Input.GetAxis("Vertical") * 10f) * m_MovePower);

        Debug.Log(joystick.Horizontal+" , "+joystick.Vertical);
        

        if (!jump && joybutton.Pressed && GetComponent<Rigidbody>().position.y <1.5) 
        {
            jump = true;
            rigidbody.AddForce(Vector3.up * m_JumpPower,ForceMode.Impulse);
        }

        if (!jump && Input.GetButton("Jump") && GetComponent<Rigidbody>().position.y < 1.5)
        {
            jump = true;
            rigidbody.AddForce(Vector3.up * (m_JumpPower-8), ForceMode.Impulse);
        }

        if (jump && (!joybutton.Pressed || Input.GetButton("Jump")))
        {
            jump = false;
        }

    }
}
