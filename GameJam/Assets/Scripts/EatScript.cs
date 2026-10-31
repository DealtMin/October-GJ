using UnityEngine;

public class EatScript : MonoBehaviour, IEdible
{
    public void Eat()
    {
        Debug.Log(gameObject.name + " съеден");
        Destroy(gameObject);
    }
}
