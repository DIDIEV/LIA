using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nueva DB" , menuName = "Inventario/Base de datos")]
public class ItemDataBase : ScriptableObject
{
    public List<ItemData> items = new List<ItemData>();

    private Dictionary <string , ItemData> itemDictionary = new Dictionary <string, ItemData>();

    public void initializeDataBase(){
        itemDictionary.Clear();

        foreach (ItemData item in items )
        {
            if (string.IsNullOrEmpty(item.id.ToString())){
                continue;
            }
            if (!itemDictionary.ContainsKey(item.id.ToString())){
                itemDictionary.Add(item.id.ToString() , item);
            }
        }
        Debug.Log("Base de datos inicializada");

    }
    public ItemData BuscarItem(string id){
        if (itemDictionary.Count == 0 && items.Count > 0){
            initializeDataBase();
        }

        if (itemDictionary.TryGetValue(id.ToString(), out ItemData itemData)){
            return itemData;
        }
        else
        {
            return null;
        }
    }

}
