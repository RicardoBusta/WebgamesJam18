using UnityEngine;

public class RotateAndSwapModel : MonoBehaviour
{
    private float _currentSwapTime;

    private int index;
    public Material[] Materials;
    public MeshRenderer playerBase;
    public MeshRenderer playerBody;
    public float rotateSpeed;

    public float swapTime;

    public MeshRenderer weaponBase;

    public GameObject[] Weapons;

    private void Start()
    {
        _currentSwapTime = 0;
        for (var i = 0; i < Weapons.Length; i++) Weapons[i].SetActive(false);
    }

    private void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        _currentSwapTime -= Time.deltaTime;
        if (_currentSwapTime <= 0)
        {
            _currentSwapTime = swapTime;
            SwapWeapon();
        }
    }

    private void SwapWeapon()
    {
        Weapons[index].SetActive(false);
        index++;
        index %= Weapons.Length;
        Weapons[index].SetActive(true);
        weaponBase.material = Materials[index];
        playerBody.material = Materials[index];
        playerBase.material = Materials[index];
    }
}