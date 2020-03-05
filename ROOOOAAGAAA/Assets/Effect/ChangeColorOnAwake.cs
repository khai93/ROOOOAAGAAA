using UnityEngine;

namespace ROOOOAAGAAA.Effect
{
    [RequireComponent(typeof(Renderer))]
    public class ChangeColorOnAwake : MonoBehaviour
    {
        [SerializeField]
        private Color color;

        private void Awake()
        {
            GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b);
        }
    }
}
