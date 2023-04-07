using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] CameraMovement mainCam;

    public static InputHandler Instance { get; private set; }

    Vector3 previousMousePos = Vector3.zero;

    //Creates the instance if it does not already exist
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }

        Instance = this;
    }

    /// <summary>
    /// Detects the finger dragging on the screen and moves the camera left and right along the hallway accordingly
    /// </summary>
    public void DetectDrag()
    {
        foreach (Touch touch in Input.touches)
        {
            //Detects dragging finger side to side for camera movement
            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 touchWorldPos = Camera.main.ScreenToWorldPoint(touch.position);

                float velocity = Vector3.Distance(touchWorldPos, Camera.main.ScreenToWorldPoint(touch.position - touch.deltaPosition)) / touch.deltaTime;

                if (touch.deltaPosition.x > 0)
                {
                    mainCam.SetVelocity(velocity / 2, 0);
                }
                if (touch.deltaPosition.x < 0)
                {
                    mainCam.SetVelocity(velocity / 2, 1);
                }
            }
        }
    }

    /// <summary>
    /// Detects mouse click and drag and moves the camera left and right along the hallway accordingly
    /// </summary>
    public void DetectMouseDrag()
    {
        //Detects dragging mouse side to side for camera movement
        if (Input.GetMouseButton(0))
        {
            Vector3 deltaPosition = previousMousePos - Input.mousePosition;
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float velocity = Vector3.Distance(mouseWorldPos, Camera.main.ScreenToWorldPoint(Input.mousePosition - deltaPosition)) / Time.deltaTime;

            if (deltaPosition.x < 0)
            {
                mainCam.SetVelocity(velocity / 2, 0);
            }
            if (deltaPosition.x > 0)
            {
                mainCam.SetVelocity(velocity / 2, 1);
            }

        }

        previousMousePos = Input.mousePosition;
    }

    /// <summary>
    /// Detects a finger tapping on any door and either opens it or indicates that it is locked if it is
    /// </summary>
    /// returns the door that was tapped if a door was detected
    public Door DetectDoorTap()
    {
        Door tappedDoor = null;
        Ray ray = new Ray();

        if (Input.touches.Length == 1)
        {
            Touch touch = Input.touches[0];

            //Detects tapping on a door to enter the selected grade
            if (touch.phase == TouchPhase.Began)
            {
                ray = Camera.main.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.CompareTag("Door"))
                    {
                        tappedDoor = hit.collider.GetComponent<Door>();
                        //tappedDoor.GetComponent<Animator>().SetTrigger("DoorOpened");
                    }
                }
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                print(hit.collider.name);

                if (hit.collider.CompareTag("Door"))
                {
                    tappedDoor = hit.collider.GetComponent<Door>();
                }
            }
        }


        return tappedDoor;
    }
}
