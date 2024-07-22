using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TestPR.UI
{
    public class SpawnedUIObjectBehaviour : MonoBehaviour
    {
        public void UpdateUIPositionWorld(RectTransform objectRectTransform,Transform positionTarget )
        {
            RectTransform rectTransform;

            rectTransform = objectRectTransform.GetComponent<RectTransform>();

            Vector3 screenPosition = Camera.main.WorldToScreenPoint(positionTarget.position);

            rectTransform.position = screenPosition;
        }
    }
}
