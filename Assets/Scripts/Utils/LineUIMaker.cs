using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
    public class LineUIMaker : MonoBehaviour
    {
        [SerializeField] private float _lineWidth = 3f;

        public float LineWidth
        {
            get{ return _lineWidth; }
            set{ _lineWidth = value; 
                SetLineWidth(); }
        }

        [SerializeField] private Sprite _lineImage;
        [SerializeField] private int _maxLines = 6;
        [SerializeField] private Color _color;
        [SerializeField] private Vector2 _graphScale = new(1, 1);
        [SerializeField] private Transform _lineContainer;
        private List<(Vector2, Vector2)> _pointsTuples = new();
        private List<RectTransform> _linesRectList = new();

        public void ClearLinesAndPoints()
        {
            _pointsTuples.Clear();
            foreach (var line in _linesRectList)
                DestroyImmediate(line.gameObject);
            _linesRectList.Clear();
            // Destroy all children of the line container
            foreach (Transform child in _lineContainer)
                DestroyImmediate(child.gameObject);
        } 

        public void AddPoints(Vector2 a, Vector2 b)
        {
            _pointsTuples.Add((a, b));
            if (_linesRectList.Count < _pointsTuples.Count && _linesRectList.Count < _maxLines)
                MakeLineObj();
        }

        public void ShapeAndShowLines()
        {
            ShapeLine();
            ShowLines();
        }

        public void HideLines() => StartCoroutine(ToggleLinesVisibility(false));

        private void ShapeLine()
        {
            for (int i = 0; i < _pointsTuples.Count; i++)
            {
                var pointsTuple = _pointsTuples[i];
                Vector3 a = new Vector3(pointsTuple.Item1.x * _graphScale.x, pointsTuple.Item1.y * _graphScale.y, 0);
                Vector3 b = new Vector3(pointsTuple.Item2.x * _graphScale.x, pointsTuple.Item2.y * _graphScale.y, 0);

                var rect = _linesRectList[i];
                rect.localPosition = (a + b) / 2;
                Vector3 dif = a - b;
                rect.sizeDelta = new Vector2(dif.magnitude, _lineWidth);
                rect.rotation = Quaternion.Euler(new Vector3(0, 0, 180 * Mathf.Atan(dif.y / dif.x) / Mathf.PI));
            }
        }
        
        private void SetLineWidth()
        {
            foreach (var line in _linesRectList)
            {
                line.sizeDelta = new Vector2(line.sizeDelta.x, _lineWidth);
            }
        }
        private void ShowLines() => StartCoroutine(ToggleLinesVisibility(true));

        private void MakeLineObj()
        {
            var newObj = new GameObject
            {
                name = "lineObj"
            };

            var newImage = newObj.AddComponent<Image>();
            newImage.sprite = _lineImage;
            newImage.color = _color;
            RectTransform rect = newObj.GetComponent<RectTransform>();

            rect.SetParent(_lineContainer);
            rect.localScale = Vector3.one;

            _linesRectList.Add(rect);
        }

        private IEnumerator ToggleLinesVisibility(bool isActive)
        {
            yield return new WaitForEndOfFrame();
            foreach (var rectTransform in _linesRectList)
            {
                rectTransform.gameObject.SetActive(isActive);
            }
        }
    }
}