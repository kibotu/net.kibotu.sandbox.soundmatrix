using UnityEngine;

namespace Assets.Source
{
    public class RotateTowardsMouse : MonoBehaviour
    {
        void Update()
        {
            var mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            transform.LookAt(mouseWorldPosition);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
        }
    }
}