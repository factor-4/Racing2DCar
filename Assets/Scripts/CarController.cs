using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    public float carSpeed;
    public float maxPos = 1.6f;

    Vector3 position;
    public uiManager ui;

    bool currentPlatformAndroid = false;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        #if UNITY_ANDROID
                currentPlatformAndroid = true;
        #else
                currentPlatformAndroid = false;
        #endif
    }

    // Use this for initialization
    void Start () {
      //  ui = GetComponent<uiManager> ();
        position = transform.position;

        if (currentPlatformAndroid == true)
        {
            Debug.Log("Android");
        }
        else
        {
            Debug.Log("Windows");
        }
		
	}
	
	// Update is called once per frame
	void Update () {

        if (currentPlatformAndroid == true)
        {
            //android specific code

            TouchMove();
        }
        else
        {

            position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;

            position.x = Mathf.Clamp(position.x, -1.5502f, 1.5502f);

            transform.position = position;
        }

        position = transform.position;
        position.x = Mathf.Clamp(position.x, -1.5502f, 1.5502f);
        transform.position = position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy Car")
        {
            Destroy(gameObject);
            gameObject.SetActive(false);
            ui.gameOverActivated();

        }
    }


    void TouchMove()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float middle = Screen.width / 2;
            if (touch.position.x < middle && touch.phase == TouchPhase.Began)
            {
                MoveLeft();
            }
            else if (touch.position.x > middle && touch.phase == TouchPhase.Began)
            {
                MoveRight();
            }
        }
        else
        {
            SetVelocityZero();
        }
    }

    public void MoveLeft()
    {
        rb.velocity = new Vector2(-carSpeed, 0);
    }

    public void MoveRight()
    {
        rb.velocity = new Vector2(carSpeed, 0);
    }

    public void SetVelocityZero ()
    {
        rb.velocity = Vector2.zero;
    }
}
