using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

[RequireComponent(typeof(PlayerInput))]
public class GamepadVibrate : MonoBehaviour
{

    private Gamepad _plyGamepad;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _plyGamepad = GetGamepadFromDevices(_playerInput.devices);
    }

    /// <summary>
    /// Return true if the player owns a gamepad
    /// </summary>
    /// <returns></returns>
    public bool IsPlayerDeviceAGamepad()
    {
        return _plyGamepad != null;
    }

    /// <summary>
    /// Set the vibration of the gamepad
    /// </summary>
    /// <param name="leftMotor"> Speed of the low-frequency (left) motor. Normalized [0..1] value
    /// with 1 indicating maximum speed and 0 indicating the motor is turned off. Will automatically
    /// be clamped into range.</param>
    /// <param name="rightMotor">Speed of the high-frequency (right) motor. Normalized [0..1] value
    /// with 1 indicating maximum speed and 0 indicating the motor is turned off. Will automatically
    /// be clamped into range.</param>
    public void Vibrate(float leftMotor, float rightMotor)
    {
        _plyGamepad?.SetMotorSpeeds(leftMotor, rightMotor);
    }

    /// <summary>
    /// Set the vibration of the gamepad for a specified time
    /// </summary>
    /// <param name="leftMotor"> Speed of the low-frequency (left) motor. Normalized [0..1] value
    /// with 1 indicating maximum speed and 0 indicating the motor is turned off. Will automatically
    /// be clamped into range.</param>
    /// <param name="rightMotor">Speed of the high-frequency (right) motor. Normalized [0..1] value
    /// with 1 indicating maximum speed and 0 indicating the motor is turned off. Will automatically
    /// be clamped into range.</param>
    /// <param name="duration"> The time of the vibration</param>
    public void Vibrate(float leftMotor, float rightMotor, float duration)
    {
        this.Vibrate(leftMotor, rightMotor);
        Invoke(nameof(StopVibrations), duration);
    }

    /// <summary>
    /// Stop the GamePad's vibrations
    /// </summary>
    public void StopVibrations()
    {
        _plyGamepad?.SetMotorSpeeds(0, 0);
    }


    private static Gamepad GetGamepadFromDevices(ReadOnlyArray<InputDevice> inputDevice)
    {
        foreach (InputDevice device in inputDevice)
        {
            if (device is Gamepad gamepad)
            {
                return gamepad;
            }
        }
        return null;
    }

}