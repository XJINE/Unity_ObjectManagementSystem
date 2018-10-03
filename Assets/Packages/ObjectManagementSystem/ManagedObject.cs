using UnityEngine;

namespace ObjectManagementSystem
{
    public class ManagedObject<T> : MonoBehaviour
    {
        #region Property

        public ObjectManager<T> ObjectManager
        {
            get;
            protected set;
        }

        public bool IsManaged
        {
            get { return this.ObjectManager != null; }
        }

        public T Data
        {
            get;
            protected set;
        }

        #endregion Property

        #region Method

        protected virtual void OnDestroy()
        {
            if (this.IsManaged)
            {
                this.ObjectManager.ReleaseManagedObject(this, true);
            }
        }

        public virtual bool Initialize(ObjectManager<T> objectManager, T data)
        {
            // NOTE:
            // Called once from ObjectManager<T>.

            if (this.ObjectManager == null && this.Data == null)
            {
                this.ObjectManager = objectManager;
                this.Data = data;
                return true;
            }

            return false;
        }

        public virtual void ReleaseFromManager()
        {
            GameObject.Destroy(this);
        }

        #endregion Method
    }
}