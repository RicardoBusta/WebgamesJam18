using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public Material mat1;
    public Material mat2;

    public Color col1;
    public Color col2;

    [FormerlySerializedAs("Weapon1")] public WeaponController weapon1;
    [FormerlySerializedAs("Weapon2")] public WeaponController weapon2;

    public float playerSpeed;

    public MeshRenderer[] tintMeshes;

    private Transform _tr;

    public bool paused;

    public bool attacking;

    public bool dashing;

    [FormerlySerializedAs("Weapons")] public WeaponController[] weapons;

    private void Start()
    {
        _tr = transform;

        foreach (var weapon in weapons)
        {
            weapon.FinishAttackEvent += () => attacking = false;
        }
    }

    public void Init()
    {
        SetTint(mat1, col1);
    }

    public void Stop()
    {
        if (paused) return;
        weapon1.SetWalkAnim(false);
        weapon2.SetWalkAnim(false);
    }

    public void Move(Vector3 direction)
    {
        if (paused) return;
        if (dashing) return;

        weapon1.SetWalkAnim(true);
        weapon2.SetWalkAnim(true);
        var scale = Time.deltaTime * playerSpeed;
        _tr.position += scale * direction;
    }

    public void LookAt(Vector3 position)
    {
        if (paused) return;
        if (dashing) return;
        _tr.rotation = Quaternion.LookRotation(position - _tr.position, Vector3.up);
    }

    public void AttackLeftHand()
    {
        if (paused) return;
        if (attacking) return;
        if (dashing) return;
        if (weapon1.Attack())
        {
            attacking = true;
            SetTint(mat1, col1);
        }
    }

    public void AttackRightHand()
    {
        if (paused) return;
        if (attacking) return;
        if (dashing) return;
        if (weapon2.Attack())
        {
            attacking = true;
            SetTint(mat2, col2);
        }
    }

    private void SetTint(Material mat, Color col)
    {
        foreach (var mesh in tintMeshes)
        {
            mesh.material = mat;
        }
    }
}