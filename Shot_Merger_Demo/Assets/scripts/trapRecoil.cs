using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapRecoil : MonoBehaviour
{
    [SerializeField] float recoil;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "gun")
        {
            int i = 0;
            other.transform.GetComponent<Rigidbody>().AddForce(new Vector3(Random.RandomRange(-1f, 1f) * 50, 0,-recoil), ForceMode.Force);
            while (other.transform.GetChild(other.transform.childCount - 1).childCount>0)
            {
                other.transform.GetChild(other.transform.childCount - 1).GetChild(i).GetComponent<cubeController>().DestroyCube();
                i++;
            }
            
        }
        else if (other.transform.tag == "cube")
        {
            other.transform.GetComponent<cubeController>().DestroyCube();
        }
    }
}
