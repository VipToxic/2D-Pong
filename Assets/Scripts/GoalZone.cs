using UnityEngine;

public class GoalZone : MonoBehaviour
{
    public MatchManager matchManager;
    public bool isLeftGoal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Bull>() != null)
        {
            if (isLeftGoal)
            {
                matchManager.Player2Scored();
            }
            else
            {
                matchManager.Player1Scored();
            }
        }
    }
}