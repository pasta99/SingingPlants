using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatManager : MonoBehaviour
{
    public GameObject heatPrefab; 
    List<GameObject> heatSources; 

    // Start is called before the first frame update
    void Start()
    {
        heatSources = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddHeat() {
        GameObject go = Instantiate(heatPrefab, new Vector3(0, 0, 1), Quaternion.identity);
        heatSources.Add(go);
    }

    public void RemoveHeat() {
        Destroy(heatSources[heatSources.Count - 1]);
        heatSources.RemoveAt(heatSources.Count - 1);
    }

    public void SelectHeat(GameObject heat) {
        UnselectAll();
        heat.GetComponent<Heat>().Select(true);
    }

    public void UnselectAll() {
        foreach (GameObject go in heatSources) {
            go.GetComponent<Heat>().Select(false);
        }
    }

    public float GetHeatLevel(Vector2 position) {
        float heat = 0; 
        foreach (GameObject go in heatSources) {
            float distance = (position - new Vector2(go.transform.position.x, go.transform.position.y)).magnitude;
            float hc = Mathf.Max(go.transform.localScale.x - (2 * distance), 0) / go.transform.localScale.x;
            heat += hc;
        }
        // Debug.Log(light);
        return heat;
    }
}
