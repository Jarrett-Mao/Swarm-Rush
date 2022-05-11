using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairCursor : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite blackCross;
    public Sprite redCross;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseCursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouseCursorPos;

        if(Input.GetMouseButtonDown(0)){
            StartCoroutine(ChangeSprite(blackCross , redCross));
        }
    }

    IEnumerator ChangeSprite(Sprite currSprite, Sprite newSprite){
        spriteRenderer.sprite = newSprite;
        // yield return StartCoroutine(ChangeSprite(newSprite, currSprite))
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.sprite = currSprite;
    }
}
