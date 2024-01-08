using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    public float radius = 1; 
    bool selected = false; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (selected) {
            float changeSize = Input.GetAxis("Mouse ScrollWheel");
            radius += changeSize * Time.deltaTime * 500; 
            radius = Mathf.Max(1, radius);
        }
        transform.localScale = new Vector3(radius, radius, 1);
    }

    public void MakeSelectable(bool selectable) {
        transform.GetComponent<BoxCollider2D>().enabled = selectable;
    }

    public void Select(bool select) {
        selected = select; 
    }

    
}
