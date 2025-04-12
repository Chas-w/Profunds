using UnityEngine;

public class BoatBehavior : MonoBehaviour
{

    [SerializeField] GameObject boat;
    [SerializeField] GameObject mouseTracker;

    [SerializeField] Transform startPosition;
    [SerializeField] Transform rotationOne;
    [SerializeField] Transform rotationTwo;

    [SerializeField] float downSpeed;

    bool isTurningRight;
    Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isTurningRight = true;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        
        if (isTurningRight) {
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, rotationOne.transform.rotation, 0.005f);
            if (this.transform.rotation == rotationOne.transform.rotation || this.transform.rotation.z > 0.2484) isTurningRight = false; 
        } else
        {
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, rotationTwo.transform.rotation, 0.005f);
            if (this.transform.rotation == rotationTwo.transform.rotation || this.transform.rotation.z < -0.226) isTurningRight = true;
        }

        Debug.Log(this.transform.rotation.z);
        
        this.transform.position = new Vector3(mousePos.x, this.transform.position.y, this.transform.position.z);
        this.transform.position += new Vector3(0, downSpeed * Time.deltaTime, 0);

        if(this.transform.position.x > 4.1f) this.transform.position = new Vector3(4.1f, this.transform.position.y, this.transform.position.z);
        if (this.transform.position.x < -4.1f) this.transform.position = new Vector3(-4.1f, this.transform.position.y, this.transform.position.z);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Rock"))
        {
            this.transform.position = startPosition.position;
            this.transform.rotation = startPosition.rotation;
        }
    }




}
