using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float jumpForce = 5f;

    private Rigidbody2D rb;
    public GameObject gameOverPanel;
    private bool isGameOver = false;
    public AudioSource jumpaudioSource;
    public AudioSource gameOveraudioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpaudioSource = gameObject.AddComponent<AudioSource>();
        jumpaudioSource.clip=Resources.Load<AudioClip>("JumpSound");

        gameOveraudioSource = gameObject.AddComponent<AudioSource>();
        gameOveraudioSource.clip = Resources.Load<AudioClip>("GameOverSound");
        /* audioSource1 = GetComponent<AudioSource>();
         audioSource2 = GetComponent<AudioSource>();
          if(audioSource1 != null )
          {
              audioSource1.clip = Resources.Load<AudioClip>("JumpSound");
          }
          if (audioSource2 != null)
          {
              audioSource2.clip = Resources.Load<AudioClip>("GameOverSound");
          }*/

    }

    void Update()
    {
        if (isGameOver) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
       if (jumpaudioSource!= null)
        {
            jumpaudioSource.Play();
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreManager.score++;
        Debug.Log("Score:" + ScoreManager.score);
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {

            EndGame();
        }
    }

    private void EndGame()
    {
        isGameOver = true;
        if(gameOveraudioSource != null)
        {
        gameOveraudioSource.Play();
        }
        gameOveraudioSource = null;
        //rb.velocity = Vector2.zero;
        if (gameOverPanel!= null)//GameObject.Find("GameOverPanel"))
        {
            gameOverPanel.SetActive(true);
        }
    }

}
