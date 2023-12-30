using UnityEngine;

public class PlantMover : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 lastPos;

    private GameObject draggedObject; 

    private LightManager lightManager;
    private HeatManager heatManager;

    void Start() {
        lightManager = GameObject.Find("Controller").GetComponent<LightManager>();
        heatManager = GameObject.Find("Controller").GetComponent<HeatManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleMouseDown();
        }
        else if (Input.GetMouseButton(0))
        {
            HandleMouseDrag();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            HandleMouseUp();
        }
    }

    private void HandleMouseDown()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            draggedObject = hit.collider.gameObject;
            isDragging = true;
            lastPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (draggedObject.name == "Light(Clone)") {
                Light l = draggedObject.GetComponent<Light>();
                if (l != null) {
                    lightManager.SelectLight(draggedObject);
                    heatManager.UnselectAll();
                }
            }

            if (draggedObject.name == "Heat(Clone)") {
                Heat l = draggedObject.GetComponent<Heat>();
                if (l != null) {
                    heatManager.SelectHeat(draggedObject);
                    lightManager.UnselectAll();
                }
            }
        }
    }

    private void HandleMouseDrag()
    {
        if (isDragging)
        {
            Vector3 offset = lastPos - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            draggedObject.transform.position -= new Vector3(offset.x, offset.y, 0);
            lastPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void HandleMouseUp()
    {
        isDragging = false;
    }
}
