
using TMPro;
using Unity.AppUI.UI;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
  [HideInInspector]public ItemData itemData;
  [HideInInspector]public int cantidad;
  public Image icono;
  private TextMeshProUGUI cantidadText;
  void start()
    {
        cantidadText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void setItem(ItemData itemData, int cantidad)
    {
        this.itemData = itemData;
        this.cantidad = cantidad;

        icono.sprite = itemData.icono;
        cantidadText.text = cantidad.ToString();
    }

    public void clearItem()
    {
        itemData = null;
        cantidad = 0;
        icono.sprite = null;
        cantidadText.text = "";
    }

}
