using UnityEngine;

namespace ObjectManagementSystem
{
    public class SampleObjectPainter : MonoBehaviour
    {
        #region Field

        public SampleObjectManager sampleObjectManager;

        public Color[] colors = new Color[] { Color.red, Color.blue, Color.green };

        protected int colorsIndex = 0;

        #endregion Field

        #region Method

        void Update()
        {
            if (Time.frameCount % 180 == 0)
            {
                foreach (SampleManagedObject managedObject in this.sampleObjectManager.ManagedObjects)
                {
                    managedObject.Data.SetColor(this.colors[Random.Range(0, this.colors.Length)]);
                }
            }
        }

        #endregion Method
    }
}