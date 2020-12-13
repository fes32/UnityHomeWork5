using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private bool _isMaxVolumeReached = false;
    private bool _isAlarm = false;

    private const float _minVolume = 0;
    private const float _maxVolume = 1;

    private void OnTriggerEnter2D(Collider2D    collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            if (_isAlarm)
            {
                DeactivateAlarm();
            }
            else
            {
                ActivateAlarm();
            }
        }
    }

    private void ActivateAlarm()
    {
        _isAlarm = true;
        StartCoroutine(AlarmSignaling());
    }

    private void DeactivateAlarm()
    {
        _audioSource.Stop();
        _isAlarm = false;
    }

    private IEnumerator AlarmSignaling()
    {
        _audioSource.UnPause();
        _audioSource.Play();

        while (_isAlarm)
        {
            if (!_isMaxVolumeReached)
            {
                for (float i = 0; i <= _maxVolume; i += 0.001f)
                {
                    _audioSource.volume = _minVolume + i;
                    yield return null;
                }
                _isMaxVolumeReached = true;
            }
            else
            {
                for (float i = _audioSource.volume; i >= 0; i -= 0.001f)
                {
                    _audioSource.volume = i;
                    yield return null;
                }
                _isMaxVolumeReached = false;
            }
        }
    }
}