using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    // public RenderTexture background;
    // public ComputeShader compute;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     background = createBlankTexture(1000, 500);
    //     transform.GetComponentInChildren<MeshRenderer>().material.mainTexture = background;
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     compute.SetTexture(0, "Result", background);
    //     compute.Dispatch(0, 8, 8, 1);
    //     // Graphics.Blit(background, positionTexture);
    // }

    // RenderTexture createBlankTexture(int width, int height){
    //     RenderTexture resultTexture = new RenderTexture(width, height, 24);
    //     resultTexture.enableRandomWrite = true;
    //     resultTexture.filterMode = FilterMode.Point;
    //     resultTexture.Create();

    //     return resultTexture;
    // }

    LightEx[] lights;

    void Start() {
        lights = new LightEx[1];
        lights[0].position = new Vector2(-3, 0);
        lights[0].outsideRadius = 5f;
        lights[0].innerRadius = 0.5f;
    }

    public float GetLightLevel(Vector2 position) {
        foreach (var l in lights) {
            float distance = (position - l.position).magnitude;
            if (distance < l.outsideRadius) {
                return 1; 
            }
        }
        return 0;
    }

}

public struct LightEx {
    public Vector2 position; 
    public float innerRadius;
    public float outsideRadius;
} 
