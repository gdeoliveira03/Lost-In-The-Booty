using UnityEngine;

namespace Assets.Scripts.Utils
{
    public class Billboard : MonoBehaviour
    {
        Camera cam;
        private void Update()
        {
            if (cam == null)
            {
                cam = GameObject.Find("scruffyMain").GetComponentInChildren<Camera>();
            }

            if (cam == null) return;

            transform.LookAt(cam.transform);
            transform.Rotate(Vector3.up * 180);
        }
    }
}
