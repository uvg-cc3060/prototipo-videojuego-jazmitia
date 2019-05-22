using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    GameManagerScript gm;
    public float speed;
    private Vector2 moveVelocity;
    public GameObject FirstDoor;
    public GameObject leveltblk;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        gm = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

        leveltblk = GameObject.FindGameObjectWithTag("lvl2blktg");


        FirstDoor = GameObject.FindGameObjectWithTag("Puerta");

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;

    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "key")
        {
            gm.keysum();
            Destroy(collision.gameObject);
            Destroy(FirstDoor);
            leveltblk.GetComponent<SpriteRenderer>().sortingLayerName = "Defult";

            
        }
    }

}
