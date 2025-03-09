using UnityEngine;

public class PaintVase : MonoBehaviour
{

    [SerializeField] GameObject mouseTracker;
    [SerializeField] float hRadius;
    [SerializeField] float vRadius;

    [SerializeField] float paintIntensity; 

    float alphaValue;
    Vector3 lastLocation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        paintIntensity *= 100; 
        alphaValue = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseTracker.transform.position.x > this.transform.position.x - hRadius && mouseTracker.transform.position.x < this.transform.position.x + hRadius
            && mouseTracker.transform.position.y > this.transform.position.y - vRadius && mouseTracker.transform.position.y < this.transform.position.y + vRadius) {

            if (lastLocation != mouseTracker.transform.position) {
                alphaValue += Mathf.Abs(Vector3.Magnitude(lastLocation - mouseTracker.transform.position)) / paintIntensity;
                if(alphaValue > 1) alphaValue = 1;
                lastLocation = mouseTracker.transform.position;
            }
        }
        this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaValue);
    }
}
