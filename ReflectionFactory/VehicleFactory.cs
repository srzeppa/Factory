using System;
using ReflectionFactory.Model;
using System.Reflection;

namespace ReflectionFactory
{
    public abstract class VehicleFactory
    {
        public static BaseVehicle CreateVehicle<T>() where T : BaseVehicle
        {
            return Activator.CreateInstance<T>();
        }

        public static BaseVehicle CreateVehicle(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetType(name).FullName;
            return (BaseVehicle)Activator.CreateComInstanceFrom(assembly.Location, type).Unwrap();
        }
    }
}
