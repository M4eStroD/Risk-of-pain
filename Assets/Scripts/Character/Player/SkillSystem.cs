using UnityEngine;

public class SkillSystem : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private ActiveSkill _skill;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            _skill.TryUse(player);
    }
}
