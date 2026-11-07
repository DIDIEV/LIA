using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private Camera camera;
    void start()
    {
        camera = Camera.main;
    }
    void update()
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
