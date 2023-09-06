using Assets.Scripts.Core.Providers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core.Components
{
    public class NoGoWallComponent : MonoBehaviour
    {
        Material _material;

        System.Random _random;

        public bool dontUpdate;
        public float alpha;
        public Vector3 pos;

        private int i = 0;

        private void Start()
        {
            _material = _material ?? GetComponent<Renderer>().material;
            //material.shader = Shader.Find("Specular");
            _random = new System.Random();
        }

        private void Update()
        {
            if (dontUpdate) return;

            i++;
            if (i % 10 == 0)
            {
                i = 1;

                float shininess = Mathf.PingPong(Time.time, 1.0f);
                float toAdd = ((float)_random.Next(0, 100) / 100f);
                alpha = shininess + toAdd;
                //_material.SetFloat("_Alpha", alpha);

                pos = ActiveUnitProvider.Instance.WorldPosition();
                _material.SetVector("_ActivePlayerPos", pos);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("Collision"); //Collision is true
            StartCoroutine(FadeAlphaToZero(GetComponent<SpriteRenderer>(), 2f));
        }

        IEnumerator FadeAlphaToZero(SpriteRenderer renderer, float duration)
        {
            Color startColor = renderer.color;
            Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0);
            float time = 0;
            while (time < duration)
            {
                time += Time.deltaTime;
                renderer.color = Color.Lerp(startColor, endColor, time / duration);
                yield return null;
            }
        }

    }
}
