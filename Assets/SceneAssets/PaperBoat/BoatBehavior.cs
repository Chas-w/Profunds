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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isTurningRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTurningRight) {
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, rotationOne.transform.rotation, 0.05f);
            if (this.transform.rotation == rotationOne.transform.rotation) isTurningRight = false; 
        } else
        {
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, rotationTwo.transform.rotation, 0.05f);
            if (this.transform.rotation == rotationTwo.transform.rotation) isTurningRight = true;
        }
        
        //this.transform.position = new Vector3(mouseTracker.transform.position.x, 0, 0);
        this.transform.position += new Vector3(0, downSpeed * Time.deltaTime, 0);
        
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
