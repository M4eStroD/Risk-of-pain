using System;
using System.Collections;
using UnityEngine;

public class ActiveSkill : MonoBehaviour
{
    protected bool IsActive = false;

    protected float _currentRecoveryTime = 0f;
    protected float _currentDurationTime = 0f;

    protected Character Target;

    public event Action SkillActivated;

    [SerializeField] private float _recoveryTime = 15f;
    [SerializeField] private float _durationTime = 5f;

    public float CurrentRecoveryTime => _currentRecoveryTime;
    public float CurrentDurationTime => _currentDurationTime;

    public float DurationTime => _durationTime;
    public float RecoveryTime => _recoveryTime;

    protected virtual void Terminate()
    {
        IsActive = false;
    }

    protected virtual IEnumerator TimerDuration()
    {
        float intervalTime = 0.5f;

        while (_currentDurationTime != _durationTime)
        {
            _currentDurationTime += intervalTime;

            yield return new WaitForSeconds(intervalTime);
        }

        _currentDurationTime = 0;

        Terminate();
        StartCoroutine(TimerRecovery());
    }

    protected IEnumerator TimerRecovery()
    {
        float intervalTime = 0.5f;

        while (_currentRecoveryTime > 0)
        {
            _currentRecoveryTime -= intervalTime;

            yield return new WaitForSeconds(intervalTime); ;
        }
    }

    public virtual bool TryUse(Character target)
    {
        if (_currentRecoveryTime == 0)
        {
            Target = target;
            IsActive = true;

            _currentRecoveryTime = _recoveryTime;
            StartCoroutine(TimerDuration());

            SkillActivated?.Invoke();

            return true;
        }

        return false;
    }
}
