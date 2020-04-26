using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Material mat1;
    public Material mat2;

    public Color col1;
    public Color col2;

    public WeaponController Weapon1;
    public WeaponController Weapon2;

    public float playerSpeed;

    public MeshRenderer[] tintMeshes;

    private Transform _tr;

    public bool paused;

    public TrailRenderer trail;

    private void Start()
    {
        _tr = transform;
    }

    public void Stop()
    {
        if (paused) return;
        Weapon1.SetWalkAnim(false);
        Weapon2.SetWalkAnim(false);
    }

    public void Move(Vector3 direction)
    {
        if (paused) return;
        Weapon1.SetWalkAnim(true);
        Weapon2.SetWalkAnim(true);
        var scale = Time.deltaTime * playerSpeed;
        _tr.position += scale * direction;
    }

    public void LookAt(Vector3 position)
    {
        if (paused) return;
        _tr.rotation = Quaternion.LookRotation(position - _tr.position, Vector3.up);
    }

    public void AttackLeftHand()
    {
        if (paused) return;
        SetTint(mat1, col1);
        Weapon1.Attack();
    }

    public void AttackRightHand()
    {
        if (paused) return;
        SetTint(mat2, col2);
        Weapon2.Attack();
    }

    private void SetTint(Material mat, Color col)
    {
        foreach (var mesh in tintMeshes)
        {
            mesh.material = mat;
        }

        trail.startColor = col;
        trail.endColor = col;
    }
}