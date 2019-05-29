using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    GameManagerScript gm;
    public float speed;
    private Vector2 moveVelocity;
    public GameObject FirstDoor;
    public GameObject cable;
    public GameObject leveltblk;
    public GameObject lvl3blck;

    public GameObject lvl3door;

    public int llaveleectro = 0;
    public TextMeshProUGUI textMesh;
    public int eapachado = 0;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        gm = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        gm.unlocked = 0;
        leveltblk = GameObject.FindGameObjectWithTag("lvl2blktg");
        lvl3blck = GameObject.FindGameObjectWithTag("lvl3blktg");

        lvl3door = GameObject.FindGameObjectWithTag("lvl3door");
          FirstDoor = GameObject.FindGameObjectWithTag("Puerta");
        cable = GameObject.FindGameObjectWithTag("cable");

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;


        if (Input.GetKeyDown(KeyCode.E))
        {
            eapachado = 1;
        }


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
            try
            {
                leveltblk.GetComponent<SpriteRenderer>().sortingLayerName = "Default";

            }
            catch { }

        }

        if (collision.tag == "activateelectro")
        {
            if (llaveleectro == 0)
            {

                textMesh.text = "Necesitas la llave para poder interactuar con este objeto!";
            }
            else
            {
                textMesh.text = "Ya tienes acceso al generador. Presiona E para activarlo";

             

                    //cable.GetComponent<SpriteRenderer>().sortingLayerName = "Player";

            }


        }



        if (collision.tag == "cofre")
        {

            if (llaveleectro == 0)
            {
                textMesh.text = "Has conseguido una llave secreta (descubre para que sirve)";
                llaveleectro = llaveleectro + 1;

            }
            else
            {
                textMesh.text = "Ya ganaste esta llave.... no sabes para que sirve?";
            }

        

        }

        if (collision.tag == "botonpuertalvl2")
        {
            if (gm.unlocked == 0)
            {
                textMesh.text = "Necesitas electricidad para activar este boton";

            }
            else
            {
                textMesh.text = "Ya tienes acceso al boton. Presiona E para abrir la puerta";

            }

        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "botonpuertalvl2")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(lvl3door);
                try
                {
                    lvl3blck.GetComponent<SpriteRenderer>().sortingLayerName = "Default";

                }
                catch { }

            }
        }


            if (collision.tag == "activateelectro")
        {

            if (llaveleectro != 0)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    gm.unlocked = 1;
                    textMesh.text = "Electricidad activada";

                }

            }
        
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "botonpuertalvl2")
        {
            textMesh.text = "";

        }
        if (collision.tag == "activateelectro")
        {
            textMesh.text = "";
            Debug.Log("llegue");

        }

        if (collision.tag == "cofre")
        {
            textMesh.text = "";
            Debug.Log("llegue");

        }
    }




}
