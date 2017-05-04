using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Lorenz_Attractors
{
   public class ResourcesManager<T>
   {
      Game Game { get; set; }
      string ResourcesLocation { get; set; }
      List<BasicResource<T>> ResourceList { get; set; }

      public ResourcesManager(Game game, string resourcesLocation)
      {
         Game = game;
         ResourcesLocation = resourcesLocation;
         ResourceList = new List<BasicResource<T>>();
      }

      public void Add(string name, T existingResource)
      {
         BasicResource<T> ressourceÀAjouter = new BasicResource<T>(name, existingResource);
         if (!ResourceList.Contains(ressourceÀAjouter))
         {
            ResourceList.Add(ressourceÀAjouter);
         }
      }

      void Add(BasicResource<T> ressourceÀAjouter)
      {
         ressourceÀAjouter.Load();
         ResourceList.Add(ressourceÀAjouter);
      }

      public T Find(string resourceName)
      {
         const int RESOURCE_NOT_FOUND = -1;
         BasicResource<T> resourceToFind = new BasicResource<T>(Game.Content, ResourcesLocation, resourceName);
         int resourceIndex = ResourceList.IndexOf(resourceToFind);
         if (resourceIndex == RESOURCE_NOT_FOUND)
         {
            Add(resourceToFind);
            resourceIndex = ResourceList.Count - 1;
         }
         return ResourceList[resourceIndex].Resource;
      }
   }
}
