using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Material mat1;
    public Material mat2;

    public float playerSpeed;

    public MeshRenderer[] tintMeshes;
    
    private Transform _tr;

    private void Start()
    {
        _tr = transform;
    }

    public void Move(Vector3 direction)
    {
        var scale = Time.deltaTime * playerSpeed;
        _tr.position += scale * direction;
    }

    public void LookAt(Vector3 position)
    {
        _tr.rotation = Quaternion.LookRotation(position - _tr.position, Vector3.up);
    }

    public void AttackLeftHand()
    {
        SetTint(mat1);
    }

    public void AttackRightHand()
    {
        SetTint(mat2);
    }

    private void SetTint(Material mat)
    {
        foreach (var mesh in tintMeshes)
        {
            mesh.material = mat;
        }
    }
}