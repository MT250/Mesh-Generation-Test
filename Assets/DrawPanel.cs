using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPanel : MonoBehaviour
{
    [SerializeField] private LineRenderer panelLine;
    [SerializeField] private LineRenderer worldSpaceLine;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            DrawLine();
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            DestroyUILine();
        }
    }

    private void DestroyUILine()
    {
        StopCoroutine("CreatingLine");
        CreateWorldSpaceObject();

        panelLine.positionCount = 0;
        panelLine.gameObject.SetActive(false);
    }

    private void CreateWorldSpaceObject()
    {
        ResetWorldObject();

        for (int i = 0; i < panelLine.positionCount; i++)
        {
            worldSpaceLine.positionCount++;
            Vector3 lineVertPos = panelLine.GetPosition(i);
            worldSpaceLine.SetPosition(i, lineVertPos);
        }

        var edgeCollider = worldSpaceLine.GetComponent<EdgeCollider2D>();
        List<Vector2> points = new List<Vector2>();

        for (int i = 0; i < worldSpaceLine.positionCount; i++)
        {
            points.Add(worldSpaceLine.GetPosition(i));
        }

        edgeCollider.SetPoints(points);
    }

    private void ResetWorldObject()
    {
        worldSpaceLine.positionCount = 0;
    }

    private void DrawLine()
    {
        panelLine.gameObject.SetActive(true);
        StartCoroutine("CreatingLine");
    }

    private IEnumerator CreatingLine()
    {
        while(true)                                         //TODO: Limit the amount of points (Hold time or points limit); 
        {
            var v3 = Input.mousePosition;
            v3 = Camera.main.ScreenToWorldPoint(v3);
            v3.z = 0f;

            panelLine.SetPosition(panelLine.positionCount++, v3);
            yield return new WaitForSeconds(.05f);
        }
    }
}
