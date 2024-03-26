﻿using UnityEngine;

public class GravityGun : MonoBehaviour
{
    //скорость запуска объекта
    public float launchSpeed = 40;
    public float grabDistance;

    //ссылка на объект, который зафиксирован
    private Rigidbody _target = null;
    private bool _isLocked = false;
    private PlayerAim _playerAimComponent;

    void Start()
    {
        _playerAimComponent = GetComponentInParent<PlayerAim>();
    }

    void Update()
    {   //если пушка еще не зафиксировала объект
        if (!_isLocked)
        {   //если нажата левая кнопка мыши
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                //пускаем луч через центр экрана
                if (Physics.Raycast(_playerAimComponent.GetCameraRay(), out hit, grabDistance))
                {   //если луч попал в объект с компонентом Rigidbody и компонентом ящика
                    if (hit.rigidbody != null && hit.rigidbody.TryGetComponent(out Throwable throwable))
                    {   //фиксируем объект
                        LockOnTarget(hit.rigidbody);
                    }
                }
            }
        }
        else
        {   //если есть зафиксированный объект, перемещаем объект в точку пушки каждый кадр
            _target.transform.position = transform.position;
            if (Input.GetMouseButtonDown(0))
            {   //если нажата левая кнопка мыши, отпускаем объект
                ReleaseTarget();
            }
        }
    }

    void LockOnTarget(Rigidbody target)
    {   //запоминаем какой объект зафиксирован
        _target = target;
        //отключаем физику у объекта
        _target.isKinematic = true;
        //перемещаем объект в точку пушки
        _target.transform.position = transform.position;
        _isLocked = true;
    }

    void ReleaseTarget()
    {   //включаем физику у объекта
        _target.isKinematic = false;
        //запускаем объект вперед со скоростью launchSpeed
        _target.velocity = _playerAimComponent.GetDirectionToTargetPoint(transform).normalized * launchSpeed;
        //обнуляем ссылку на объект
        _target = null;
        _isLocked = false;
    }
}
