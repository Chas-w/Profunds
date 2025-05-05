using UnityEngine;

public class FilmPieceBehavior : MonoBehaviour
{
    Camera cam;
    bool isHeld;
    float xDisplacement;
    float yDisplacement;

    public bool isInFinalPosition;
    public bool isLarryFilm;
    public GameObject filmManager;

    [SerializeField] GameObject finalPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        isInFinalPosition = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInFinalPosition)
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonUp(0) && isHeld)
            {
                filmManager.GetComponent<FilmManager>().currentFilmPiece = null;
                isHeld = false;
            }

            if (isHeld)
            {
                this.transform.position = new Vector3(mousePos.x - xDisplacement, mousePos.y - yDisplacement, 0);
                Debug.Log("isHeld");
            }

            if(!isLarryFilm)
            {
                if (this.transform.position.x > 9) this.transform.position = new Vector3(6.8f, this.transform.position.y, 0);
                if (this.transform.position.x < -9) this.transform.position = new Vector3(-6.8f, this.transform.position.y, 0);

                if (this.transform.position.y < -5) this.transform.position = new Vector3(this.transform.position.x, -3.3f, 0);
                if (this.transform.position.y > 5) this.transform.position = new Vector3(this.transform.position.x, 3.3f, 0);
            }
            


            if (this.transform.position.x > finalPosition.transform.position.x - 0.1f && this.transform.position.x < finalPosition.transform.position.x + 0.1f
                && this.transform.position.y > finalPosition.transform.position.y - 0.1f && this.transform.position.y < finalPosition.transform.position.y + 0.1f)
            {

                this.transform.position = new Vector3(finalPosition.transform.position.x, finalPosition.transform.position.y, 0);

                isInFinalPosition = true;
                isHeld = false;
                filmManager.GetComponent<FilmManager>().currentFilmPiece = null;
            }
        }



    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0) && !isInFinalPosition && (filmManager.GetComponent<FilmManager>().currentFilmPiece == null || filmManager.GetComponent<FilmManager>().currentFilmPiece == this.gameObject))
        {
            isHeld = true;

            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            xDisplacement = mousePos.x - this.transform.position.x;
            yDisplacement = mousePos.y - this.transform.position.y;

            filmManager.GetComponent<FilmManager>().currentFilmPiece = this.gameObject;
        }
    }
}
