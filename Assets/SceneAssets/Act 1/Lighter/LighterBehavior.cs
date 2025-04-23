using System.Collections;
using UnityEngine;

public class LighterBehavior : MonoBehaviour
{
    Animator anim;
    [SerializeField] Animator flameAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            anim.SetTrigger("Lighting");
            StartCoroutine(StartFlame());
        }
        if (Input.GetMouseButtonUp(0)) {
            anim.SetTrigger("LetGo");
            flameAnim.SetTrigger("LetGo");
        } 
    }

    IEnumerator StartFlame()
    {
        yield return new WaitForSeconds(0.3f);

        flameAnim.SetTrigger("Lighting");
    }
}
