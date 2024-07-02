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

    private void ChangeBar(bool isActive)
    {
        StartCoroutine(Timer(isActive));
    }

    private IEnumerator Timer(bool isActive)
    {
        float endPoint = 0;

        if (isActive)
            endPoint = _activeSkill.DurationTime;
        else
            endPoint = _activeSkill.RecoveryTime;

        while (_activeSkill.CurrentTime <= endPoint)
        {
            if (isActive)
                _slider.value = GetPercentBar(endPoint) / _reductionFactor;
            else
                _slider.value = _slider.maxValue - (GetPercentBar(endPoint) / _reductionFactor);

            yield return null;
        }
    }

    private float GetPercentBar(float maxTime)
    {
        return _activeSkill.CurrentTime * _hundredPercent / maxTime;
    }
}
