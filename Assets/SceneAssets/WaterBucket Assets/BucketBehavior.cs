using UnityEngine;
using UnityEngine.Rendering;

public class BucketBehavior : MonoBehaviour
{
    //Serialized
    [SerializeField] GameObject MouseTracker;

    //Public
    public int rainCount;

    //Private
    Vector3 mousePos;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = MouseTracker.transform.position;
        if (mousePos.x > 8.5f) mousePos = new Vector3(8.5f, mousePos.y, mousePos.z);
        if (mousePos.x < -8.5f) mousePos = new Vector3(-8.5f, mousePos.y, mousePos.z);
        this.transform.position = new Vector3(mousePos.x, -4.5f, 0);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Rain"))
        {
            rainCount++;
            Destroy(collision.gameObject);
        }
    }
}
