using System;
using System.Collections;
using UnityEngine;

public class ActiveSkill : MonoBehaviour
{
    protected bool IsActive = false;

    protected float _currentTime = 0f;

    protected Character Target;

    [SerializeField] private float _recoveryTime = 15f;
    [SerializeField] private float _durationTime = 5f;
    [SerializeField] private float _damageInterval = 0.05f;

    public event Action<bool> SkillActivated;

    public float CurrentTime => _currentTime;

    public float DurationTime => _durationTime;
    public float RecoveryTime => _recoveryTime;

    protected virtual void Terminate()
    {
        IsActive = false;
        SkillActivated?.Invoke(IsActive);

        StartCoroutine(Timer(_recoveryTime));
    }

    protected virtual void ApplyEffects() { }

    public virtual bool TryUse(Character target)
    {
        if (IsActive == false && _currentTime == 0)
        {
            Target = target;
            IsActive = true;

            _currentTime = 0;

            StartCoroutine(Timer(DurationTime));

            SkillActivated?.Invoke(IsActive);

            return true;
        }

        return false;
    }

    private IEnumerator Timer(float maxTime)
    {
        float intervalTime = 0.01f;
        float effectInterval = 0f;

        WaitForSeconds wait = new WaitForSeconds(intervalTime);

        while (_currentTime <= maxTime)
        {
            _currentTime += intervalTime;

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

        _currentTime = 0;

        if (IsActive)
            Terminate();
    }
}
