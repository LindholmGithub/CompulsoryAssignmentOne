namespace PetShop.UI
{
    public class StringConstants
    {
        //Menu Choices
        public const string PrintPetListText = "Press 1 to Show All Pets.";
        public const string SearchByPetTypeText = "Press 2 to Search by Pet Type.";
        public const string CreateNewPetText = "Press 3 to Create a New Pet.";
        public const string DeletePetText = "Press 4 to Delete a Pet.";
        public const string UpdatePetInfoText = "Press 5 to Update a Specific Pets Info.";
        public const string SortPetsByPriceText = "Press 6 to Sort the Petlist by Price (High-Low).";
        public const string CheapestPetsText = "Press 7 to Sort the Petlist by Price (Low-High).";
        public const string ExitConsoleText = "Press 0 to Exit the Menu.";

        //Menu Messages
        public const string WelcomeGreeting = "Welcome to the PetShop menu, please select an option below:";
        public const string PetShopText1 = " _____     _      _____ _           ";
        public const string PetShopText2 = "|  _  |___| |_   |   __| |_ ___ ___ ";
        public const string PetShopText3 = "|   __| -_|  _|  |__   |   | . | . |";
        public const string PetShopText4 = "|__|  |___|_|    |_____|_|_|___|  _|";
        public const string PetShopText5 = "                               |_|  ";
        public const string SearchPetTypeByNameText = "Please type the pet type you would like to search for:";
        public const string HereIsAListOfAllPets = "Here is a list of all pets:";
        public const string HereIsAListOfMatchingPets = "Here is a list of all pets matching the searched type:";
        public const string PleaseEnterPetId = "Please enter the ID of the pet:";
        public const string PleaseEnterPetName = "Please enter the pet name:";
        public const string PleaseEnterPetType = "Please enter the pet type:";
        public const string PleaseEnterPetBirthDay = "Please enter the pets birthday with - or / as separators:";
        public const string PleaseEnterPetSoldDate = "Please enter the day the pet was sold with - or / as separators:";
        public const string PleaseEnterPetColor = "Please enter the pet color:";
        public const string PleaseEnterPetPrice = "Please enter the pet price:";
        public const string PetHasBeenCreatedText = "Pet with the following properties created:";
        public const string ExitingMenuText = "Exiting, thanks for using the menu application";
        public const string PleaseSelectThePetInfoToEdit = "Please select the pet info you want to edit: ";
        public const string PetNameHasBeenChanged = "The Selected Pet Name has been changed";
        public const string PetTypeHasBeenChanged = "The Selected Pet Type has been changed";
        public const string PetBirthDayHasBeenChanged = "The Selected Pet Birthday has been changed";
        public const string PetSoldDateHasBeenChanged = "The Selected Pet Sold Date has been changed";
        public const string PetColorHasBeenChanged = "The Selected Pet Color has been changed";
        public const string PetPriceHasBeenChanged = "The Selected Pet Price has been changed";
        
        //Errors
        public const string PleaseTypeANumberInTheField = "Please type in numbers, not letters. Returning to main menu.";
        public const string SeachResultEqualsZero = "Couldn't find a matching pet type, returning to main menu.";
        public const string PetListIsEmptyText = "Couldn't find any results, returning to main menu.";
        public const string NamesCannotContainNumbersText = "Names can't contain numbers, returning to main menu.";
        public const string TypesCannotContainNumbersText = "Types can't contain numbers, returning to main menu.";
        public const string DatesCannotContainLettersText = "Dates can't contain letters, returning to main menu.";
        public const string ColorsCannotContainNumbersText = "Colors can't contain numbers, returning to main menu.";
        public const string PricesCannotContainLettersText = "Prices can't contain letters, returning to main menu.";
        public const string ValueCannotBeNullText = "Field can't be empty, returning to main menu.";
        public const string DateWrittenWrongText = "Date was not valid, returning to main menu.";
        public const string NumberWrittenWrongText = "You actually managed to write a number wrongly. Great job, you have to start over now. Returning to main menu.";
    }
}