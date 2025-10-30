using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;



public class Click : MonoBehaviour
{
    private Camera mainCamera;
    private Controles playerControls;
    private Vector2 clickInput;
   

    private void Awake()
    {
        playerControls = new Controles();

        mainCamera = Camera.main;

    }
    private void OnEnable()
    {
        playerControls.Player.Enable();
        playerControls.Player.click.performed += OnClick;

    }
    private void OnDisable()
    {
        playerControls.Player.click.performed -= OnClick;
        playerControls.Player.Disable();
    }
    private void OnClick(InputAction.CallbackContext context)
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

        if (hit.collider != null)
        {
            Debug.Log("Você clicou em: " + hit.collider.tag);

            // Coletar chave
            if (hit.collider.CompareTag("ball"))
            {
                Debug.Log("bola");
                
            }
        }
    }

    


    void Start()
    {
        Debug.Log("ababababa");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
