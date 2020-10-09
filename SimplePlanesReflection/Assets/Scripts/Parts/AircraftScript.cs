namespace Assets.SimplePlanesReflection.Assets.Scripts.Parts
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Text;
   using Game.AircraftIo;
   using UnityEngine;

   public partial class AircraftScript : MonoBehaviourProxyType<AircraftScript>
   {
      private static Property<object> _aircraft = CreateProperty<object>("Aircraft");

      protected AircraftScript()
      {
      }

      public Aircraft Aircraft
      {
         get
         {
            return Aircraft.Wrap(this.Get(_aircraft));
         }
      }
   }
}