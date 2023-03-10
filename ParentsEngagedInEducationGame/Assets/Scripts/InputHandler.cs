using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] CameraMovement mainCam;


    public static InputHandler Instance { get; private set; }


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

    public Door DetectDoorTap()
    {
        Door tappedDoor = null;

        if (Input.touches.Length == 1)
        {
            Touch touch = Input.touches[0];

            //Detects tapping on a door to enter the selected grade
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.CompareTag("Door"))
                    {
                        tappedDoor = hit.collider.GetComponent<Door>();
                        //hit.collider.GetComponent<Door>().EnterGrade();
                    }
                }
            }
        }

        return tappedDoor;
    }
}
