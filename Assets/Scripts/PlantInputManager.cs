using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantInputManager : MonoBehaviour
{
    PlantManager plantManager;
    private bool isDragging = false;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        plantManager = transform.GetComponent<PlantManager>();
    }

    void ManageKeyboardInputs() {
        int midiKey = -1;
        for (int i = 0; i < 9; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                // Set midiKey based on the pressed number key
                midiKey = 60 + i;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            // Set midiKey based on the pressed number key
            midiKey = 69;
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            // Set midiKey based on the pressed number key
            midiKey = 70;
        }
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            // Set midiKey based on the pressed number key
            midiKey = 71;
        }
        if (midiKey != -1) {
            plantManager.PlayMidi(midiKey + 11);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(1)) {
            plantManager.Select();
        }
        if (Input.GetMouseButtonDown(0)) {
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        ManageKeyboardInputs();
        if (isDragging)
        {
            // Update the object's position based on the mouse position
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }
}
