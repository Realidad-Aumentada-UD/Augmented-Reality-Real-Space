using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARInteractionsManager : MonoBehaviour
{
    [SerializeField] private Camera aRCamera;
    private ARRaycastManager aRRaycastManager; 
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private GameObject aRPointer;
    private GameObject item3DModel;
    private bool isInitialPosition;

    public GameObject Item3DModel{
        set{
            item3DModel = value;
            item3DModel.transform.position = aRPointer.transform.position;
            item3DModel.transform.parent = aRPointer.transform;
            isInitialPosition = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        aRPointer = transform.GetChild(0).gameObject;
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        GameManager.instance.OnMainMenu += SetItemPosition;
    }
    // Update is called once per frame
    void Update()
    {
        // dar posicion inicial al modelo creado
        if (isInitialPosition)
        {
            //defino mitad de la pantalla
            Vector2 middlePointScreen = new Vector2(Screen.width/2,Screen.height/2 );
            aRRaycastManager.Raycast(middlePointScreen, hits, TrackableType.Planes);
            if (hits.Count >0)
            {
                transform.position=hits[0].pose.position;
                transform.rotation=hits[0].pose.rotation;
                aRPointer.SetActive(true);
                isInitialPosition= false;
            }
        }
    }

    private void SetItemPosition(){
        if (item3DModel != null)
        {
            item3DModel.transform.parent = null;
            aRPointer.SetActive(false);
            item3DModel = null;
        }
    } 

    //Función en caso que yo quiera eliminar el modelo 3d que esta RA
    public void DeleteItem(){
        Destroy(item3DModel);
        aRPointer.SetActive(false);
        GameManager.instance.MainMenu();
    }
}
