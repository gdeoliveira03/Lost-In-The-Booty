using UnityEngine;

namespace Assets.Scripts.Utils
{
    public class Billboard : MonoBehaviour
    {
        [SerializeField]
        private Camera camToLookAt;

        private void Update()
        {
            if (camToLookAt == null)
            {
                camToLookAt = GameObject.Find("scruffyMain")?.GetComponentInChildren<Camera>();
            }

            if (camToLookAt == null)
                return;

            transform.LookAt(camToLookAt.transform);
            transform.Rotate(Vector3.up * 180);
        }
    }
}
