using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints; // Tablica punktów trasy
    [SerializeField] private float speed = 2f; // Prêdkoœæ poruszania
    [SerializeField] private bool isLooping = true; // Czy trasa ma byæ zapêtlona?

    private int currentWaypointIndex = 0; // Aktualny punkt trasy
    private bool isMoving = true; // Czy AI nadal siê porusza?

    private void Update()
    {
        if (waypoints.Length == 0 || !isMoving) return;

        // Pobierz aktualny punkt trasy
        Transform targetWaypoint = waypoints[currentWaypointIndex];

        // Poruszaj siê w kierunku celu
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        // SprawdŸ, czy AI dotar³o do celu
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            if (currentWaypointIndex < waypoints.Length - 1)
            {
                // PrzejdŸ do kolejnego punktu
                currentWaypointIndex++;
            }
            else
            {
                if (isLooping)
                {
                    // Resetuj do pierwszego punktu, jeœli zapêtlanie jest w³¹czone
                    currentWaypointIndex = 0;
                }
                else
                {
                    // Zatrzymaj ruch, jeœli zapêtlanie jest wy³¹czone
                    isMoving = false;
                }
            }
        }

        // Obróæ AI w stronê celu
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }
}
