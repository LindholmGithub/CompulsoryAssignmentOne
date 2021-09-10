﻿using System;
using System.Collections.Generic;
using System.Globalization;
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
                else if (choice == 4)
                {
                    DeletePet();
                }
                else if (choice == 5)
                {
                    UpdatePet();
                }
                else if (choice == 6)
                {
                    SortPetsExpensive();
                }
                else if (choice == 7)
                {
                    SortPetsCheapest();
                }
            }
            Console.WriteLine(StringConstants.ExitingMenuText);
        }

        private void SortPetsCheapest()
        {
            //▼
            List<Pet> pets = _petService.GetAllPets();
            List<Pet> expensivePets = pets.OrderBy(pet => pet.Price).ToList();
            Console.Clear();
            Console.WriteLine("Here is a list of Pets Sorted by Price (Low-High):");
            Console.WriteLine("");
            PrintBeautifulTable();
            foreach (var pet in expensivePets)
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

        private void SortPetsExpensive()
        {
            //▲
            List<Pet> pets = _petService.GetAllPets();
            List<Pet> expensivePets = pets.OrderByDescending(pet => pet.Price).ToList();
            Console.Clear();
            Console.WriteLine("Here is a list of Pets Sorted by Price (High-Low):");
            Console.WriteLine("");
            PrintBeautifulTable();
            foreach (var pet in expensivePets)
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

        private void UpdatePet()
        {
            GetAllPets();
            Console.WriteLine("");
            Console.WriteLine("Select a pet by entering the ID of the pet:");
            int idToUpdate = Int32.Parse(Console.ReadLine());
            Console.Clear();
            
            //Name
            Console.WriteLine(StringConstants.PleaseEnterPetName);
            var updatePetName = Console.ReadLine();
            if (String.IsNullOrEmpty(updatePetName))
            {
                Console.Clear();
                Console.WriteLine(StringConstants.ValueCannotBeNullText);
                return;
            }
            if (updatePetName.Any(char.IsDigit))
            {
                Console.Clear();
                Console.WriteLine(StringConstants.NamesCannotContainNumbersText);
                return;
            }
            //Type
            Console.WriteLine(StringConstants.PleaseEnterPetType);
            PetType updatePetType = new PetType();
            var petType = Console.ReadLine();
            updatePetType.Name = petType;
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
            var updatePetBirthDay = Console.ReadLine();
            if (String.IsNullOrEmpty(updatePetBirthDay))
            {
                Console.Clear();
                Console.WriteLine(StringConstants.ValueCannotBeNullText);
                return;
            }
            if (updatePetBirthDay.Any(char.IsLetter))
            {
                Console.Clear();
                Console.WriteLine(StringConstants.DatesCannotContainLettersText);
                return;
            }
            if(!DateTime.TryParseExact(updatePetBirthDay, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var tempOne))
            {
                Console.Clear();
                Console.WriteLine(StringConstants.DateWrittenWrongText);
                return;
            }

            //Sold Date
            Console.WriteLine(StringConstants.PleaseEnterPetSoldDate);
            var updatePetSoldDate = Console.ReadLine();
            if (String.IsNullOrEmpty(updatePetSoldDate))
            {
                Console.Clear();
                Console.WriteLine(StringConstants.ValueCannotBeNullText);
                return;
            }
            if (updatePetSoldDate.Any(char.IsLetter))
            {
                Console.Clear();
                Console.WriteLine(StringConstants.DatesCannotContainLettersText);
                return;
            }
            if(!DateTime.TryParseExact(updatePetSoldDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var tempTwo))
            {
                Console.Clear();
                Console.WriteLine(StringConstants.DateWrittenWrongText);
                return;
            }

            //Color
            Console.WriteLine(StringConstants.PleaseEnterPetColor);
            var updatePetColor = Console.ReadLine();
            if (String.IsNullOrEmpty(updatePetColor))
            {
                Console.Clear();
                Console.WriteLine(StringConstants.ValueCannotBeNullText);
                return;
            }
            if (updatePetColor.Any(char.IsDigit))
            {
                Console.Clear();
                Console.WriteLine(StringConstants.ColorsCannotContainNumbersText);
                return;
            }

            //Price
            Console.WriteLine(StringConstants.PleaseEnterPetPrice);
            var updatePetPrice = Console.ReadLine();
            if (String.IsNullOrEmpty(updatePetPrice))
            {
                Console.Clear();
                Console.WriteLine(StringConstants.ValueCannotBeNullText);
                return;
            }
            if (updatePetPrice.Any(char.IsLetter))
            {
                Console.Clear();
                Console.WriteLine(StringConstants.PricesCannotContainLettersText);
                return;
            }
            if(!Double.TryParse(updatePetPrice, out var tempThree))
            {
                Console.Clear();
                Console.WriteLine(StringConstants.NumberWrittenWrongText);
                return;
            }

            var pet = new Pet()
            {
                Id = idToUpdate,
                Name = updatePetName,
                Type = updatePetType,
                BirthDate = DateTime.Parse(updatePetBirthDay),
                SoldDate = DateTime.Parse(updatePetSoldDate),
                Color = updatePetColor,
                Price = Double.Parse(updatePetPrice)

            };
            _petService.Update(pet);
            Console.Clear();
            Console.WriteLine(StringConstants.PetInfoHasBeenUpdated);
        }
        
        
        private void DeletePet()
        {
            Console.WriteLine(StringConstants.PleaseEnterPetId);
            var petId = Console.ReadLine();
            int selectionId = Int32.Parse(petId);
            if (!Int32.TryParse(petId,out int petIdInt))
            {
                Console.Clear();
                Console.WriteLine(StringConstants.PleaseTypeANumberInTheField);
            }
            else
            {
                var deletedPetName = _petService.Delete(selectionId);
                Console.WriteLine($"The pet {deletedPetName} with the ID {petId}, has been deleted.");
            }
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
            if(!DateTime.TryParseExact(petBirthDay, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var tempOne))
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
            if(!DateTime.TryParseExact(petSoldDate,"dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var tempTwo))
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
            _petService.Create(pet);
            Console.Clear();
            Console.WriteLine(StringConstants.PetHasBeenCreatedText);
            PrintBeautifulTable();
            Console.WriteLine($"{pet.Id,-5}"+ "| " +
                              $"{pet.Name,-20}"+ "| " +
                              $"{pet.Type.Name,-10}"+ "| " +
                              $"{pet.BirthDate.ToString("dd-MM-yyyy"),-11}"+ "| " +
                              $"{pet.SoldDate.ToString("dd-MM-yyyy"),-11}"+ "| " +
                              $"{pet.Color,-10}"+ "| " +
                              $"{pet.Price,-10}");
            Console.WriteLine("");
        }

        private void PrintBeautifulTable()
        {
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
                PrintBeautifulTable();
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
            Console.WriteLine(StringConstants.DeletePetText);
            Console.WriteLine(StringConstants.UpdatePetInfoText);
            Console.WriteLine(StringConstants.SortPetsByPriceText);
            Console.WriteLine(StringConstants.CheapestPetsText);
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
                PrintBeautifulTable();
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