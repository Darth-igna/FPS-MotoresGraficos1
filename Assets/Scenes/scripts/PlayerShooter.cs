using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private InputActionProperty shootInput;
    [SerializeField] private Rigidbody projectilePrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private bool useImpulse = true;
    [SerializeField] private float impulse = 20f;
    [SerializeField] private float initialSpeed = 20f;

    private InputAction shootAction;

    private void OnEnable()
    {
        shootAction = shootInput.action;
        if (shootAction == null) return;

        shootAction.performed += OnShoot;
        shootAction.Enable();
    }

    private void OnDisable()
    {
        if (shootAction == null) return;

        shootAction.performed -= OnShoot;
        shootAction.Disable();
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        if (projectilePrefab == null || spawnPoint == null) return;

        Rigidbody projectile = Instantiate(
            projectilePrefab,
            spawnPoint.position,
            spawnPoint.rotation
        );

        if (useImpulse)
            projectile.AddForce(spawnPoint.forward * impulse,
                                ForceMode.Impulse);
        else
            projectile.linearVelocity = spawnPoint.forward * initialSpeed;
    }
}
