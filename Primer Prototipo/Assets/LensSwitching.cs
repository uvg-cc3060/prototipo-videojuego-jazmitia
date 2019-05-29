using UnityEngine;
using TMPro;
public class LensSwitching : MonoBehaviour
{
    GameManagerScript gm;

    public int selectedLens=0 ;
    public  TextMeshProUGUI textMesh;
    string [] lentes = new string[4] { "Normal", "X-Ray", "Night Vision","Electric Flow"};
    public GameObject key;
    public Color color;
    public GameObject cable;

    public GameObject cable1;
    float tiempo = 30.0f;

    public GameObject cable2;
    public GameObject secretmessage;
    public GameObject message;


    // Start is called before the first frame update
    void Start()
    {
        SelectLens();
        gm = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        cable = GameObject.FindGameObjectWithTag("cable");
        cable1 = GameObject.FindGameObjectWithTag("cable1");
        cable2 = GameObject.FindGameObjectWithTag("cable2");
        secretmessage = GameObject.FindGameObjectWithTag("secretmessage");
        message = GameObject.FindGameObjectWithTag("message");

        if (gm.keys == 0) {
            key = GameObject.FindGameObjectWithTag("key");


        }

    }

    // Update is called once per frame
    void Update()
    {
        tiempo = tiempo - Time.deltaTime;
        Debug.Log(tiempo);
        int pevieousSelectedLens = selectedLens;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {

            if (selectedLens >= transform.childCount - 1)
            {
                selectedLens = 0;
            }
            else
            {
                selectedLens++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {

            if (selectedLens <= 0)
            {
                selectedLens = transform.childCount-1;
            }
            else
            {
                selectedLens--;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            selectedLens = 0;
            try
            {
                secretmessage.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
                message.GetComponent<SpriteRenderer>().sortingLayerName = "Default";

                cable.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
                cable1.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
                cable2.GetComponent<SpriteRenderer>().sortingLayerName = "Default";

            }
            catch { }

            if (gm.keys == 0)
            {
                key.GetComponent<SpriteRenderer>().sortingLayerName = "Invisible";

            }


        }

        if (Input.GetKeyDown(KeyCode.Alpha2)&& transform.childCount>=2)
        {
            selectedLens = 1;
            try
            {
                secretmessage.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
                message.GetComponent<SpriteRenderer>().sortingLayerName = "Default";

                cable.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
                cable1.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
                cable2.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
            }
            catch { }

            if (gm.keys == 0)
            {
                key.GetComponent<Renderer>().material.SetColor("_Color", color);
                key.GetComponent<SpriteRenderer>().sortingLayerName = "Rayos X";
                key.SetActive(true);

            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedLens = 2;
            try
            {
                secretmessage.GetComponent<SpriteRenderer>().sortingLayerName = "lvl2";
                message.GetComponent<SpriteRenderer>().sortingLayerName = "Rayos X";

                cable.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
                cable1.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
                cable2.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
            }
            catch { }

            if (gm.keys == 0)
            {

                key.GetComponent<SpriteRenderer>().sortingLayerName = "Invisible";

            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            selectedLens = 3;
            try
            {
                secretmessage.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
                message.GetComponent<SpriteRenderer>().sortingLayerName = "Default";

            }
            catch { }

            if (gm.keys == 0)
            {
                key.GetComponent<SpriteRenderer>().sortingLayerName = "Invisible";

            }

            if (gm.unlocked==1) {
                cable.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
                cable1.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
                cable2.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
                Debug.Log("electric");

            }
        



        }



        if (pevieousSelectedLens != selectedLens) {
            tiempo = 30.0f;
            SelectLens();
        }


        if (selectedLens != 0) {
            textMesh.text = "Lentes: " + (lentes[selectedLens]).ToString() + " Tiempo: " + ((int)tiempo).ToString();


        }
        else
        {
            textMesh.text = "Lentes: " + (lentes[selectedLens]).ToString() ;

        }



        if (tiempo < 0) {
            selectedLens = 0;
            tiempo = 30.0f;
            Debug.Log("Reset");
            SelectLens();


        }

    }

    void SelectLens() {
        int i = 0;
        foreach (Transform lens in transform) {
            if (i == selectedLens)
            {
                lens.gameObject.SetActive(true);
            }
            else {
                lens.gameObject.SetActive(false);
            }

            i++;

        }

    }
}
