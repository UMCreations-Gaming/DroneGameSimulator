using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    [SerializeField] GameObject Maincampos;
    [SerializeField] Joystick joystickLeft;
    [SerializeField] Joystick joystickRight;
    [SerializeField] Joystick joystickCam;
    [SerializeField] Camera Dronecam;
    [SerializeField] GameObject Drone;

    //
    public bool isground;


    //UI
    [SerializeField] Image Newtworkrichimage;
   

    // Update is called once per frame
    void FixedUpdate()
    {
        /*if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("flay player");
            transform.position += Vector3.up * speed * Time.deltaTime;
          
        }*/
         
        DroneMovement();
        DroneRooation();
        Networkrich();

        if(joystickCam.Horizontal != 0 || joystickCam.Vertical != 0)
        {
        DroneCamrotation();
        }

    }


    public void Networkrich()
    {
        float dist = Vector3.Distance(Maincampos.transform.position, transform.position) - 10 ;
        //
        // print("Distance to other: " + dist);
        print("Distance to other: " + dist/100);
        NetwokrichUI(dist / 100);
        if (dist > 100)
        {
            Debug.Log("Game over Connection los");
            Debug.Break();
        }
    }

    
    public void NetwokrichUI(float value)
    {
        Newtworkrichimage.fillAmount = 1 - value;
    }


    public void DroneCamrotation()
    {
        Dronecam.transform.rotation = Quaternion.Euler(Dronecam.transform.rotation.x + joystickCam.Vertical * -45, Dronecam.transform.rotation.y + joystickCam.Horizontal * 45   , 0);
    }

private float tiltFactor = 5;
private float tiltSpeed = 5;
    public void DroneMovement()
    {
        var rigidbody = GetComponent<Rigidbody>();
        if (!isground)
        {

         //r L F B
         Vector3 dir = new Vector3(joystickLeft.Horizontal * speed, rigidbody.velocity.y, joystickLeft.Vertical * speed);
         rigidbody.velocity = transform.transform.TransformDirection(dir);
           // Drone.transform.rotation = Quaternion.Euler(Drone.transform.rotation.x, Drone.transform.rotation.y, -joystickLeft.Horizontal*10);


           // Movement
        //Vector3 dir = new Vector3(joystickLeft.Horizontal * speed, rigidbody.velocity.y, joystickLeft.Vertical * speed);
        //rigidbody.velocity = transform.TransformDirection(dir);

        // Tilt (Rotation)
        float tiltAmountX = joystickLeft.Vertical * tiltFactor;  // Tilt forward/backward
        float tiltAmountZ = -joystickLeft.Horizontal * tiltFactor;  // Tilt left/right

        Quaternion targetTilt = Quaternion.Euler(tiltAmountX, transform.eulerAngles.y, tiltAmountZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetTilt, Time.deltaTime * tiltSpeed);


        }

        //up and down
        rigidbody.velocity = new Vector3(rigidbody.velocity.x, joystickRight.Vertical * speed , rigidbody.velocity.z);

     }

    public void DroneRooation()
    {
        if (!isground)
        {

            transform.eulerAngles += new Vector3(0, transform.rotation.x + joystickRight.Horizontal , 0) * 0.5f;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isground = true;
        }

        if (collision.transform.CompareTag("End"))
        {
            // dreone reach to end pint chake for ring collections
            if(Gamemanager.instance.ringcount == LevelManager.instance.totalpointrequiuerd)
            {
                //game over
                Debug.Log("Level completed");
                Gamemanager.instance.LevelCompeted();
               
            }
        }


    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isground = false;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Ring"))
        {
            // increment ring collection point
            // and destriy the rings
            Debug.Log(other.gameObject);
            // Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            Gamemanager.instance.IncrementRingcount();
        }
    }
}
