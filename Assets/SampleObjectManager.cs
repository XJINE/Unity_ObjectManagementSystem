using UnityEngine;

namespace ObjectManagementSystem
{
    public class SampleObjectManager : ObjectManager<SampleObjectBehaviour>
    {
        protected override SampleObjectBehaviour ReturnManagedObjectData(GameObject managedGameObject)
        {
            return managedGameObject.GetComponent<SampleObjectBehaviour>();
        }
    }
}