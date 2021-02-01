using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class playercontroller : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb2d;

    public float time = 10f;

    public AudioClip MusicClipOne;
    public AudioClip MusicClipTwo;
    public AudioSource intoSource;
    public AudioSource doorSource;
    public AudioSource loseSource;

    private int count;

    public Text countText;
    public Text winText;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        count = 0;
        SetCountText ();
        intoSource = GetComponent<AudioSource> ();
        doorSource = GetComponent<AudioSource> ();
        loseSource = GetComponent<AudioSource> ();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");

        float moveVertical = Input.GetAxis ("Vertical");

        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

        rb2d.AddForce (movement * speed);

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.collider.tag == "End")
        {
            count = count + 1;
            Destroy(collision.collider.gameObject);
            SetCountText ();
            doorSource.Play ();
        }
    }

    void SetCountText ()
    {
        countText.text = "Score: " + count.ToString ();

        if (count == 1)
        {
            winText.text = "You Win! Made by Regan Wheeless.";
            Destroy(gameObject);
        }
    }

    public void Update()
     {
         if (time > 0)
         {
             time -= Time.deltaTime;
         }

         if (time == 0)
         {
             loseSource.Play ();
         }
        
     }
}
