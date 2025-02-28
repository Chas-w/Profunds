using UnityEngine;

public class CameraFollowBoat : MonoBehaviour
{

    [SerializeField] GameObject boat;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(boat.transform.position.x, boat.transform.position.y - 3, -10);
    }
}
