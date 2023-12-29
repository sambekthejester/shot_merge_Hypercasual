using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class merge : MonoBehaviour
{
    bool _allowMerge=true;
    
    public cubeController CubeController;
   

    
   

    private void Awake()
    {
        CubeController = GetComponent<cubeController>();
      
    }

    private void OnTriggerEnter(Collider collider)
    {



        if (collider.transform.tag == "gun" && collider.transform.GetChild(collider.transform.childCount - 1).childCount == 0)
        {

            Vector3 newPos = new Vector3(collider.transform.GetChild(collider.transform.childCount - 2).transform.position.x, transform.position.y,
                collider.transform.GetChild(collider.transform.childCount - 2).transform.position.z + 0.1f);
            Vector3 newPosTemp = newPos - this.transform.position;
            
            this.transform.position = newPos;

            this.transform.SetParent(collider.transform.GetChild(collider.transform.childCount - 1));
            this.GetComponent<shot>().enabled = true;
            if (this.GetComponent<cubeController>().IsSum)
            {
                GameManager.Instance.FireRateTextSum++;
                GameManager.Instance.FireRate -= 0.04f;
            }
            else
            {
                GameManager.Instance.FireRateTextMult *= 2;
                GameManager.Instance.FireRate -= 0.07f;
            }
           if (CubeController.IsUnited)
            {
                for (int i = 0; i < CubeController.United.Length; i++)
                {


                    CubeController.United[i].transform.position += newPosTemp;

                    CubeController.United[i].GetComponent<shot>().enabled = true;
                    CubeController.United[i].transform.SetParent(collider.transform.GetChild(collider.transform.childCount - 1));
                   
                    if (CubeController.United[i].GetComponent<cubeController>().IsSum)
                    {
                        GameManager.Instance.FireRateTextSum++;
                        GameManager.Instance.FireRate -= 0.04f;
                    }
                    else
                    {
                        GameManager.Instance.FireRateTextMult *= 2;
                        GameManager.Instance.FireRate -= 0.07f;
                    }
                }

            }

            


        }
        else if (collider.transform.tag == "cube" && collider.transform.parent.transform.tag == "gun" && !transform.IsChildOf(collider.transform.parent))
        {
            var collisionPoint = collider.ClosestPoint(transform.position);
            var collisionNormal = this.transform.position - collisionPoint;
            Debug.Log("collisionPoint" + collisionPoint);
            Debug.Log("collisionNormal" + collisionNormal);

            if (collisionNormal.z >= 0.05f &&  collider.gameObject.GetComponent<cubeController>().AllowFront)
            {

                Vector3 newPos = new Vector3(collider.transform.position.x, transform.position.y, transform.position.z);
                Vector3 newPosTemp = newPos - this.transform.position;
                this.transform.position = newPos;
                collider.gameObject.GetComponent<cubeController>().AllowFront = false;
                this.GetComponent<shot>().enabled = true;
                this.transform.SetParent(collider.transform.parent);

                if (this.GetComponent<cubeController>().IsSum)
                {
                    GameManager.Instance.FireRateTextSum++;
                    GameManager.Instance.FireRate -= 0.04f;
                }
                else
                {
                    GameManager.Instance.FireRateTextMult *= 2;
                    GameManager.Instance.FireRate -= 0.07f;
                }

                if (CubeController.IsUnited)
                {
                    for (int i = 0; i < CubeController.United.Length; i++)
                    {

                        CubeController.United[i].transform.position += newPosTemp;

                        CubeController.United[i].GetComponent<shot>().enabled = true;
                        CubeController.United[i].transform.SetParent(collider.transform.parent);
                       
                        if (CubeController.United[i].GetComponent<cubeController>().IsSum)
                        {
                            GameManager.Instance.FireRateTextSum++;
                            GameManager.Instance.FireRate -= 0.04f;
                        }
                        else
                        {
                            GameManager.Instance.FireRateTextMult *= 2;
                            GameManager.Instance.FireRate -= 0.07f;
                        }
                    }
                }

            }
            else if (collisionNormal.x > -0.05f && collider.gameObject.GetComponent<cubeController>().AllowRight) //right
            {

                Vector3 newPos = new Vector3(transform.position.x, transform.position.y, collider.transform.position.z);
                Vector3 newPosTemp = newPos - this.transform.position;
                this.transform.position = newPos;
                collider.gameObject.GetComponent<cubeController>().AllowRight = false;
                this.GetComponent<shot>().enabled = true;
                this.transform.SetParent(collider.transform.parent);
                CubeController.AllowLeft = false;

                if (this.GetComponent<cubeController>().IsSum)
                {
                    GameManager.Instance.FireRateTextSum++;
                    GameManager.Instance.FireRate -= 0.04f;
                }
                else
                {
                    GameManager.Instance.FireRateTextMult *= 2;
                    GameManager.Instance.FireRate -= 0.07f;
                }

                if (CubeController.IsUnited)
                {
                    for (int i = 0; i < CubeController.United.Length; i++)
                    {

                        CubeController.United[i].transform.position += newPosTemp;

                        CubeController.United[i].GetComponent<shot>().enabled = true;
                        CubeController.United[i].transform.SetParent(collider.transform.parent);

                        if (CubeController.United[i].GetComponent<cubeController>().IsSum)
                        {
                            GameManager.Instance.FireRateTextSum++;
                            GameManager.Instance.FireRate -= 0.04f;
                        }
                        else
                        {
                            GameManager.Instance.FireRateTextMult *= 2;
                            GameManager.Instance.FireRate -= 0.07f;
                        }
                    }
                }
              


            }
            else if (collisionNormal.x < 0.05f && collider.gameObject.GetComponent<cubeController>().AllowLeft) //left
            {



                Vector3 newPos = new Vector3(transform.position.x, transform.position.y, collider.transform.position.z);
                this.transform.position = newPos;
                Vector3 newPosTemp = newPos - this.transform.position;
                collider.gameObject.GetComponent<cubeController>().AllowLeft = false;
                this.GetComponent<shot>().enabled = true;
                this.transform.SetParent(collider.transform.parent);
                CubeController.AllowRight = false;

                if (this.GetComponent<cubeController>().IsSum)
                {
                    GameManager.Instance.FireRateTextSum++;
                    GameManager.Instance.FireRate -= 0.04f;
                }
                else
                {
                    GameManager.Instance.FireRateTextMult *= 2;
                    GameManager.Instance.FireRate -= 0.07f;
                }

                if (CubeController.IsUnited)
                {
                    for (int i = 0; i < CubeController.United.Length; i++)
                    {

                        CubeController.United[i].transform.position += newPosTemp;

                        CubeController.United[i].GetComponent<shot>().enabled = true;
                        CubeController.United[i].transform.SetParent(collider.transform.parent);
                       
                        if (CubeController.United[i].GetComponent<cubeController>().IsSum)
                        {
                            GameManager.Instance.FireRateTextSum++;
                            GameManager.Instance.FireRate -= 0.04f;
                        }
                        else
                        {
                            GameManager.Instance.FireRateTextMult *= 2;
                            GameManager.Instance.FireRate -= 0.07f;
                        }
                    }
                }

            }



        }


    }

   
}
