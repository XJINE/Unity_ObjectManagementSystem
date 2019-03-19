using UnityEngine;

public class SampleObjectBehaviour : MonoBehaviour
{
    #region Field

    protected float moveSpeed;
    protected float animSpeed;
    protected Vector3 target;

    #endregion Field

    #region Method

    protected virtual void Awake()
    {
        this.moveSpeed = Random.Range(1f, 3f);
        this.animSpeed = Random.Range(1f, 3f);

        UpdateTargetPosition();

        Destroy(base.gameObject, Random.Range(3f, 15f));
    }

    protected virtual void Update()
    {
        base.transform.position = Vector3.MoveTowards
            (base.transform.position, this.target, Time.deltaTime * this.moveSpeed);

        base.transform.Rotate(this.animSpeed, this.animSpeed, this.animSpeed);

        if (this.transform.position == this.target)
        {
            UpdateTargetPosition();
        }
    }

    private void UpdateTargetPosition()
    {
        this.target = Random.onUnitSphere * 5;
    }

    public void SetColor(Color color)
    {
        MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
        propertyBlock.SetColor("_Color", color);
        base.GetComponent<Renderer>().SetPropertyBlock(propertyBlock);
    }

    #endregion Method
}