﻿namespace UnityDependency.Test.Capture
{
    using Alquimiaware;
    using AssertExtensions;
    using UnityEngine;
    using UnityHelpers;

    [IntegrationTest.DynamicTest("CreateDefaultsTests")]
    public class Capture_Defaults_CreatedInRoot : MonoBehaviour
    {
        private CaptureScopeSampleDefaultPaths testSubject = null;

        void Start()
        {
            GameObject[] gos = UnityHelpers.CreateHierarchy("Grandparent", "Parent", "Subject");
            GameObject subjectGO = gos[2];
            this.testSubject = subjectGO.AddComponent<CaptureScopeSampleDefaultPaths>();
        }

        void Update()
        {
            try
            {
                this.testSubject.CaptureDependencies();

                this.testSubject.RootChildCollider.gameObject.AssertIsTree("Root/Child");
            }
            finally
            {
                DestroyImmediate(this.testSubject.RootChildCollider.transform.parent.gameObject);
                DestroyImmediate(this.testSubject.transform.parent.parent.gameObject);
            }
        }
    }
}