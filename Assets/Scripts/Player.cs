using System;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour,IPausable
{
    [Header("Movement")]
    public float jumpForce = 30;
    
    [Header("Sound Effects")]
    public AudioClip jumpSound;
    public AudioClip deathSound;
    public AudioClip pointSound;
    
    private Rigidbody2D rb;
    private AudioSource audio;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();  
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && rb.velocity.y <= 0)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            audio.PlayOneShot(jumpSound);
        }

        if (rb.velocity.y <= 0)
            rb.rotation = -30;
        else
            rb.rotation = 30;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GameManager.Instance.Score++;
        audio.PlayOneShot(pointSound);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        audio.PlayOneShot(deathSound);
        rb.constraints = RigidbodyConstraints2D.None;
        GameManager.Instance.End();
        Destroy(this);
    }


    public bool IsPaused { get; set; }
    public void OnPause()
    {
        IsPaused = true;
        rb.isKinematic = true;
    }

    public void OnResume()
    {
        IsPaused = false;
        rb.isKinematic = false;
    }
}
