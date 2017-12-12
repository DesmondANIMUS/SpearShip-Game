using System;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private bool canYouMove = true;

    public float panSpeed = 50f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;
    
	void Update ()
    {
        if (GameManager.GameOver)
        {
            enabled = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            canYouMove = !canYouMove;

        if (!canYouMove)
            return;

        ScrollTheCamera();
        PanTheCamera();
        RotateTheCamera();
    }

    private void RotateTheCamera()
    {
        if(Input.GetKey("q"))
            transform.Rotate(Vector3.up * Time.deltaTime * scrollSpeed * 5f, Space.World);
        if(Input.GetKey("e"))
            transform.Rotate(Vector3.down * Time.deltaTime * scrollSpeed *5f, Space.World);
    }

    private void PanTheCamera()
    {
        if ((Input.GetKey("w")) || (Input.mousePosition.y >= (Screen.height - panBorderThickness)))
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);

        if ((Input.GetKey("s")) || (Input.mousePosition.y <= panBorderThickness))
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);

        if ((Input.GetKey("a")) || (Input.mousePosition.x <= panBorderThickness))
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);

        if ((Input.GetKey("d")) || (Input.mousePosition.x >= (Screen.width - panBorderThickness)))
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
    }

    private void ScrollTheCamera()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");        
        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        
        transform.position = pos;
    }
}
