using Assets.Scripts.Core.StateMachines.Inputs;
using Codice.CM.Client.Differences.Graphic;
using Demo.Data;
using Mono.Cecil;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core.AimArc
{
    public class AimArc
    {
        private const int RESOURCE_ARC = 5;
        private const int RESOURCE_POINT = 6;

        private const int LINE_RANGE = 100;

        private Transform _source;

        private GameObject[] _points;
        private const int POINTS_AMOUNT = 5;

        private GameObject _line;

        private bool IsVisible;

        public AimArc(Transform source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            _source = source;

            _line = GameObject.Instantiate(ResourceLoader.LoadPrefab(RESOURCE_ARC), _source.position, Quaternion.identity);

            _points = new GameObject[POINTS_AMOUNT];

            HideLine();

            for (int i = 0; i < POINTS_AMOUNT; i++)
            {
                float up = i * (LINE_RANGE / POINTS_AMOUNT);
                Vector3 pointsNextPosition = _source.position + (_source.transform.up * up);
                GameObject point = GameObject.Instantiate(ResourceLoader.LoadPrefab(RESOURCE_POINT), pointsNextPosition, Quaternion.identity);
                point.transform.parent = _line.transform;
                _points[i] = point;
            }

            //Vector3 endPosition = _source.position + (_source.transform.up * LINE_RANGE);
            //GameObject endPoint = GameObject.Instantiate(_pointPrefab, endPosition, Quaternion.identity);
            //endPoint.transform.parent = _line.transform;
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        public void Update()
        {
            if (_line == null || !IsVisible)
            {
                return;
            }

            float dTime = Time.deltaTime;
            float maxSpeed = 50f;
            float speedLossPercent = 50f;

            for (int i = 0; i < POINTS_AMOUNT; i++)
            {
                float up = i * (LINE_RANGE / POINTS_AMOUNT);
                Vector3 pointsNextPosition = _source.position + (_source.transform.up * up);
                float loss = (speedLossPercent / POINTS_AMOUNT) * i;
                float speed = (maxSpeed / 100) * (100 - loss);
                _points[i].transform.position = Vector3.Lerp(_points[i].transform.position, pointsNextPosition, dTime * speed);
            }
        }

        /// <summary>
        /// Shows the line.
        /// </summary>
        public void ShowLine()
        {
            IsVisible = true;
            if (_line != null)
            {
                _line.SetActive(true);
                Update();
            }
        }

        /// <summary>
        /// Hides the line.
        /// </summary>
        public void HideLine()
        {
            IsVisible = false;
            _line?.SetActive(false);
        }
    }
}
