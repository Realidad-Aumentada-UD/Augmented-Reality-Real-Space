using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ## Scriptable Object 
* Contenedores de datos, donde crearemos una plantilla donde definiremos la información de cada Objeto
* y luego creamos el objeto, la cual usaremos para definir la información que tendrá cada item.
* Es decir cada modelo 3D
*/
[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string ItemName;
    public Sprite ItemImage;
    public string ItemDescription;
    public GameObject Item3DModel;
}
