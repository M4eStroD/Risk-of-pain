using System;
using System.Collections;
using UnityEngine;

public class ActiveSkill : MonoBehaviour
{
    [SerializeField] private float _recoveryTime = 15f;
    [SerializeField] private float _durationTime = 5f;
    [SerializeField] private float _damageInterval = 0.05f;

    protected bool IsActive = false;

    protected float _currentSkillTime = 0f;

    public event Action<bool> SkillActivated;

    public float CurrentSkillTime => _currentSkillTime;

    public float DurationTime => _durationTime;
    public float RecoveryTime => _recoveryTime;

    public virtual bool TryUse()
    {
        if (IsActive == false && _currentSkillTime == 0)
        {
            IsActive = true;

            _currentSkillTime = 0;

            StartCoroutine(Timer(DurationTime));

            SkillActivated?.Invoke(IsActive);

            return true;
        }

        return false;
    }

    protected virtual void Terminate()
    {
        IsActive = false;
        SkillActivated?.Invoke(IsActive);

        StartCoroutine(Timer(_recoveryTime));
    }

    protected virtual void ApplyEffects() { }

    private IEnumerator Timer(float maxTime)
    {
        float intervalTime = 0.01f;
        float effectInterval = 0f;

        WaitForSeconds wait = new WaitForSeconds(intervalTime);

        while (_currentSkillTime <= maxTime)
        {
            _currentSkillTime += intervalTime;

            if (IsActive)
            {
                if (effectInterval >= _damageInterval)
                {
                    effectInterval = 0f;
                    ApplyEffects();
                }
                else
                {
                    effectInterval += intervalTime;
                }
            }

            yield return wait;
        }

        _currentSkillTime = 0;

        if (IsActive)
            Terminate();
    }
}
