using UnityEngine;
using UnityEngine.EventSystems;


public class dragDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject parent;
    [SerializeField] private float dragScale;
    [SerializeField] private GridJoueur grid;

    private GameObject draggedObject;
    private GameObject bateau;
    private GameObject bateauButton;
    private string draggedType;
    private GameObject textDraggedObject;

    GameObject getRayCastHit(Vector2 pos)
    {
        Ray ray = cam.ScreenPointToRay(pos);
        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            return hit.transform.gameObject;
        }
        return parent; // N'est jamais censé arriver
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        // Permet de reconnaitre quel bouton a été pressé et de faire appaitre l'image sur le curseur
        bateauButton = eventData.pointerPressRaycast.gameObject;
        draggedObject = Instantiate(bateauButton, parent.transform);
        
        draggedObject.transform.position = bateauButton.transform.position;
        draggedObject.transform.localScale = new Vector3(dragScale, dragScale, dragScale);
        draggedType = bateauButton.name;
        textDraggedObject = GameObject.Find(draggedType+" - TMP - "+ BoatManager.instance.GetActivePlayer());
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = 100.0f; //distance of the plane from the camera
        draggedObject.transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        // Détruit l'image de prévisualisation et fait apparaitre un bateau
        Destroy(draggedObject);
        bateau = getRayCastHit(eventData.position);
        if(bateau.name == "Box" && bateau.transform.parent.gameObject.name == "Grid")
        {
            grid.PlaceBoat(bateau, draggedType, bateauButton, textDraggedObject);
        }
    }
}
