using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerControll : MonoBehaviour
{
    public AudioClip blasterSound;
    AudioSource audio;
    


    [Header("General")]
    [Tooltip("m/s")][SerializeField] float speed = 6f; //скорость перемещения

    [SerializeField] float XClamp = 5.5f; //ограничение перемещения
    [SerializeField] float YClamp = 5.5f;

    [Header("Rotation")]

    [SerializeField] float xRotationFactor = -5f;
    [SerializeField] float yRotationFactor = 5f;
    //[SerializeField] float zRotationFactor = 4f;

    [Header("RotationOnMove")]

    [SerializeField] float xMoveRot = -20f;
    [SerializeField] float yMoveRot = 10f;
    [SerializeField] float zMoveRot = 10f;

    [SerializeField] GameObject[] guns;


    bool isControolEnabled = true;

    float xMove, yMove;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isControolEnabled)
        {
            MoveShip();
            RotateShip();
            FireGuns();
        }
    }

   

    void OnPlayerDeath()
    {
        print("Controll Off");
        isControolEnabled = false;
    }

    void MoveShip()
    {
         xMove = CrossPlatformInputManager.GetAxis("Horizontal");
         yMove = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xMove * speed * Time.deltaTime;
        float yOffset = yMove * speed * Time.deltaTime;

        float newXPos = transform.localPosition.x + xOffset;
        float newYPos = transform.localPosition.y + yOffset;

        float clampXPos = Mathf.Clamp(newXPos, -XClamp, XClamp);
        float clampYPos = Mathf.Clamp(newYPos, -YClamp, YClamp);


        transform.localPosition = new Vector3(clampXPos, clampYPos, transform.localPosition.z);
    }

    void RotateShip()
    {
        float xRot = transform.localPosition.y * xRotationFactor + yMove * xMoveRot;
        float yRot = transform.localPosition.x * yRotationFactor + xMove * yMoveRot;
        float zRot = xMove * zMoveRot;



        transform.localRotation = Quaternion.Euler(xRot,yRot,zRot);
    }

    void FireGuns()
    {
        
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            
            if (!audio.isPlaying)
                audio.PlayOneShot(blasterSound);

            foreach (GameObject gun in guns)
            {
                ActiveGuns();
            }
        } else
        {
            DeActiveGuns();
        }
    }
    void ActiveGuns()
    {
foreach(GameObject gun in guns)
        {
            gun.GetComponent<ParticleSystem>().enableEmission = true;
            
        }
    }
    void DeActiveGuns()
    {
        foreach(GameObject gun in guns)
        {
            gun.GetComponent<ParticleSystem>().enableEmission = false;
        }
    }
}