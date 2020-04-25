using UnityEngine;

public class RotateAndSwapModel : MonoBehaviour
{
    public float rotateSpeed;

    public float swapTime;

    private float _currentSwapTime;

    public GameObject[] Weapons;
    public Material[] Materials;

    public MeshRenderer weaponBase;
    public MeshRenderer playerBody;
    public MeshRenderer playerBase;

    private int index;

    private void Start()
    {
        _currentSwapTime = 0;
        for (var i = 0; i < Weapons.Length; i++)
        {
            Weapons[i].SetActive(false);
        }
    }

    void Update()
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