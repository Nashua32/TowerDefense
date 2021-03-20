using UnityEngine;

public class ControlCamera : MonoBehaviour
{

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    private bool Move = true;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Move = !Move;
        }
        if (!Move)
        {
            return;
        }
        if (Input.GetKey("up") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.right*panSpeed*Time.deltaTime, Space.World);
        }
        if (Input.GetKey("down") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.left*panSpeed*Time.deltaTime, Space.World);
        }
        if (Input.GetKey("right") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.back*panSpeed*Time.deltaTime, Space.World);
        }
        if (Input.GetKey("left") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.forward*panSpeed*Time.deltaTime, Space.World);
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        
        Vector3 pos = transform.position;
        pos.y -= scroll* 1000 *scrollSpeed* Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;


    }
}
