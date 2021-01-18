using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InexperiencedDeveloper.Core
{
public class Helper
{

    public static void TurnOnCursor(bool trueOrFalse)
    {
        if (!trueOrFalse)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;
    }

    public static GameObject ShootRay(float range, Camera camera)
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, range))
            return hitInfo.collider.gameObject;
        else
            return null;
    }

    public static void DrawRay(float range, Color color, Camera camera)
    {
        Debug.DrawRay(camera.transform.position, Camera.main.transform.forward * range, color);
    }


} //Helper
}// namespace
