using UnityEngine;

public class StickBehavior : MonoBehaviour
{

    Camera cam;
    bool isHeld;
    bool isInFinalPosition;

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
        if (!isInFinalPosition) {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonUp(0))
            {
                isHeld = false;
            }

            if (isHeld) {
                //this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(mousePos.x, mousePos.y, 0), 0.01f);
                this.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
                Debug.Log("isHeld");
            }

            if(this.transform.position.x > 9) this.transform.position = new Vector3(6.8f, this.transform.position.y, 0);
            if (this.transform.position.x < -9) this.transform.position = new Vector3(-6.8f, this.transform.position.y, 0);

            if (this.transform.position.y < -5) this.transform.position = new Vector3(this.transform.position.x, -3.3f, 0);
            if (this.transform.position.y > 5) this.transform.position = new Vector3(this.transform.position.x, 3.3f, 0);


            if (this.transform.position.x > finalPosition.transform.position.x - 0.1f && this.transform.position.x < finalPosition.transform.position.x + 0.1f
                && this.transform.position.y > finalPosition.transform.position.y - 0.1f && this.transform.position.y < finalPosition.transform.position.y + 0.1f)
            {
                
                this.transform.position = new Vector3(finalPosition.transform.position.x, finalPosition.transform.position.y, 0);
                this.transform.rotation = finalPosition.transform.rotation;

                //this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                isInFinalPosition = true;
                isHeld = false;
            }
        }

        

    }

    private void OnMouseOver()
    {
        Debug.Log("MouseOver");
        if (Input.GetMouseButton(0)) {
            Debug.Log("IsClicked");
            isHeld = true;
        }
    }
}
