using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    // Eventos de nuestra aplicación
    public event Action OnMainMenu;
    public event Action OnItemsMenu;
    public event Action OnARPosition;

    // Patron singleton
    public static GameManager instance;

    private void Awake(){
        // aseguramos que solo exista una sola instancia de GameManager
        if(instance != null && instance != this){
            Destroy(gameObject);
        }else{
            instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        MainMenu();
    }

    // 
    public void MainMenu(){
        OnMainMenu?.Invoke();
        Debug.Log("Main menu activated");
    }

    public void ItemsMenu(){
        OnItemsMenu?.Invoke();
        Debug.Log("Items menu activated");
    }

    public void ARPosition(){
        OnARPosition?.Invoke();
        Debug.Log("AR Position activated");
    }

    public void CloseAPP(){
         Application.Quit();
    }
}
