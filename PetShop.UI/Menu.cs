using System;
using System.Collections.Generic;
using System.Linq;
using PetShop.Core.IServices;
using PetShop.Core.Models;

namespace PetShop.UI
{
    public class Menu : IMenu
    {
        private IPetService _petService;

        public Menu(IPetService petService)
        {
            _petService = petService;
        }

        public void Start()
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("|| " + StringConstants.PetShopText1 + " ||");
            Console.WriteLine("|| " + StringConstants.PetShopText2 + " ||");
            Console.WriteLine("|| " + StringConstants.PetShopText3 + " ||");
            Console.WriteLine("|| " + StringConstants.PetShopText4 + " ||");
            Console.WriteLine("|| " + StringConstants.PetShopText5 + " ||");
            Console.WriteLine("==========================================");
            Console.WriteLine("");
            Console.WriteLine(StringConstants.WelcomeGreeting);
            StartLoop();
        }

        private void StartLoop()
        {
            int choice;
            while ((choice = GetMainMenuSelection()) != 0)
            {
                if (choice == 1)
                {
                    GetAllPets();
                }
                else if (choice == 2)
                {
                    SearchByPetType();
                }
                else if (choice == 3)
                {
                    CreateNewPet();
                }
            }
            Console.WriteLine(StringConstants.ExitingMenuText);
        }

        private void CreateNewPet()
        {
            Console.Clear();
            
            //Name
            Console.WriteLine(StringConstants.PleaseEnterPetName);
            var petName = Console.ReadLine();
            if (String.IsNullOrEmpty(petName))
            {
                Console.Clear();
                Console.WriteLine(StringConstants.ValueCannotBeNullText);
                return;
            }
            if (petName.Any(char.IsDigit))
            {
                Console.Clear();
                Console.WriteLine(StringConstants.NamesCannotContainNumbersText);
                return;
            }
            
            //Type
            Console.WriteLine(StringConstants.PleaseEnterPetType);
            PetType newPetType = new PetType();
            var petType = Console.ReadLine();
            newPetType.Name = petType;
            if (String.IsNullOrEmpty(petType))
            {
                Console.Clear();
                Console.WriteLine(StringConstants.ValueCannotBeNullText);
                return;
            }
            if (petType.Any(char.IsDigit))
            {
                Console.Clear();
                Console.WriteLine(StringConstants.TypesCannotContainNumbersText);
                return;
            }
            
            //Birthday
            Console.WriteLine(StringConstants.PleaseEnterPetBirthDay);
            var petBirthDay = Console.ReadLine();
            if (String.IsNullOrEmpty(petBirthDay))
            {
                Console.Clear();
                Console.WriteLine(StringConstants.ValueCannotBeNullText);
                return;
            }
            if (petBirthDay.Any(char.IsLetter))
            {
                Console.Clear();
                Console.WriteLine(StringConstants.DatesCannotContainLettersText);
                return;
            }
            if(!DateTime.TryParse(petBirthDay, out var tempOne))
            {
                Console.Clear();
                Console.WriteLine(StringConstants.DateWrittenWrongText);
                return;
            }
            //Sold Date
            Console.WriteLine(StringConstants.PleaseEnterPetSoldDate);
            var petSoldDate = Console.ReadLine();
            if (String.IsNullOrEmpty(petSoldDate))
            {
                Console.Clear();
                Console.WriteLine(StringConstants.ValueCannotBeNullText);
                return;
            }
            if (petSoldDate.Any(char.IsLetter))
            {
                Console.Clear();
                Console.WriteLine(StringConstants.DatesCannotContainLettersText);
                return;
            }
            if(!DateTime.TryParse(petSoldDate, out var tempTwo))
            {
                Console.Clear();
                Console.WriteLine(StringConstants.DateWrittenWrongText);
                return;
            }
            //Color
            Console.WriteLine(StringConstants.PleaseEnterPetColor);
            var petColor = Console.ReadLine();
            if (String.IsNullOrEmpty(petColor))
            {
                Console.Clear();
                Console.WriteLine(StringConstants.ValueCannotBeNullText);
                return;
            }
            if (petColor.Any(char.IsDigit))
            {
                Console.Clear();
                Console.WriteLine(StringConstants.ColorsCannotContainNumbersText);
                return;
            }
            //Price
            Console.WriteLine(StringConstants.PleaseEnterPetPrice);
            var petPrice = Console.ReadLine();
            if (String.IsNullOrEmpty(petPrice))
            {
                Console.Clear();
                Console.WriteLine(StringConstants.ValueCannotBeNullText);
                return;
            }
            if (petPrice.Any(char.IsLetter))
            {
                Console.Clear();
                Console.WriteLine(StringConstants.PricesCannotContainLettersText);
                return;
            }
            if(!Double.TryParse(petPrice, out var tempThree))
            {
                Console.Clear();
                Console.WriteLine(StringConstants.NumberWrittenWrongText);
                return;
            }

            var pet = new Pet()
            {
                Name = petName,
                Type = newPetType,
                BirthDate = Convert.ToDateTime(petBirthDay),
                SoldDate = Convert.ToDateTime(petSoldDate),
                Color = petColor,
                Price = Convert.ToDouble(petPrice)
            };
            pet = _petService.Create(pet);
            Console.Clear();
            Console.WriteLine(StringConstants.PetHasBeenCreatedText);
            Console.WriteLine($"{"ID:",-5}" + "| " +
                              $"{"Name:",-20}"+ "| " +
                              $"{"Type:",-10}"+ "| " +
                              $"{"Birth Date:",-11}"+ "| " +
                              $"{"Sold Date:",-11}"+ "| " +
                              $"{"Color:",-10}"+ "| " +
                              $"{"Price:",-10}");
            Console.WriteLine($"{"-----",-5}" + "|-" +
                              $"{"--------------------",-20}"+ "|-" +
                              $"{"----------",-10}"+ "|-" +
                              $"{"-----------",-11}"+ "|-" +
                              $"{"-----------",-11}"+ "|-" +
                              $"{"----------",-10}"+ "|-" +
                              $"{"----------",-10}");
            Console.WriteLine($"{pet.Id,-5}"+ "| " +
                               $"{pet.Name,-20}"+ "| " +
                               $"{pet.Type.Name,-10}"+ "| " +
                               $"{pet.BirthDate.ToString("dd-MM-yyyy"),-11}"+ "| " +
                               $"{pet.SoldDate.ToString("dd-MM-yyyy"),-11}"+ "| " +
                               $"{pet.Color,-10}"+ "| " +
                               $"{pet.Price,-10}");
            Console.WriteLine("");
        }

