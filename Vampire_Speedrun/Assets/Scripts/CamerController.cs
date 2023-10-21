using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class CamerController : MonoBehaviour
{
    float playerXVel;
    float playerYVel;
    bool playerGrounded;

    private void Start()
    {



    }

    //room camera
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private float cameraXVelThreshold = 7;
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float upDistance;
    [SerializeField] private float cameraSpeed;
    [SerializeField] private float fallCameraVelocity;
    private float lookAhead;
    private float lookVertical;

    private int directionX = 0;
    private int directionY = 0;

    private bool activateFallCamera = false;

    public float transitionDuration = 0.1f;

    private void Update()
    {
       

        


        GameObject go = GameObject.Find("Player");
        PlayerMovement playerMovement = go.GetComponent<PlayerMovement>();
        float playerXVel = playerMovement.xVelocity;
        float playerYVel = playerMovement.yVelocity;
        bool playerGrounded = playerMovement.IsGrounded();

        //room camera
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed * Time.deltaTime);

        //follow player

        if (playerXVel < (cameraXVelThreshold * -1)) // pressing a
        {
            
            directionX = -1;
        }
        if (playerXVel > cameraXVelThreshold ) // pressing d
        {
            
            directionX = 1;
        }


        
        if ((playerYVel < -fallCameraVelocity) || Input.GetKey(KeyCode.S))
        {
            StartCoroutine("FallCamera");
        }
        else if (playerYVel >= 0.0 || playerGrounded)
        {
            activateFallCamera = false;
            StartCoroutine("RiseCamera");
        }

        if (activateFallCamera)
        {
            if (playerYVel < 0 || Input.GetKey(KeyCode.S))
            {
                directionY = -1;
            }
        }

        

        transform.position = new Vector3(player.position.x + lookAhead, player.position.y + lookVertical, transform.position.z);

        Debug.Log("player y vel: " + playerYVel);
        Debug.Log("player grounded: " + playerGrounded);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * directionX), Time.deltaTime * cameraSpeed);
        lookVertical = Mathf.Lerp(lookVertical, (upDistance * directionY), Time.deltaTime * cameraSpeed);
    }

    IEnumerator FallCamera()
    {

        // execute block of code here


        yield return new WaitForSeconds(0);

        activateFallCamera = true;
    }

    IEnumerator RiseCamera()
    {

        // execute block of code here


        yield return new WaitForSeconds(0);
        
        directionY = 1;

    }

}
