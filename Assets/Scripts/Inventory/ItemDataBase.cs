using UnityEngine;

[createAssetMenu(fileName = "Nueva DB" , menuName = "Inventario/Base de datos")]
public class ItemDataBase : ScriptableObject
{
    public List<ItemData> items = new List<ItemData>();

    private Dictionary <string , ItemData> itemDictionary = new Dictionary <string, ItemData>();

    public void initializeDataBase(){
        itemDictionary.clear();

        foreach (ItemData item in items )
        {
            if (string.IsNullOrEmpty(item.id.ToString())){
                continue;
            }
            if (!itemDictionary.containsKey(item.id.ToString())){
                itemDictionary.add(item.id.ToString() , item);
            }
        }

    }
    public ItemData BuscarItem(string id){
        if (itemDictionary.Count == 0 && items.count > 0){
            initializeDataBase();
        }

        if (itemDictionary.TryGetValue(id.ToString(), out ItemData)){
            return ItemData;
        }
        else
        {
            return null;
        }
    }

}
