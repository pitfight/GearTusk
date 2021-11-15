using UnityEngine;
using System.Collections;

public class LevelArmControll : MonoBehaviour
{
    private GameObject target;
    private Vector2 startPos;
    private Vector2 endPos;

    [HideInInspector]public Vector2 Direction;
    public float RotationSpeed = 3f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hitInfo;
            target = GetClickedObject(out hitInfo);
            if (target != null)
            {
                startPos = Input.mousePosition;
            }
        }
        if (Input.GetMouseButton(0))
        {
            endPos = Input.mousePosition;
            Direction = endPos - startPos;
            Direction.y = 0;
            Direction.x = Mathf.Clamp(Direction.x, 0.2f, -0.2f);
            Quaternion rotation = Quaternion.LookRotation(target.transform.position, Direction);
            rotation.z = 0;
            rotation.y = 0;
            rotation.w = Mathf.Clamp(rotation.x, 0.4f, 0.9f);
            target.transform.rotation = Quaternion.Lerp(target.transform.rotation, rotation, RotationSpeed * Time.deltaTime);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Direction.x = 0;
        }

    }

    GameObject GetClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }

        return target;
    }
}