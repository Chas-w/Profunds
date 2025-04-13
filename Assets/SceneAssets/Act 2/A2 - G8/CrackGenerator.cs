using UnityEngine;

public class CrackGenerator : MonoBehaviour
{
    [SerializeField] Sprite[] crackSprites;
    int currentCrack;
    bool canContinue;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = crackSprites[0];
        canContinue = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canContinue)
        {
            currentCrack++;
            if (currentCrack == crackSprites.Length) {
                canContinue = false;
                this.GetComponent<SpriteRenderer>().sprite = null;
            }  else this.GetComponent<SpriteRenderer>().sprite = crackSprites[currentCrack];

        }
    }
}
