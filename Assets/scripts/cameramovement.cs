using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class cameramovement : MonoBehaviour
{
    [SerializeField] GameObject target;
    public Vector3 offset;
    public Vector3 previousposition;
    public Vector3 threshold;
    public float thresholdy;
    public float yrotationvalue;
    public float xrotationvalue;
    public Joystick myjoystick;
    public float mouseymin;
    public float mouseymax;
    public float clampedxangle;
    public float xrotate;
    public float yrotate;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("the angles " + Quaternion.Euler(new Vector3(0f,30f,0f)));
        Debug.Log("the angles " + transform.eulerAngles);
    }

    // Update is called once per frame
    void Update()
    {

        if (!EventSystem.current.IsPointerOverGameObject())
        {
           
            if (Input.GetMouseButtonDown(1))
            {

                previousposition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            }
            if (Input.GetMouseButton(1))
            {
                threshold = previousposition - Camera.main.ScreenToViewportPoint(Input.mousePosition);


            }
            else
            {
                previousposition = Vector3.zero;
                threshold = Vector3.zero;
            }
            //float xrot = threshold.y * 2f;
            //float yrot = threshold.x * 2f;
            //clampedxangle = Mathf.Clamp(xrot,-20f , 25f);

            //x me y aur y me x
            xrotate = threshold.y * 2f;
            yrotate = threshold.x * 2f;
            transform.Rotate(xrotate, yrotate, 0f);

            
            //clampedxangle = Mathf.Clamp(transform.eulerAngles.x, 335f, 30f);
          
            //transform.rotation = Quaternion.Euler(clampedxangle, transform.eulerAngles.y, 0f); //new Vector3(clampedxangle, transform.eulerAngles.y, 0f);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);

        }

    }
    private void LateUpdate()
    {
        transform.position = target.transform.position;
    }
}
