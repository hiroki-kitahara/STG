﻿using System;
using System.Collections.Generic;
using HK.STG.Systems;
using UnityEngine;

namespace HK.STG.DanmakuSystems
{
    [CreateAssetMenu(menuName = "HK/STG/DanmakuSystem/MuzzleParameter")]
    public sealed class MuzzleParameter : ScriptableObject
    {
        [SerializeField]
        private int initialCoolTime;
        public int InitialCoolTime { get { return this.initialCoolTime; } }

        /// <summary>
        /// ループする回数
        /// </summary>
        /// <remarks>
        /// <c>0</c>の場合は無限ループ
        /// </remarks>
        [SerializeField]
        private int loop;
        public int Loop { get { return this.loop; } }

        [SerializeField]
        private List<Parameter> parameters;

        public List<Parameter> Parameters
        {
            get { return this.parameters; }
        }

        #if UNITY_EDITOR
        void OnValidate()
        {
            this.parameters.ForEach(p => p.OnValidate());
        }
        #endif

        [Serializable]
        public class Parameter
        {
            [SerializeField]
            private Bullet bulletPrefab;
            public Bullet BulletPrefab { get { return this.bulletPrefab; } }

            [SerializeField]
            private bool lookAtPlayer;
            public bool LookAtPlayer { get { return this.lookAtPlayer; } }

            [SerializeField]
            private Range speed;
            public Range Speed { get { return this.speed; } }

            [SerializeField]
            private AngleModifyType angleModifyType;
            public AngleModifyType AngleModifyType { get { return this.angleModifyType; } }

            [SerializeField]
            private Range angle;
            public Range Angle { get { return this.angle; } }

            [SerializeField]
            private int number;
            public int Number { get { return this.number; } }

            [SerializeField]
            private float range;
            public float Range { get { return this.range; } }
            
            [SerializeField]
            private int coolTime;
            public int CoolTime { get { return this.coolTime; } }

#if UNITY_EDITOR
            public void OnValidate()
            {
                this.number = Mathf.Max(this.number, 1);
                this.coolTime = Mathf.Max(this.coolTime, 0);
            }
#endif
        }
    }
}
