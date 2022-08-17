using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public float inc;

    public float min;

    public float max;

    public AudioSource src;
    public int lossScore = 0;
    public Text lossText;

    public int playerHealth = 3;
    public Text HP;

    // Start is called before the first frame update
    void Start()
    {
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        move();

        if (playerHealth == 0)
        {
            Invoke("Restart", 1f);
        }

    }

    void move()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + inc, min, max), transform.position.y, transform.position.z);

        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x - inc, min, max), transform.position.y, transform.position.z);

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
          
            src.Play();
            playerHealth -= 1;
            HP.text = "Health: " + playerHealth;

            lossScore += 1;
            lossText.text = "Losses: " + lossScore;
        }
    }
   

    void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
