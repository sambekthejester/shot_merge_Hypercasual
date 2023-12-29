using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cubeController : MonoBehaviour
{
    public bool IsSum;

    public bool AllowRight = true;
    public bool AllowLeft = true;
    public bool AllowFront = true;

    public bool IsUnited;
 
    public GameObject[] United;
    public TextMeshProUGUI text;

    public GameObject DestroyedCube;


    private void Update()
    {
        MoveUi();
    }
    public void MoveUi()
    {
        text.transform.position = new Vector3(transform.position.x, text.transform.position.y, transform.position.z);
    }

    public void DestroyCube()
    {
        


        if (IsSum)
        {
            GameManager.Instance.FireRateTextSum--;
            GameManager.Instance.FireRate += 0.04f;
        }
        else
        {
            GameManager.Instance.FireRateTextMult *= 0.5f;
            GameManager.Instance.FireRate += 0.07f;
        }

        RaycastHit hit;
       
        if (Physics.Raycast(transform.position, Vector3.right, out hit, 0.6f))
        {
            if (hit.transform.TryGetComponent<cubeController>(out cubeController cubeController))
            {
                cubeController.AllowLeft = true;
            }
                        
        }
        if (Physics.Raycast(transform.position, Vector3.left, out hit, 0.6f))
        {
            if (hit.transform.TryGetComponent<cubeController>(out cubeController cubeController))
            {
                cubeController.AllowRight = true;
            }

        }
        if (Physics.Raycast(transform.position, Vector3.back, out hit, 0.6f))
        {
            if (hit.transform.TryGetComponent<cubeController>(out cubeController cubeController))
            {
                cubeController.AllowFront = true;
            }

        }



        GameObject tempCube=Instantiate(DestroyedCube, transform.position, Quaternion.identity);
        tempCube.transform.GetChild(0).transform.GetComponent<Rigidbody>().AddForce(new Vector3( 10f,10f,10f) * Random.RandomRange(-1f, 0f), ForceMode.Force);
        tempCube.transform.GetChild(1).transform.GetComponent<Rigidbody>().AddForce(new Vector3(10f, 10f, 10f) * Random.RandomRange(0f, 1f), ForceMode.Force);
        Destroy(text);
        Destroy(this.gameObject);
        Destroy(tempCube.transform.GetChild(0).gameObject, 1.75f);
        Destroy(tempCube.transform.GetChild(1).gameObject, 1.75f);
        Destroy(tempCube, 2f);
    }
}
