using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    float angle = 0f;

    public Transform cameraMain;




    // Update is called once per frame
    void Update()
    {
        MoveObject();

        RotateObject();
    }

    void MoveObject()
    {



        // Move the object RIGHT
     //   if (Input.GetAxis("Horizontal") > 0)
      //  {

      //      transform.position = transform.position + new Vector3(0.1f, 0f, 0f);
     //       Debug.Log(transform.position);
     //   }

        // Move the object LEFT
    //    else if (Input.GetAxis("Horizontal") < 0)
     //   {

     //       transform.position = transform.position + new Vector3(-0.1f, 0f, 0f);
    //    }

        // Move the object FORWARD
        if (Input.GetAxisRaw("Vertical") > 0)
        {

            transform.position = transform.position + 0.02f*transform.forward;

        }

        // Move the object BACKWARD
        else if (Input.GetAxisRaw("Vertical") < 0)
        {

            transform.position = transform.position - 0.02f*transform.forward;

        }

    }

    public void RotateObject()
    {


        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            angle += 0.25f;
           

        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            angle -= 0.25f;
          
        }

        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }

  } // FINISH
