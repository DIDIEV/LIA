using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private Camera camera;
    void Start()
    {
        camera = Camera.main;
    }
    void Update()
    {   if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(camera.transform.position , camera.transform.forward , out RaycastHit hit , 5))
            {
                ObjetoInteractuable objetoInteractuable = hit.collider.gameObject.GetComponent<ObjetoInteractuable>();
                if (objetoInteractuable != null)
                {
                    objetoInteractuable.interactuar();
                }
            }    
        }
        
    }
}
