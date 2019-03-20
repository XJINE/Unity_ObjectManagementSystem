using UnityEngine;

namespace ObjectManagementSystem
{
    public class ManagedObject<T> : MonoBehaviour where T : ManagedObject<T>
    {
        #region Property

        public ObjectManager<T> ObjectManager { get; protected set; }

        #endregion Property

        #region Method

        protected virtual void OnDestroy()
        {
            // CAUTION:
            // ManagedObject might be removed from the outside of the ObjectManager.

            if (this.ObjectManager != null)
            {
                this.ObjectManager.ReleaseManagedObject((T)this);
            }
        }

        public bool Register(ObjectManager<T> objectManager)
        {
            if (this.ObjectManager != null)
            {
                return false;
            }

            this.ObjectManager = objectManager;

            return true;
        }

        #endregion Method
    }
}