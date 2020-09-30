using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExercises
{
    class AttributesDemo
    {
        public void Run()
        {
            Plane plane = new Plane();
            plane.FlyInOldFashion();
            plane.FlyInNewFashion();
        }
    }

    class Plane
    {
        [Obsolete("The planes should no longer be pilotted this way!", false)]
        public void FlyInOldFashion()
        {

        }

        public void FlyInNewFashion()
        {

        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    class PilotAttribute:Attribute
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public bool IsLicensed { get; private set; }

        public PilotAttribute(string name, int age, bool isLicensed) =>
            (Name, Age, IsLicensed) = (name, age, isLicensed);
    }

    [PilotAttribute("John Johnson", 50, true)]
    class Pilot
    {
        [PilotAttribute("Mike Michael", 30, false)]
        public void PilotPlane()
        {

        }
    }
}
