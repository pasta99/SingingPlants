using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public GameObject lightPrefab; 
    List<GameObject> lights; 

    // Start is called before the first frame update
    void Start()
    {
        lights = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddLight() {
        GameObject go = Instantiate(lightPrefab);
        lights.Add(go);
    }

    public void RemoveLight() {
        Destroy(lights[lights.Count - 1]);
        lights.RemoveAt(lights.Count - 1);
    }

    public void SelectLight(GameObject light) {
        Debug.Log("Selected light");
        foreach (GameObject go in lights) {
            go.GetComponent<Light>().Select(false);
        }
        light.GetComponent<Light>().Select(true);
    }

    public float GetLightLevel(Vector2 position) {
        float light = 0; 
        foreach (GameObject go in lights) {
            float distance = (position - new Vector2(go.transform.position.x, go.transform.position.y)).magnitude;
            float lc = Mathf.Max(go.transform.localScale.x - (2 * distance), 0) / go.transform.localScale.x;
            light += lc;
        }
        // Debug.Log(light);
        return light;
    }
}
