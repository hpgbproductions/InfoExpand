namespace Assets.SimplePlanesReflection.Assets.Game.AircraftIo.Parts
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Reflection;
   using System.Text;

   public partial class Part : ProxyType<Part>
   {
      private static Property<int> _id = CreateProperty<int>("Id");

      protected Part()
      {
      }

      public int Id
      {
         get
         {
            return this.Get(_id);
         }
      }
   }
}