using System;
using System.Collections;
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

			CalculateStacks(containers);
		}

		void CalculateStacks(string containers)
		{
			var stacks = new List<Stack<char>>();
			var containerList = containers.ToList();

			// This loop is the containers arriving at the terminal
			for (int i = 0; i < containerList.Count; i++)
			{
				var incomingContainer = containerList[i];
				// Scenario 1 - Are there no stacks yet?
				if (!stacks.Any())
				{
					AddNewStackWithContainer(stacks, incomingContainer);
					continue;
				}

				// Decide on adding to a stack or creating a new one
				for (int j = 0; j < stacks.Count; j++)
				{
					var stack = stacks[j];
					var peekedContainer = stack.Peek();

					// Scenario 2 - Is the incoming container the same as the peeked one?
					if (incomingContainer.CompareTo(peekedContainer) == 0)
					{
						stack.Push(incomingContainer);
						break;
					}

					// Scenario 3 - Is higher order than peeked, try next stack
					if (incomingContainer.CompareTo(peekedContainer) > 0)
					{
						if (j < (stacks.Count - 1))
						{
							continue;
						}

						// Add new stack if at end of stack list
						AddNewStackWithContainer(stacks, incomingContainer);
						j++;
					}

					// Scenario 4 - Is lower order than peeked, check top stack element reoccurance
					if (incomingContainer.CompareTo(peekedContainer) < 0)
					{
						var isExpectingAnotherPeekedContainer = ExpectAnotherContainerIntoTerminal(peekedContainer, i,
																							   containerList);

						if (isExpectingAnotherPeekedContainer)
						{
							if (j < (stacks.Count - 1))
							{
								continue;
							}

							// Add new stack if at end of stack list
							AddNewStackWithContainer(stacks, incomingContainer);
							j++;
						}
						else
						{
							stack.Push(incomingContainer);
						}
							
					}

				}
			}

			Stacks = stacks.Count;
		}

		bool ExpectAnotherContainerIntoTerminal(char container, int startIndex, List<char> containerList)
		{
			for (int i = startIndex; i < containerList.Count; i++)
			{
				if (container.CompareTo(containerList[i]) == 0)
				{
					return true;
				}
			}

			return false;
		}

		static void AddNewStackWithContainer(List<Stack<char>> stacks, char incomingContainer)
		{
			var stack = new Stack<char>();
			stack.Push(incomingContainer);
			stacks.Add(stack);
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
			var distinctContainers = containers.Distinct(new CharEqualityComparer()).ToList();
			Ships = distinctContainers.Count;
		}

		private void SetContainerCount(string containers)
		{
			Containers = containers.Length;
		}
	}

	
}
