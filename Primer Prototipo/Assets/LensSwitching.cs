using UnityEngine;
using TMPro;
public class LensSwitching : MonoBehaviour
{

    public int selectedLens=0 ;
    public  TextMeshProUGUI textMesh;
    string [] lentes = new string[3] { "Thermal", "X-Ray", "Night Vision"};
    public GameObject key;
    public Color color;

    // Start is called before the first frame update
    void Start()
    {
        SelectLens();
        key = GameObject.FindGameObjectWithTag("key");
    }

    // Update is called once per frame
    void Update()
    {
         

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
            key.GetComponent<SpriteRenderer>().sortingLayerName = "Invisible";

        }

        if (Input.GetKeyDown(KeyCode.Alpha2)&& transform.childCount>=2)
        {
            selectedLens = 1;
            key.GetComponent<Renderer>().material.SetColor("_Color", color);
            key.GetComponent<SpriteRenderer>().sortingLayerName = "Rayos X";
            key.SetActive(true);

        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedLens = 2;
            key.GetComponent<SpriteRenderer>().sortingLayerName = "Invisible";

        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            selectedLens = 3;
            key.GetComponent<SpriteRenderer>().sortingLayerName = "Invisible";

        }



        if (pevieousSelectedLens != selectedLens) {
            SelectLens();
        }
        textMesh.text = "Lentes: "+(lentes[selectedLens]).ToString();
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
