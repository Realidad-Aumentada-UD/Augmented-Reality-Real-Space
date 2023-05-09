using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Se encargara de asignar y crear un boton por cada item que exista*/

public class DataManager : MonoBehaviour
{
    [SerializeField] private List<Item> items = new List<Item>();
    [SerializeField] private GameObject buttonContainer;
    [SerializeField] private ItemButtonManager itemButtonManager; 

    void Start()
    {
        GameManager.instance.OnItemsMenu += CreateButtons;
    }

    private void CreateButtons()
    {
        foreach (var item in items)
        {
            ItemButtonManager itemButton;
            itemButton = Instantiate(itemButtonManager, buttonContainer.transform);
            //asignar valor para cada uno de los elementos que contendra el boton
            itemButton.ItemName = item.ItemName;
            itemButton.ItemDescription = item.ItemDescription;
            itemButton.ItemImage = item.ItemImage;
            itemButton.Item3DModel = item.Item3DModel;
            //Nombrar cada boton
            itemButton.name = item.ItemName;
        }
        //Desuscribir al evento para evitar crear varias instancias de los mismo sbotones
        GameManager.instance.OnItemsMenu -= CreateButtons;
    }
}