using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    LibPdInstance pd;
    public float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        pd = transform.GetComponent<LibPdInstance>();
        pd.SendFloat("freq", 600);
    }

    void Update()
    {
        // Get input values for horizontal and vertical axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);

        // Normalize the movement vector to ensure consistent speed in all directions
        movement = movement.normalized * moveSpeed * Time.deltaTime;

        // Move the GameObject based on the input
        transform.Translate(movement);

        float freq = Mathf.Lerp(200, 1000, (transform.position.x + 8) / 19);
        pd.SendFloat("freq", freq);
    }
}
