﻿using UnityEngine;

namespace ObjectManagementSystem
{
    [RequireComponent(typeof(SampleObjectGenerator))]
    public class SampleObjectGeneratorDebugger : MonoBehaviour
    {

        #region Field

        public KeyCode generateKey = KeyCode.Return;

        public KeyCode removeAllKey = KeyCode.Delete;

        #endregion Field

        #region Property

        public SampleObjectGenerator ObjectGenerator
        {
            get;
            protected set;
        }

        #endregion Property

        #region Method

        protected virtual void Awake()
        {
            this.ObjectGenerator = base.GetComponent<SampleObjectGenerator>();
        }

        protected virtual void Update()
        {
            if (Input.GetKeyDown(this.generateKey))
            {
                this.ObjectGenerator.GenerateRandom<SampleManagedObject>(Vector3.zero);
            }
            if (Input.GetKeyDown(this.removeAllKey))
            {
                this.ObjectGenerator.ObjectManager.RemoveAllManagedObjects();
            }
        }

        #endregion Method


        protected virtual void OnGUI()
        {
            GUI.Label(new Rect(20, 20, 300, 20), "Press " + this.generateKey + " to Add New Object.");
            GUI.Label(new Rect(20, 40, 300, 20), "Press Delete " + this.removeAllKey + " to Remove All Objects.");
            GUI.Label(new Rect(20, 60, 300, 20), "Object Count : " + this.ObjectGenerator.ObjectManager.ManagedObjects.Count
                                                           + " / " + this.ObjectGenerator.ObjectManager.MaxCount);
        }
    }
}