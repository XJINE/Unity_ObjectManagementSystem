using UnityEngine;

public class Sample : MonoBehaviour
{
    #region Field

    public SampleObjectGenerator generator;

    public Color[] paintColors = new Color[] { Color.red, Color.blue, Color.green };

    public KeyCode generateKey = KeyCode.Return;
    public KeyCode removeKey   = KeyCode.Delete;
    public KeyCode paintKey    = KeyCode.P;

    #endregion Field

    #region Method

    void Update()
    {
        if (Input.GetKeyDown(this.generateKey))
        {
            var managedObject = this.generator.Generate<SampleManagedObject>
                                (Random.Range(0, this.generator.objects.Length));
        }

        if (Input.GetKeyDown(this.removeKey))
        {
            foreach (var managedObject in this.generator.Manager.ManagedObjects)
            {
                GameObject.Destroy(managedObject.gameObject);
            }
        }

        if (Input.GetKeyDown(this.paintKey))
        {
            foreach (var managedObject in this.generator.Manager.ManagedObjects)
            {
                managedObject.Data.SetColor(this.paintColors[Random.Range(0, this.paintColors.Length)]);
            }
        }
    }

    void OnGUI()
    {
        GUILayout.Label("Press " + this.generateKey + " to Add a New Object.");
        GUILayout.Label("Press " + this.removeKey   + " to Remove All Objects.");
        GUILayout.Label("Press " + this.paintKey    + " to Paint All Objects.");

        GUILayout.Label("Object Count : " + this.generator.Manager.ManagedObjects.Count
                                  + " / " + this.generator.Manager.maxCount);
    }

    #endregion Method
}