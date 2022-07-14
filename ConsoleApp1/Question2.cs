using ConsoleApp1.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Q2
{
    internal static class Question2
    {
        internal static void DoWork()
        {
        START:
            try
            {
                Console.Write("Input the number of families: ");
                var input = Console.ReadLine();
                var numberOfFamilies = int.Parse(input);

                if (string.IsNullOrWhiteSpace(input))
                    return;

                Console.WriteLine("Input the number of members in the family: ");
                Console.Write("(separated by a space): ");
                input = Console.ReadLine();

                var numberOfFamilyMembers = input.Trim().Split(" ")
                                                .Where(w => !string.IsNullOrWhiteSpace(w))
                                                .ConvertToInt()
                                                .OrderByDescending(o => o)
                                                .ToList();

                if (numberOfFamilyMembers.Count() != numberOfFamilies)
                {
                    throw new Exception("Input must be equal with count of family");
                }

                var totalBus = 0;
                var totalFamilyMembers = numberOfFamilyMembers.Count();

                while (numberOfFamilyMembers.Count() > 0)
                {
                    int currentFamily = numberOfFamilyMembers.First();
                    numberOfFamilyMembers.RemoveAt(0);
                    if (currentFamily == 4)
                    {
                        totalBus++;
                        continue;
                    }
                    else
                    {
                        for (int i = 0; i <= numberOfFamilyMembers.Count(); i++)
                        {
                            int additionalFamily;

                            if (numberOfFamilyMembers.Count() == 1)
                            {
                                additionalFamily = numberOfFamilyMembers.First();

                                if (currentFamily + additionalFamily > 4)
                                {
                                    totalBus += 2;
                                }
                                else
                                {
                                    totalBus++;
                                }
                                numberOfFamilyMembers.RemoveAt(0);
                                break;
                            }

                            additionalFamily = numberOfFamilyMembers.ElementAt(i);

                            if (currentFamily + additionalFamily > 4)
                                continue;


                            totalBus++;
                            numberOfFamilyMembers.RemoveAt(i);

                            break;
                        }
                    }
                }

                Console.Write($"Minimum bus required is : {totalBus}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto START;
            }
        }
    }
}
