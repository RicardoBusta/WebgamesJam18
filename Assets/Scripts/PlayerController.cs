using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform _tr;

    public bool attacking;

    public Color col1;
    public Color col2;

    public GameController controller;

    public bool dashing;

    private bool lastAttackRightHand;
    public Material mat1;
    public Material mat2;

    public bool paused;

    public float playerSpeed;

    public MeshRenderer[] tintMeshes;

    public WeaponController weapon1;
    public WeaponController weapon2;

    public WeaponController[] weapons;

    private void Start()
    {
        _tr = transform;

        foreach (var weapon in weapons) weapon.FinishAttackEvent += () => attacking = false;
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
        if (controller.waitPlayerInput) return;

        weapon1.SetWalkAnim(true);
        weapon2.SetWalkAnim(true);
        var scale = Time.deltaTime * playerSpeed;
        _tr.position += scale * direction;
    }

    public void LookAt(Vector3 position)
    {
        if (paused) return;
        if (dashing) return;
        if (controller.waitPlayerInput) return;
        var lookVector = position - _tr.position;
        if (lookVector == Vector3.zero) return;
        _tr.rotation = Quaternion.LookRotation(lookVector, Vector3.up);
    }

    public void AttackLeftHand()
    {
        if (paused) return;
        if (attacking) return;
        if (dashing) return;
        if (controller.waitPlayerInput) return;
        if (weapon1.Attack())
        {
            attacking = true;
            SetTint(mat1, col1);
        }

        if (lastAttackRightHand)
        {
            lastAttackRightHand = false;
            controller.PlayShockWave(col1);
        }
    }

    public void AttackRightHand()
    {
        if (paused) return;
        if (attacking) return;
        if (dashing) return;
        if (controller.waitPlayerInput) return;
        if (weapon2.Attack())
        {
            attacking = true;
            SetTint(mat2, col2);
        }

        if (!lastAttackRightHand)
        {
            lastAttackRightHand = true;
            controller.PlayShockWave(col2);
        }
    }

    private void SetTint(Material mat, Color col)
    {
        foreach (var mesh in tintMeshes) mesh.material = mat;
    }
}