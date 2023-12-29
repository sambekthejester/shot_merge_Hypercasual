using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class barrelController : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI text;
    int HpBarrel;

    private void Awake()
    {
        HpBarrel = Random.Range(10, 41);
        text.text = HpBarrel.ToString();
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "bullet")
        {
            if (HpBarrel > 0)
            {
                HpBarrel--;
                text.text = HpBarrel.ToString();
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(text);
                Destroy(this.gameObject);
            }

        }
        else if (other.transform.tag == "gun")
        {
                    
            int i = 0;
            while (other.transform.GetChild(other.transform.childCount-1).childCount >= 1)
            {
                other.transform.GetChild(other.transform.childCount - 1).GetChild(i).GetComponent<cubeController>().DestroyCube();
                i++;
            }

            GameManager.Instance.BoolGameOver = true;
            GameManager.Instance.GameOver();

        }
        else if (other.transform.tag == "cube")
        {
            other.transform.GetComponent<cubeController>().DestroyCube();
        }
    }
}