        private void SearchByPetType()
        {
            Console.Clear();
            Console.WriteLine(StringConstants.SearchPetTypeByNameText);
            string input = Console.ReadLine()?.ToLower();
            List<Pet> tempPetList = _petService.GetPetsByType(input);
            if (tempPetList.Count == 0)
            {
                Console.Clear();
                Console.WriteLine(StringConstants.SeachResultEqualsZero);
            }
            else
            {
                Console.Clear();
                Console.WriteLine(StringConstants.HereIsAListOfMatchingPets);
                Console.WriteLine("");
                Console.WriteLine($"{"ID:",-5}" + "| " +
                                  $"{"Name:",-20}"+ "| " +
                                  $"{"Type:",-10}"+ "| " +
                                  $"{"Birth Date:",-11}"+ "| " +
                                  $"{"Sold Date:",-11}"+ "| " +
                                  $"{"Color:",-10}"+ "| " +
                                  $"{"Price:",-10}");
                Console.WriteLine($"{"-----",-5}" + "|-" +
                                  $"{"--------------------",-20}"+ "|-" +
                                  $"{"----------",-10}"+ "|-" +
                                  $"{"-----------",-11}"+ "|-" +
                                  $"{"-----------",-11}"+ "|-" +
                                  $"{"----------",-10}"+ "|-" +
                                  $"{"----------",-10}");
                foreach (var pet in tempPetList)
                {
                    Console.WriteLine($"{pet.Id,-5}"+ "| " +
                                      $"{pet.Name,-20}"+ "| " +
                                      $"{pet.Type.Name,-10}"+ "| " +
                                      $"{pet.BirthDate.ToString("dd-MM-yyyy"),-11}"+ "| " +
                                      $"{pet.SoldDate.ToString("dd-MM-yyyy"),-11}"+ "| " +
                                      $"{pet.Color,-10}"+ "| " +
                                      $"{pet.Price,-10}");
                }
            }
        }

        private int GetMainMenuSelection()
        {
            ShowMainMenu();
            var selectionString = Console.ReadLine();
            if (int.TryParse(selectionString, out var selection))
            {
                return selection;
            }
            return -1;
        }
        private void ShowMainMenu()
        {
            Console.WriteLine("");
            Console.WriteLine(StringConstants.PrintPetListText);
            Console.WriteLine(StringConstants.SearchByPetTypeText);
            Console.WriteLine(StringConstants.CreateNewPetText);
            Console.WriteLine("");
            Console.WriteLine(StringConstants.ExitConsoleText);
        }

        private void GetAllPets()
        {
            Console.Clear();
            List<Pet> pets = _petService.GetAllPets();
            if (pets.Count == 0)
            {
                Console.Clear();
                Console.WriteLine(StringConstants.PetListIsEmptyText);
            }
            else
            {
                Console.WriteLine(StringConstants.HereIsAListOfAllPets);
                Console.WriteLine("");
                Console.WriteLine($"{"ID:",-5}" + "| " +
                                  $"{"Name:",-20}"+ "| " +
                                  $"{"Type:",-10}"+ "| " +
                                  $"{"Birth Date:",-11}"+ "| " +
                                  $"{"Sold Date:",-11}"+ "| " +
                                  $"{"Color:",-10}"+ "| " +
                                  $"{"Price:",-10}");
                Console.WriteLine($"{"-----",-5}" + "|-" +
                                  $"{"--------------------",-20}"+ "|-" +
                                  $"{"----------",-10}"+ "|-" +
                                  $"{"-----------",-11}"+ "|-" +
                                  $"{"-----------",-11}"+ "|-" +
                                  $"{"----------",-10}"+ "|-" +
                                  $"{"----------",-10}");

                foreach (var pet in pets)
                {
                    Console.WriteLine($"{pet.Id,-5}"+ "| " +
                                      $"{pet.Name,-20}"+ "| " +
                                      $"{pet.Type.Name,-10}"+ "| " +
                                      $"{pet.BirthDate.ToString("dd-MM-yyyy"),-11}"+ "| " +
                                      $"{pet.SoldDate.ToString("dd-MM-yyyy"),-11}"+ "| " +
                                      $"{pet.Color,-10}"+ "| " +
                                      $"{pet.Price,-10}");
                }
            }
        }
    }
}