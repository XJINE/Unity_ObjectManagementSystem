using UnityEngine;

namespace ObjectManagementSystem
{
    public class SampleObjectGenerator : ObjectGenerator<SampleObjectBehaviour>
    {
        public override GameObject Generate<Sample>(int objectIndex, Vector3 position, Vector3? rotation = null, Vector3? scale = null)
        {
            return base.Generate<Sample>(objectIndex, position, rotation, scale);
        }
    }
}