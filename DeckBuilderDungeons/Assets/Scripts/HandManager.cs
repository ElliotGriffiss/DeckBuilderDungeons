using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    [SerializeField] private BezierCurve Curve;

    [SerializeField] private List<Transform> Cards;

    public void OnEnable()
    {
        //float screenAspect = (float)Screen.width / (float)Screen.height;
        //float camHalfHeight = Camera.main.orthographicSize;
        //float camHalfWidth = screenAspect * camHalfHeight;
        //float camWidth = 2.0f * camHalfWidth;

        float CardWidth = 1.95f;

        //float widthPerCard = camWidth / Cards.Count;

        Debug.Log(Cards.Count);


        for (int i = 0; i < Cards.Count; i++)
        {
            Vector3 newPosition = Curve.GetPoint(i / Cards.Count+1);

            Debug.Log(i);

            Debug.Log(i / Cards.Count);

            Cards[i].position = newPosition;
        }

    }
}
