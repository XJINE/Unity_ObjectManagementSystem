using UnityEngine;

public class Sample : MonoBehaviour
{
    #region Field

    public SampleObjectGenerator objectGenerator;

    public Color[] paintColors = new Color[] { Color.red, Color.blue, Color.green };

    public KeyCode generateKey = KeyCode.Return;
    public KeyCode removeKey   = KeyCode.Delete;
    public KeyCode paintKey    = KeyCode.P;

    #endregion Field

    void Update()
    {
        if (Input.GetKeyDown(this.generateKey))
        {
            var managedObject = this.objectGenerator.Generate<SampleManagedObject>
                                (Random.Range(0, this.objectGenerator.objects.Length));
        }

        if (Input.GetKeyDown(this.removeKey))
        {
            this.objectGenerator.ObjectManager.RemoveAllManagedObjects();
        }

        if (Input.GetKeyDown(this.paintKey))
        {
            foreach (var managedObject in this.objectGenerator.ObjectManager.ManagedObjects)
            {
                managedObject.Data.SetColor(this.paintColors[Random.Range(0, this.paintColors.Length)]);
            }
        }
    }

    void OnGUI()
    {
        GUILayout.Label("Press " + this.generateKey + " to Add New Object.");
        GUILayout.Label("Press " + this.removeKey   + " to Remove All of the Object.");
        GUILayout.Label("Press " + this.paintKey    + " to Paint All of the Object.");

        GUILayout.Label("Object Count : " + this.objectGenerator.ObjectManager.ManagedObjects.Count
                                  + " / " + this.objectGenerator.ObjectManager.MaxCount);
    }
}