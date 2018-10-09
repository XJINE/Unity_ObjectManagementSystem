using UnityEngine;

namespace ObjectManagementSystem
{
    public class SampleObjectManager : ObjectManager<SampleObjectBehaviour>
    {
        protected override SampleObjectBehaviour InitializeManagedObjectData(GameObject managedGameObject)
        {
            return managedGameObject.GetComponent<SampleObjectBehaviour>();
        }
    }
}