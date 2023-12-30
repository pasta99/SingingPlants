using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour
{
    private bool active; 
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
        Deactivate();
    }

    // Update is called once per frame
    void Update()
    {
        if (active) {
            if (Input.GetMouseButtonDown(0)) {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null)
                {
                    GameObject hitObject = hit.collider.gameObject;
                    Plant plant = hitObject.GetComponent<Plant>();
                    if (plant != null) {
                        plant.AddWater(0.1f);
                    }
                }
            }

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }

    public void Activate() {
        this.active = true; 
        spriteRenderer.enabled = true;
    }

    public void Deactivate() {
        this.active = false; 
        spriteRenderer.enabled = false; 
    }

    public void Toggle() {
        if (active) {
            Deactivate();
        }
        else {
            Activate();
        }
    }
}
