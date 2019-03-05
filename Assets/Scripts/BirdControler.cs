using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControler : MonoBehaviour {

    public float flyPower=50;

    public AudioClip flyClip;
    public AudioClip gameOverClip;
    private AudioSource audioSource;

    private Animator anim;

	GameObject obj;
	GameObject gameController;

	void Start () {
        obj = gameObject;
        audioSource = obj.GetComponent<AudioSource>();
        audioSource.clip = flyClip;
		anim = obj.GetComponent<Animator>();
		anim.SetFloat("flyPower", 0);
		anim.SetBool("isDead", false);
		if (gameController == null)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController");

        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!gameController.GetComponent<GameControler>().isEndGame)
            {
                audioSource.Play();
            }
            
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, flyPower));
        }
		anim.SetFloat("flyPower", obj.GetComponent<Rigidbody2D>().velocity.y);
	}
    private void OnCollisionEnter2D(Collision2D other)
    {
		anim.SetBool("isDead", true);
		EndGame();
	}
    private void OnTriggerExit2D(Collider2D collision)
    {
        gameController.GetComponent<GameControler>().GetPoint();
    }
    void EndGame()
    {
		audioSource.clip = gameOverClip;
        audioSource.Play();
        gameController.GetComponent<GameControler>().EndGame();
    }
}
