using UnityEngine;

public class SkillSystem : MonoBehaviour
{
    [SerializeField] private ActiveSkill _skill;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            _skill.TryUse();
    }
}
