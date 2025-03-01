using UnityEngine;

public class LightbulbManager : MonoBehaviour
{

    [SerializeField] GameObject twisting;
    [SerializeField] GameObject lightbulb;

    Vector3 lightbulbStartPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lightbulbStartPosition = lightbulb.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (lightbulb.transform.position.y > 0.5f) lightbulb.transform.position = new Vector3(lightbulb.transform.position.x, lightbulbStartPosition.x - (twisting.GetComponent<TwistingBehavior>().totalRotation / 25), 0);
        else lightbulb.GetComponent<SpriteRenderer>().color = Color.yellow;

    }
}
