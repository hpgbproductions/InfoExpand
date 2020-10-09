namespace Assets.SimplePlanesReflection.Assets.Scripts.Parts
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Reflection;
   using System.Text;
   using Game.AircraftIo.Parts;

   public partial class PartScript : MonoBehaviourProxyType<PartScript>
   {
      private static Property<object> _part = CreateProperty<object>("Part");

      protected PartScript()
      {
      }

      public Part Part
      {
         get
         {
            return Part.Wrap(this.Get(_part));
         }
      }
   }
}