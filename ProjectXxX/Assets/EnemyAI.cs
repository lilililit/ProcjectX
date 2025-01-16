using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints; // Tablica punkt�w trasy
    [SerializeField] private float speed = 2f; // Pr�dko�� poruszania
    [SerializeField] private bool isLooping = true; // Czy trasa ma by� zap�tlona?

    private int currentWaypointIndex = 0; // Aktualny punkt trasy
    private bool isMoving = true; // Czy AI nadal si� porusza?

    private void Update()
    {
        if (waypoints.Length == 0 || !isMoving) return;

        // Pobierz aktualny punkt trasy
        Transform targetWaypoint = waypoints[currentWaypointIndex];

        // Poruszaj si� w kierunku celu
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        // Sprawd�, czy AI dotar�o do celu
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            if (currentWaypointIndex < waypoints.Length - 1)
            {
                // Przejd� do kolejnego punktu
                currentWaypointIndex++;
            }
            else
            {
                if (isLooping)
                {
                    // Resetuj do pierwszego punktu, je�li zap�tlanie jest w��czone
                    currentWaypointIndex = 0;
                }
                else
                {
                    // Zatrzymaj ruch, je�li zap�tlanie jest wy��czone
                    isMoving = false;
                }
            }
        }

        // Obr�� AI w stron� celu
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }
}
