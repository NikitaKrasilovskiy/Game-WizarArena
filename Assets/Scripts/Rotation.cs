using UnityEngine;
public class Rotation : MonoBehaviour
{
    [SerializeField] private Transform Point;
    void Update()
    { transform.Rotate(new Vector3(0, 0, 20) * Time.deltaTime); }
}