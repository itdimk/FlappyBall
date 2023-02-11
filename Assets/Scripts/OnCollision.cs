using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class OnCollision : MonoBehaviour
{
    public UnityEvent Collided;
    public string[] targetTags = { "Player" };

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (targetTags.Contains(col.gameObject.tag))
        {
            Collided.Invoke();
            col.gameObject.SetActive(false);
        }
    }
}