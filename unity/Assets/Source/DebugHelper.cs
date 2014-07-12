using UnityEngine;

namespace Assets.Source
{
    public class DebugHelper : MonoBehaviour
    {
        public bool Enabled;

        public void Update () {
            if(Enabled) Debug.Log("Materials: " + Resources.FindObjectsOfTypeAll<Material>().Length);
        }
    }
}
