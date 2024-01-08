using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAnimator : MonoBehaviour
{
    bool growing; 
    bool shrinking; 
    
    float maxSize; 
    Vector3 deltaSize;

    public float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        maxSize = transform.localScale.x * 1.1f;
        deltaSize = transform.localScale * 0.01f; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Grow() {
        Debug.Log("Called grow");
        growing = true; 
        shrinking = false; 
        IEnumerator cor = GrowEnum();
        StartCoroutine(cor);
    }

    IEnumerator GrowEnum() {
        Debug.Log("Called growENUM");
        Debug.Log(growing);
        while (true) {
            if (growing) {
                Debug.Log("Growing");
                transform.localScale += deltaSize;
                if (transform.localScale.x >= maxSize) {
                    growing = false;
                    Shrink();
                    break;
                }
                yield return new WaitForSeconds(waitTime);
            }
        }
    } 
    
    public void Shrink() {
        growing = false; 
        shrinking = true; 
        StartCoroutine(ShrinkEnum());
    }

    IEnumerator ShrinkEnum() {
        while (true) {
            if (shrinking) {
                transform.localScale -= deltaSize;
                if (transform.localScale.x <= 1) {
                    shrinking = false;
                    Grow();
                    break;
                }
                yield return new WaitForSeconds(waitTime);
            }
        }
    } 
}
