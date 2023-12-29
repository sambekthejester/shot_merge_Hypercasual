using UnityEngine;

public class Ending : MonoBehaviour
{
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Finish")
        {
            GameManager.Instance.Bonus++;
        }
    }
}
