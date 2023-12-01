using UnityEngine;

public class RotateGameObjects : MonoBehaviour
{

    void Start()
    {
        RotateObjects();
    }

    void RotateObjects()
    {
        GameObject[] objectsToRotate = GameObject.FindGameObjectsWithTag("rotate"); // Replace "YourTag" with the actual tag of your game objects

        foreach (GameObject obj in objectsToRotate)
        {
            RotateObject(obj);
        }
    }

    void RotateObject(GameObject obj)
    {
        Vector3 currentRotation = obj.transform.rotation.eulerAngles;
        obj.transform.rotation = Quaternion.Euler(new Vector3(currentRotation.x, currentRotation.y - 1.901f, currentRotation.z));
    }
}
