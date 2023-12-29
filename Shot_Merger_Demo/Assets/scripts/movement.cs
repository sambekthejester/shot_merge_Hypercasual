using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class movement : MonoBehaviour
{
    
    [SerializeField] float _horizontal;
    [SerializeField] float _horizontalSpeed;
    [SerializeField] float _verticalSpeed;
    [SerializeField] TextMeshProUGUI text;
    private float _newPos;
    

    private void Update()
    {
        GetHoriztonalInput();
       

    }
    private void FixedUpdate()
    {

        moveForward();
        moveHorizontal();
        Debug.Log(transform.GetChild(transform.childCount - 1).name);
        if (GameManager.Instance.BoolGameOver)
        {
            DestroyPistol();
        }

    }
    private void moveForward()
    {
        transform.Translate(Vector3.forward * _verticalSpeed * Time.fixedDeltaTime);
        text.transform.position = transform.position - new Vector3(-0.1f, 0f, 0.5f); 
      
    }

    private void moveHorizontal()
    {
        _newPos = transform.position.x + _horizontal * Time.fixedDeltaTime * _horizontalSpeed;
        text.transform.position = transform.position - new Vector3(-0.1f, 0f, 0.5f);
        
        if (_newPos < 1.6 && _newPos > -1.1)
        {
            transform.position = new Vector3(_newPos, transform.position.y, transform.position.z);
            text.transform.position = transform.position - new Vector3(-0.1f, 0f, 0.5f);
        }

       

    }
    private void GetHoriztonalInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved && Mathf.Abs(touch.deltaPosition.x) < 80)
            {

                _horizontal = touch.deltaPosition.x;
            }
            else
            {
                _horizontal = 0;

            }

        }

    }

    void DestroyPistol()
    {
        this.GetComponentInChildren<shot>().GetComponent<shot>().enabled = false;
        for (int i = 0; i < 2; i++)
        {
            transform.GetChild(i).gameObject.AddComponent<Rigidbody>();
            transform.GetChild(i).GetComponent<Rigidbody>().useGravity = true;
            transform.GetChild(i).GetComponent<Collider>().enabled = true;
            transform.GetChild(i).tag = "gun";
            transform.GetChild(i).gameObject.layer = 6;
            transform.GetChild(i).parent = null;
        }
        
        Destroy(this);
        
    }
}