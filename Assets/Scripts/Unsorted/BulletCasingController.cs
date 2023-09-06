using Codice.Client.BaseCommands;
using System;
using UnityEngine;

namespace Assets.Scripts.Unsorted
{
    public class BulletCasingController : MonoBehaviour
    {
        [SerializeField]
        private float _movementSpeed = 25f;

        [SerializeField]
        private float _angle = -90f;

        [SerializeField]
        private float _gravity = -9.81f;

        [SerializeField]
        [Range(0, 1)]
        private float _jitter = 0.5f;

        private float _lifeTime = 0f;

        private float AngleJitter => _angle > 0.0f ? _angle * _jitter : _angle;

        public static float Wave(float x, float t)
        {
            return Mathf.Sin(Mathf.PI * (t));
        }

        private void Start()
        {

        }

        private void OnEnable()
        {
            _lifeTime = 0;
        }

        private void Update()
        {
            if (_lifeTime == float.MaxValue)
            {
                throw new ApplicationException(nameof(_lifeTime));
            }
            _lifeTime = _lifeTime + Time.deltaTime;

            var originalPosition = transform.position;
            //transform.position += Vector3.up * Time.deltaTime * _movementSpeed;
            //var newPosition = transform.position - transform.forward;


            //transform.Translate(Vector3.left * Time.deltaTime * _movementSpeed);
            //newPosition.y = newPosition.y - 0.1f;
            //newPosition.y = Wave(newPosition.y - 0.1f, _lifeTime);

            //transform.position = Vector3.Lerp(originalPosition, newPosition, Time.deltaTime * _movementSpeed);

            var x = _movementSpeed * _lifeTime * Mathf.Rad2Deg * Mathf.Cos(Mathf.Deg2Rad * _angle);
            var newPosition = transform.position + (x * transform.forward);

            var y = (_movementSpeed * _lifeTime * Mathf.Rad2Deg * Mathf.Sin(Mathf.Deg2Rad * _angle)) - (0.5f * _gravity * _lifeTime * _lifeTime);
            newPosition = newPosition + (y * transform.right);

            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime);
        }

    }
}
