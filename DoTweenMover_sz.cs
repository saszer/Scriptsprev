using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenMover_sz : MonoBehaviour
{
    /// <summary>
    /// Takes current Pos, adds moveby and rotate by to it and sets that as position 1 and current position as position 2/'/////
    /// tweens from position 1 to position 2
    /// </summary>
    //PLACE OBJECTS AT THEIR FINAL DESTINATION FOR THIS SCRIPT

    [SerializeField, Tooltip("Increaments the Local Position and sets it as initial")]
    private Vector3 _moveBy;

    [SerializeField, Tooltip("Rotates and set it as initial")]
    private Quaternion _rotateBy;

    [SerializeField]
    private float _waitBeforeTween;

    [Range(1.0f, 111.1f), SerializeField, Tooltip("Speed")]
    private float _moveDuration = 1.0f;

    [SerializeField]
    private Ease _moveEase = Ease.OutSine;

    [SerializeField, Tooltip("GameObject to Activate After Animation is complete")]
    private GameObject _ActivateAfterTween;

    private Vector3 _targetLocation;
    private Quaternion _targetRot;

    //Initial place before tween animation(set acc to moveby and rotateby).
    private Vector3 _initialPos;
    private Quaternion _initRot;

    Tween _tweenp, _tweenr;

    private void Awake()
    {   
        //capture final position // current
        _targetLocation = transform.localPosition;
        _targetRot = transform.localRotation;

        //initial position // increament to move objects acc to moveby and and rotateby values
        _initialPos = transform.localPosition + _moveBy;
        _initRot = transform.localRotation * _rotateBy;

        
        OnDisable(); //to initialize
    }

    private void OnEnable()
    {
        StartCoroutine(Enable()); 
    }
    
    private IEnumerator Enable()
    {
        yield return new WaitForSeconds(_waitBeforeTween);
        _tweenp = transform.DOLocalMove(_targetLocation, _moveDuration).SetEase(_moveEase);
        _tweenr = transform.DOLocalRotateQuaternion(_targetRot, _moveDuration).SetEase(_moveEase);
    }

    private void OnDisable()
    {
        //housekeeping //kill tween or inum which maybe in progress and interfere with next enable.
        _tweenp.Kill(); _tweenr.Kill();
        StopCoroutine(Enable());

        //initialize
        transform.localPosition = _initialPos;
        transform.localRotation = _initRot;

        if (_ActivateAfterTween != null)
        {
            _ActivateAfterTween.SetActive(false);
        }

    }

    private void Update()
    {
        if (_tweenp.active || _tweenr.active)
        {
            //if tween is ended
            if (_tweenp.ElapsedPercentage() > 0.98 && _tweenr.ElapsedPercentage() > 0.98)
            {
                if (_ActivateAfterTween != null)
                {
                    _ActivateAfterTween.SetActive(true);
                }

            }
        }
    }
}
