using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemBContainers2007Acm.Test
{
    public class Terminal
    {
        public Terminal()
        {
            Stacks = 0;
            Containers = 0;
            Ships = 0;
        }

        public void LoadContainers(string containers)
        {
            
        }

        public int Stacks { get; private set; }
        public int Containers { get; private set; }
        public int Ships { get; set; }

        public int MaximumStacks => Ships;

        public void ReceiveContainers(string containers)
        {
            ValidateContainers(containers);

            SetContainerCount(containers);
            SetShipCount(containers);
        }

        private void ValidateContainers(string containers)
        {
            var hasNumbers = containers.Any(IsNumber);
            if (hasNumbers)
            {
                throw new NumberNotAcceptedException();
            }

            var hasSpecialCharacters = containers.Any(IsSpecialCharacter);
            if (hasSpecialCharacters)
            {
                throw new SpecialCharacterNotAcceptedException();
            }
        }

        private bool IsSpecialCharacter(char container)
        {
            return !IsNumber(container) && 
                !(container >= 65 && container <= 90);
        }

        private bool IsNumber(char container)
        {
            return container >= 48 && container <= 57;
        }

        private void SetShipCount(string containers)
        {
            var distinctContainers = containers.Distinct(new CharComparer()).ToList();
            Ships = distinctContainers.Count;
        }

        private void SetContainerCount(string containers)
        {
            Containers = containers.Length;
        }
    }

    public class CharComparer : IEqualityComparer<char>
    {
        public bool Equals(char x, char y)
        {
            return x.Equals(y);
        }

        public int GetHashCode(char obj)
        {
            var hashProductName = obj.GetHashCode();
            
            return hashProductName;
        }
    }
}