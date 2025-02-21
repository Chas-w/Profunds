using UnityEngine;

public class KeyBehavior : MonoBehaviour
{

    GameObject ruler;
    AudioSource keyNote;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ruler = GameObject.FindGameObjectWithTag("Ruler");
        keyNote = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ruler.GetComponent<RulerBehavior>().RulerHit(this.transform); //hits down ruler
            //keyNote.Play(); //will play note once added
        }
    }
}
