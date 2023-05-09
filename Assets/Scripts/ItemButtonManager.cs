using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*Se encargará de mostrar información del botón con respecto al item asociado*/
public class ItemButtonManager : MonoBehaviour
{
    private string itemName;
    private string itemDescription;
    private Sprite itemImage;
    private GameObject item3DModel;

    public string ItemName{
        set{
            itemName = value;
        }
    }

    public string ItemDescription{
        set => itemDescription = value;
    }

    public Sprite ItemImage{
        set => itemImage = value;
    }

    public GameObject Item3DModel{
        set => item3DModel = value;
    }
    // Start is called before the first frame update
    void Start()
    {
        //cuando se cree el botón este automáticamente asigne los valores
        transform.GetChild(0).GetComponent<Text>().text = itemName;
        transform.GetChild(2).GetComponent<Text>().text = itemDescription;
        transform.GetChild(1).GetComponent<RawImage>().texture = itemImage.texture;

        var button= GetComponent<Button>();
        button.onClick.AddListener(GameManager.instance.ARPosition);
        button.onClick.AddListener(Create3DModel);
    }

    private void Create3DModel(){
        Instantiate(item3DModel);
    }
}
