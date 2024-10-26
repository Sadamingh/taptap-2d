using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwiseCatMovement : MonoBehaviour
{
    public AK.Wwise.Event walkSoundPlay;
    public AK.Wwise.Event runSoundPlay;
    public AK.Wwise.Event jumpSoundPlay;
    private bool isSoundPlaying;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded = false;
    private bool isRunning = false;

    void CallBackFunction(object in_cookie, AkCallbackType callType, object in_info)
    {
        if (callType == AkCallbackType.AK_EndOfEvent)
        {
            isSoundPlaying = false;
        }


    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        CheckGrounded();
        PlayFootstepSounds();
        //PlayJumpSound();

    }

    void CheckGrounded()
    {
        // Here you should use your grounded check logic, possibly using raycasting or colliders
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
    }

    void PlayFootstepSounds()
    {
        // Play walk or run sounds only when grounded and moving horizontally
        if (isGrounded && Mathf.Abs(rb.velocity.x) > 0.1f)
        {
            isRunning = Input.GetKey(KeyCode.LeftShift);  // Press LeftShift to run

            if (isRunning && !isSoundPlaying)
            {
                runSoundPlay.Post(gameObject);
                isSoundPlaying = true;

            }
            else if (!isRunning && !isSoundPlaying)
            {
                walkSoundPlay.Post(gameObject);
            }
        }
        //else
        //{
           
        //}
    }

    //void PlayJumpSound()
   // {
        // Play jump sound when jumping and grounded becomes false
    //    if (Input.GetButtonDown("Jump") && isGrounded)
    //    {
    //        jumpAudioSource.Play();
     //   }
   // }
}

