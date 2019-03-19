using UnityEngine;

namespace ObjectManagementSystem
{
    public class ManagedObject<T> : MonoBehaviour, IInitializable
    {
        #region Property

        protected ObjectManager<T> objectManager;

        public ObjectManager<T> ObjectManager
        {
            get { return this.objectManager; }
            set { if (!this.IsInitialized) { this.objectManager = value; } }
        }

        public T Data
        {
            get;
            protected set;
        }

        public bool IsInitialized
        {
            get; protected set;
        }

        #endregion Property

        #region Method

        protected virtual void OnDestroy()
        {
            // CAUTION:
            // ManagedObject might be removed from the outside of the ObjectManager.

            if (this.objectManager != null)
            {
                this.objectManager.ReleaseManagedObject(this);
            }
        }

        public virtual bool Initialize()
        {
            if (this.IsInitialized)
            {
                return false;
            }

            this.IsInitialized = true;

            this.Data = base.GetComponent<T>();

            return true;
        }

        #endregion Method
    }
}