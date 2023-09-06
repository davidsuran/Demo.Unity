using Assets.Scripts.Battlefield.Data.Serializable;
using Assets.Scripts.Battlefield.Data.StateMachine;
using Assets.Scripts.Core.Components;
using Assets.Scripts.Core.Providers;
using Assets.Scripts.Core.StateMachines.Player.States;
using Assets.Scripts.Core.StateMachines.Weapons;
using Demo.Data.Units;
using System;
using UnityEngine;

namespace Assets.Scripts.Core.StateMachines.Player
{
    //[RequireComponent(typeof(InputReader))]
    //[RequireComponent(typeof(Animator))]
    //[RequireComponent(typeof(CharacterController))]
    //[RequireComponent(typeof(HealthPointsComponent))]
    //[RequireComponent(typeof(ActionPointsComponent))]
    //[RequireComponent(typeof(HitableComponent))]
    public class PlayerStateMachine : StateMachine
    {
        #region Const

        public const int CAMERA_LOOK_AT_POINT_INDEX = 1;

        public const int FREELOOK_INDEX = 2;

        #endregion

        public Vector3 Velocity;
        public float MovementSpeed { get; private set; } = 5f;
        public float JumpForce { get; private set; } = 5f;
        public float LookRotationDampFactor { get; private set; } = 10f;
        public Transform MainCamera { get; private set; }
        public Animator Animator { get; private set; }
        public CharacterController Controller { get; private set; }
        public Rigidbody Rigidbody { get; private set; }
        public GameObject FreeLook { get; private set; }
        public Transform CameraLookAt { get; private set; }

        #region Components

        public HealthPointsComponent HealthPointsComponent { get; private set; }
        public ActionPointsComponent ActionPointsComponent { get; private set; }
        public HitableComponent HitableComponent { get; private set; }
        public CritableComponent[] CritableComponents { get; private set; }
        public ActionSwitchingComponent ActionSwitchingComponent { get; private set; }

        #endregion Components

        public GameObjectPooler pool;
         
        public MachineGunStateMachine MachineGunStateMachine { get; private set; }

        public Unit Unit { get; set; }
    
        private void Awake()
        {
            Debug.Log("Start called");
            MainCamera = Camera.main.transform;
            CameraLookAt = transform.GetChild(CAMERA_LOOK_AT_POINT_INDEX).gameObject.transform;
            FreeLook = transform.GetChild(FREELOOK_INDEX).gameObject;

            //InputReader = GetComponent<InputReader>();
            Animator = GetComponent<Animator>();
            Controller = GetComponent<CharacterController>();
            Rigidbody = GetComponent<Rigidbody>();
            
            HitableComponent = GetComponent<HitableComponent>();

            CritableComponents = GetComponentsInChildren<CritableComponent>();

            MachineGunStateMachine = transform.Find("Gun").GetComponent<MachineGunStateMachine>();

            HealthPointsComponent = GetComponent<HealthPointsComponent>();
            ActionPointsComponent = GetComponent<ActionPointsComponent>();
            //ActionSwitchingComponent = GetComponent<ActionSwitchingComponent>();

            Velocity.y = Physics.gravity.y;


        }

        public void OnDisable()
        {
            ActiveUnitProvider.Instance.UnLoadUnit();
        }

        /// <summary>
        /// Starts the of turn.
        /// </summary>
        internal void StartOfTurn()
        {
            BattlefieldProvider.Instance.ShowUnitsHealthBar();
            BattlefieldProvider.Instance.ShowUnitsActionBar();

            ActionPointsComponent.SetUp(Unit.Stats.ActionPoints);

            SwitchState(new PlayerMoveState(this));
        }

        internal void SwitchToActiveState()
        {
            SwitchState(new PlayerMoveState(this));
        }

        /// <summary>
        /// Switchs the state of to not my turn.
        /// </summary>
        internal void SwitchToNotMyTurnState()
        {
            BattlefieldProvider.Instance.HideUnitsHealthBar();
            BattlefieldProvider.Instance.HideUnitsActionBar();

            Debug.Log("Switch to not my turn state.");

            //FreeLook.SetActive(false);

            SwitchState(new PlayerNotMyTurnState(this));
        }

        /// <summary>
        /// Sets the initial stats.
        /// </summary>
        /// <param name="stats">The stats.</param>
        private void SetupInitialStats(Stats stats)
        {
            HealthPointsComponent.SetUp(stats.HealthPoints);
            ActionPointsComponent.SetUp(stats.ActionPoints);

        }

        /// <summary>
        /// Sets the unit.
        /// </summary>
        /// <param name="soldier">The soldier.</param>
        internal void SetUnit(Soldier soldier)
        {
            Unit = soldier;
            SetupInitialStats(Unit.Stats);
        }

        /// <summary>
        /// Aimings the end.
        /// </summary>
        public void AimingEnd(int i)
        {
            Debug.Log($"Aiming end {i}");

            PlayerPreparingActionState preparingActionState = currentState as PlayerPreparingActionState;

            if (preparingActionState == null )
            {
                throw new InvalidOperationException($"Aiming End should be called only when in {nameof(PlayerPreparingActionState)}");
            }

            preparingActionState.ShowAimLine();
        }
    }
}
