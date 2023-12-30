using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour
{
    private bool active; 
    // Start is called before the first frame update
    void Start()
    {
        active = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (active) {
            if (Input.GetMouseButtonDown(0)) {
                
            }
        }
    }

    public void Activate() {
        this.active = true; 
    }

    public void Deactivate() {
        this.active = false; 
    }
}
