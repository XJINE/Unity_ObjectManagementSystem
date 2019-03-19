using UnityEngine;

namespace ObjectManagementSystem
{
    // NOTE:
    // This is one of a sample.
    // ObjectManager<> is able to use without ObjectGenerator<>.

    [RequireComponent(typeof(ObjectManager<>))]
    public class ObjectGenerator<T> : MonoBehaviour
    {
        #region Field

        public Transform objectParent;

        public GameObject[] objects;

        #endregion Field

        #region Property

        public ObjectManager<T> ObjectManager 
        {
            get;
            protected set;
        }

        #endregion Property

        #region Method

        public virtual void Awake()
        {
            this.ObjectManager = base.GetComponent<ObjectManager<T>>();
        }

        public virtual GameObject Generate<U>(int      index,
                                              Vector3  position,
                                              Vector3? rotation = null,
                                              Vector3? scale    = null) where U : ManagedObject<T>
        {
            if (this.ObjectManager.IsFilled)
            {
                return null;
            }

            GameObject generatedObject = GameObject.Instantiate(this.objects[index]);

            Transform transform  = generatedObject.transform;
            transform.position   = position;
            transform.rotation   = rotation == null ? transform.rotation   : Quaternion.Euler((Vector3)rotation);
            transform.localScale = scale    == null ? transform.localScale : (Vector3)scale;
            transform.parent     = this.objectParent;

            this.ObjectManager.AddManagedObject<U>(generatedObject);

            return generatedObject;
        }

        #endregion Method
    }
}