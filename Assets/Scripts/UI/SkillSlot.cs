using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
    [SerializeField] private ActiveSkill _activeSkill;
    [SerializeField] private Slider _slider;

    private float _hundredPercent = 100;
    private float _reductionFactor = 100;

    private void OnEnable()
    {
        _activeSkill.SkillActivated += ChangeBar;
    }

    private void OnDisable()
    {
        _activeSkill.SkillActivated -= ChangeBar;
    }

    private void ChangeBar()
    {
        StartCoroutine(ChangeDurationBar());
    }

    private IEnumerator ChangeDurationBar()
    {
        while (_activeSkill.CurrentDurationTime != _activeSkill.DurationTime)
        {
            _slider.value = GetPercentDurationBar() / _reductionFactor;

            yield return null;
        }

        StartCoroutine(ChangeRecoveryBar());
    }

    private IEnumerator ChangeRecoveryBar()
    {
        while (_activeSkill.CurrentRecoveryTime >= 0)
        {
            _slider.value = GetPercentRecoveryBar() / _reductionFactor;

            yield return null;
        }
    }

    private float GetPercentDurationBar()
    {
        return _activeSkill.CurrentDurationTime * _hundredPercent / _activeSkill.DurationTime;
    }

    private float GetPercentRecoveryBar()
    {
        return _activeSkill.CurrentRecoveryTime * _hundredPercent / _activeSkill.RecoveryTime;
    }
}
