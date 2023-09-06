using UnityEngine;

namespace Assets.Scripts.Core.Components
{
    public class DayNightCycleComponent : MonoBehaviour
    {
        public float Speed = 0.1f;

        void Update()
        {
            //transform.eulerAngles = new Vector3(transform.eulerAngles.x + (Time.deltaTime * Speed), transform.eulerAngles.y, transform.eulerAngles.z);

            //Vector3 eulers = this.transform.rotation.eulerAngles;
            //this.transform.rotation = Quaternion.Euler(new Vector3(eulers.x + (Time.deltaTime * Speed), eulers.y, eulers.z));

            //transform.rotation = Quaternion.AngleAxis(Speed * Time.deltaTime, transform.right);

            transform.Rotate(Speed * Time.deltaTime, 0,  0, Space.Self);
        }
    }
}
