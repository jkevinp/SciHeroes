using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuestionDictionary  {
    private List<QuestionObject> questionList;
    public List<QuestionObject> QuestionList
    {
        get;
        set;
    }
    public void loadList(string _questionSet)
    {
        List<QuestionObject> _questionList = new List<QuestionObject>();
        _questionSet = _questionSet.ToLower();
        switch (_questionSet)
        {
            case "plant":
            case "plants":
           _questionList.Add(new QuestionObject("Is it true that there are Carnivorous plants?", new string[2] { "true", "false" }, 0));
           _questionList.Add(new QuestionObject("It is the longest-living organism on earth.", new string[3] { "Animals", "Humans", "Trees" }, 2));
           _questionList.Add(new QuestionObject("A chemical that is used to help the plants grow.", new string[3] { "Sunlight", "Fertilizer", "Water" }, 1));
           _questionList.Add(new QuestionObject("This is where water and minerals are converted (changed) into food for the plant.",new string[3]{"Leaves", "Stem" ,"Roots"} , 0));
           _questionList.Add(new QuestionObject("What is a process used by plants and other organisms to convert light energy,normally from the Sun, into chemical energy that can be later released to fuel the organisms.", new string[3] { "Water Photolysis", " Calvin Cycle", "Photosynthesis" }, 2));
           _questionList.Add(new QuestionObject("Gymnosperms and angiosperms are groups of seed-producing plants", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject("Angiosperms are seed plants that produce flowers", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject(" Monocots are plants that produce seed with two leaves", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject("The following are examples of Dicot except:", new string[3] { "Avocado", "Pine Tree" , "Santol" }, 1));
           _questionList.Add(new QuestionObject("The following are characteristic of algae except:", new string[3] { "Have chlorophyll" ,"Do not have chlorophyll","Can make their own food"}, 1));
           _questionList.Add(new QuestionObject("Is it true that there are Carnivorous plants?", new string[2] { "true", "false" }, 0));
           _questionList.Add(new QuestionObject("It is the longest-living organism on earth.", new string[3] { "Animals", "Humans", "Trees" }, 2));
           _questionList.Add(new QuestionObject("A chemical that is used to help the plants grow.", new string[3] { "Sunlight", "Fertilizer", "Water" }, 1));
           _questionList.Add(new QuestionObject("This is where water and minerals are converted (changed) into food for the plant.",new string[3]{"Leaves", "Stem" ,"Roots"} , 0));
           _questionList.Add(new QuestionObject("What is a process used by plants and other organisms to convert light energy,normally from the Sun, into chemical energy that can be later released to fuel the organisms.", new string[3] { "Water Photolysis", " Calvin Cycle", "Photosynthesis" }, 2));
           _questionList.Add(new QuestionObject("Gymnosperms and angiosperms are groups of seed-producing plants", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject("Angiosperms are seed plants that produce flowers", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject(" Monocots are plants that produce seed with two leaves", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject("The following are examples of Dicot except:", new string[3] { "Avocado", "Pine Tree" , "Santol" }, 1));
           _questionList.Add(new QuestionObject("The following are characteristic of algae except:", new string[3] { "Have chlorophyll" ,"Do not have chlorophyll","Can make their own food"}, 1));
           _questionList.Add(new QuestionObject("Is it true that there are Carnivorous plants?", new string[2] { "true", "false" }, 0));
           _questionList.Add(new QuestionObject("It is the longest-living organism on earth.", new string[3] { "Animals", "Humans", "Trees" }, 2));
           _questionList.Add(new QuestionObject("A chemical that is used to help the plants grow.", new string[3] { "Sunlight", "Fertilizer", "Water" }, 1));
           _questionList.Add(new QuestionObject("This is where water and minerals are converted (changed) into food for the plant.",new string[3]{"Leaves", "Stem" ,"Roots"} , 0));
           _questionList.Add(new QuestionObject("What is a process used by plants and other organisms to convert light energy,normally from the Sun, into chemical energy that can be later released to fuel the organisms.", new string[3] { "Water Photolysis", " Calvin Cycle", "Photosynthesis" }, 2));
           _questionList.Add(new QuestionObject("Gymnosperms and angiosperms are groups of seed-producing plants", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject("Angiosperms are seed plants that produce flowers", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject(" Monocots are plants that produce seed with two leaves", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject("The following are examples of Dicot except:", new string[3] { "Avocado", "Pine Tree" , "Santol" }, 1));
           _questionList.Add(new QuestionObject("The following are characteristic of algae except:", new string[3] { "Have chlorophyll" ,"Do not have chlorophyll","Can make their own food"}, 1));
           _questionList.Add(new QuestionObject("Is it true that there are Carnivorous plants?", new string[2] { "true", "false" }, 0));
           _questionList.Add(new QuestionObject("It is the longest-living organism on earth.", new string[3] { "Animals", "Humans", "Trees" }, 2));
           _questionList.Add(new QuestionObject("A chemical that is used to help the plants grow.", new string[3] { "Sunlight", "Fertilizer", "Water" }, 1));
           _questionList.Add(new QuestionObject("This is where water and minerals are converted (changed) into food for the plant.",new string[3]{"Leaves", "Stem" ,"Roots"} , 0));
           _questionList.Add(new QuestionObject("What is a process used by plants and other organisms to convert light energy,normally from the Sun, into chemical energy that can be later released to fuel the organisms.", new string[3] { "Water Photolysis", " Calvin Cycle", "Photosynthesis" }, 2));
           _questionList.Add(new QuestionObject("Gymnosperms and angiosperms are groups of seed-producing plants", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject("Angiosperms are seed plants that produce flowers", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject(" Monocots are plants that produce seed with two leaves", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject("The following are examples of Dicot except:", new string[3] { "Avocado", "Pine Tree" , "Santol" }, 1));
           _questionList.Add(new QuestionObject("The following are characteristic of algae except:", new string[3] { "Have chlorophyll" ,"Do not have chlorophyll","Can make their own food"}, 1));
 
                _questionList.Add(new QuestionObject("Is it true that there are Carnivorous plants?", new string[2] { "true", "false" }, 0));
           _questionList.Add(new QuestionObject("It is the longest-living organism on earth.", new string[3] { "Animals", "Humans", "Trees" }, 2));
           _questionList.Add(new QuestionObject("A chemical that is used to help the plants grow.", new string[3] { "Sunlight", "Fertilizer", "Water" }, 1));
           _questionList.Add(new QuestionObject("This is where water and minerals are converted (changed) into food for the plant.",new string[3]{"Leaves", "Stem" ,"Roots"} , 0));
           _questionList.Add(new QuestionObject("What is a process used by plants and other organisms to convert light energy,normally from the Sun, into chemical energy that can be later released to fuel the organisms.", new string[3] { "Water Photolysis", " Calvin Cycle", "Photosynthesis" }, 2));
           _questionList.Add(new QuestionObject("Gymnosperms and angiosperms are groups of seed-producing plants", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject("Angiosperms are seed plants that produce flowers", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject(" Monocots are plants that produce seed with two leaves", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject("The following are examples of Dicot except:", new string[3] { "Avocado", "Pine Tree" , "Santol" }, 1));
           _questionList.Add(new QuestionObject("The following are characteristic of algae except:", new string[3] { "Have chlorophyll" ,"Do not have chlorophyll","Can make their own food"}, 1));
           _questionList.Add(new QuestionObject("Is it true that there are Carnivorous plants?", new string[2] { "true", "false" }, 0));
           _questionList.Add(new QuestionObject("It is the longest-living organism on earth.", new string[3] { "Animals", "Humans", "Trees" }, 2));
           _questionList.Add(new QuestionObject("A chemical that is used to help the plants grow.", new string[3] { "Sunlight", "Fertilizer", "Water" }, 1));
           _questionList.Add(new QuestionObject("This is where water and minerals are converted (changed) into food for the plant.",new string[3]{"Leaves", "Stem" ,"Roots"} , 0));
           _questionList.Add(new QuestionObject("What is a process used by plants and other organisms to convert light energy,normally from the Sun, into chemical energy that can be later released to fuel the organisms.", new string[3] { "Water Photolysis", " Calvin Cycle", "Photosynthesis" }, 2));
           _questionList.Add(new QuestionObject("Gymnosperms and angiosperms are groups of seed-producing plants", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject("Angiosperms are seed plants that produce flowers", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject(" Monocots are plants that produce seed with two leaves", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject("The following are examples of Dicot except:", new string[3] { "Avocado", "Pine Tree" , "Santol" }, 1));
           _questionList.Add(new QuestionObject("The following are characteristic of algae except:", new string[3] { "Have chlorophyll" ,"Do not have chlorophyll","Can make their own food"}, 1));
           _questionList.Add(new QuestionObject("Is it true that there are Carnivorous plants?", new string[2] { "true", "false" }, 0));
           _questionList.Add(new QuestionObject("It is the longest-living organism on earth.", new string[3] { "Animals", "Humans", "Trees" }, 2));
           _questionList.Add(new QuestionObject("A chemical that is used to help the plants grow.", new string[3] { "Sunlight", "Fertilizer", "Water" }, 1));
           _questionList.Add(new QuestionObject("This is where water and minerals are converted (changed) into food for the plant.",new string[3]{"Leaves", "Stem" ,"Roots"} , 0));
           _questionList.Add(new QuestionObject("What is a process used by plants and other organisms to convert light energy,normally from the Sun, into chemical energy that can be later released to fuel the organisms.", new string[3] { "Water Photolysis", " Calvin Cycle", "Photosynthesis" }, 2));
           _questionList.Add(new QuestionObject("Gymnosperms and angiosperms are groups of seed-producing plants", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject("Angiosperms are seed plants that produce flowers", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject(" Monocots are plants that produce seed with two leaves", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject("The following are examples of Dicot except:", new string[3] { "Avocado", "Pine Tree" , "Santol" }, 1));
           _questionList.Add(new QuestionObject("The following are characteristic of algae except:", new string[3] { "Have chlorophyll" ,"Do not have chlorophyll","Can make their own food"}, 1));
           _questionList.Add(new QuestionObject("Is it true that there are Carnivorous plants?", new string[2] { "true", "false" }, 0));
           _questionList.Add(new QuestionObject("It is the longest-living organism on earth.", new string[3] { "Animals", "Humans", "Trees" }, 2));
           _questionList.Add(new QuestionObject("A chemical that is used to help the plants grow.", new string[3] { "Sunlight", "Fertilizer", "Water" }, 1));
           _questionList.Add(new QuestionObject("This is where water and minerals are converted (changed) into food for the plant.",new string[3]{"Leaves", "Stem" ,"Roots"} , 0));
           _questionList.Add(new QuestionObject("What is a process used by plants and other organisms to convert light energy,normally from the Sun, into chemical energy that can be later released to fuel the organisms.", new string[3] { "Water Photolysis", " Calvin Cycle", "Photosynthesis" }, 2));
           _questionList.Add(new QuestionObject("Gymnosperms and angiosperms are groups of seed-producing plants", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject("Angiosperms are seed plants that produce flowers", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject(" Monocots are plants that produce seed with two leaves", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject("The following are examples of Dicot except:", new string[3] { "Avocado", "Pine Tree" , "Santol" }, 1));
           _questionList.Add(new QuestionObject("The following are characteristic of algae except:", new string[3] { "Have chlorophyll" ,"Do not have chlorophyll","Can make their own food"}, 1));
 
                _questionList.Add(new QuestionObject("Is it true that there are Carnivorous plants?", new string[2] { "true", "false" }, 0));
           _questionList.Add(new QuestionObject("It is the longest-living organism on earth.", new string[3] { "Animals", "Humans", "Trees" }, 2));
           _questionList.Add(new QuestionObject("A chemical that is used to help the plants grow.", new string[3] { "Sunlight", "Fertilizer", "Water" }, 1));
           _questionList.Add(new QuestionObject("This is where water and minerals are converted (changed) into food for the plant.",new string[3]{"Leaves", "Stem" ,"Roots"} , 0));
           _questionList.Add(new QuestionObject("What is a process used by plants and other organisms to convert light energy,normally from the Sun, into chemical energy that can be later released to fuel the organisms.", new string[3] { "Water Photolysis", " Calvin Cycle", "Photosynthesis" }, 2));
           _questionList.Add(new QuestionObject("Gymnosperms and angiosperms are groups of seed-producing plants", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject("Angiosperms are seed plants that produce flowers", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject(" Monocots are plants that produce seed with two leaves", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject("The following are examples of Dicot except:", new string[3] { "Avocado", "Pine Tree" , "Santol" }, 1));
           _questionList.Add(new QuestionObject("The following are characteristic of algae except:", new string[3] { "Have chlorophyll" ,"Do not have chlorophyll","Can make their own food"}, 1));
           _questionList.Add(new QuestionObject("Is it true that there are Carnivorous plants?", new string[2] { "true", "false" }, 0));
           _questionList.Add(new QuestionObject("It is the longest-living organism on earth.", new string[3] { "Animals", "Humans", "Trees" }, 2));
           _questionList.Add(new QuestionObject("A chemical that is used to help the plants grow.", new string[3] { "Sunlight", "Fertilizer", "Water" }, 1));
           _questionList.Add(new QuestionObject("This is where water and minerals are converted (changed) into food for the plant.",new string[3]{"Leaves", "Stem" ,"Roots"} , 0));
           _questionList.Add(new QuestionObject("What is a process used by plants and other organisms to convert light energy,normally from the Sun, into chemical energy that can be later released to fuel the organisms.", new string[3] { "Water Photolysis", " Calvin Cycle", "Photosynthesis" }, 2));
           _questionList.Add(new QuestionObject("Gymnosperms and angiosperms are groups of seed-producing plants", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject("Angiosperms are seed plants that produce flowers", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject(" Monocots are plants that produce seed with two leaves", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject("The following are examples of Dicot except:", new string[3] { "Avocado", "Pine Tree" , "Santol" }, 1));
           _questionList.Add(new QuestionObject("The following are characteristic of algae except:", new string[3] { "Have chlorophyll" ,"Do not have chlorophyll","Can make their own food"}, 1));
           _questionList.Add(new QuestionObject("Is it true that there are Carnivorous plants?", new string[2] { "true", "false" }, 0));
           _questionList.Add(new QuestionObject("It is the longest-living organism on earth.", new string[3] { "Animals", "Humans", "Trees" }, 2));
           _questionList.Add(new QuestionObject("A chemical that is used to help the plants grow.", new string[3] { "Sunlight", "Fertilizer", "Water" }, 1));
           _questionList.Add(new QuestionObject("This is where water and minerals are converted (changed) into food for the plant.",new string[3]{"Leaves", "Stem" ,"Roots"} , 0));
           _questionList.Add(new QuestionObject("What is a process used by plants and other organisms to convert light energy,normally from the Sun, into chemical energy that can be later released to fuel the organisms.", new string[3] { "Water Photolysis", " Calvin Cycle", "Photosynthesis" }, 2));
           _questionList.Add(new QuestionObject("Gymnosperms and angiosperms are groups of seed-producing plants", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject("Angiosperms are seed plants that produce flowers", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject(" Monocots are plants that produce seed with two leaves", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject("The following are examples of Dicot except:", new string[3] { "Avocado", "Pine Tree" , "Santol" }, 1));
           _questionList.Add(new QuestionObject("The following are characteristic of algae except:", new string[3] { "Have chlorophyll" ,"Do not have chlorophyll","Can make their own food"}, 1));
           _questionList.Add(new QuestionObject("Is it true that there are Carnivorous plants?", new string[2] { "true", "false" }, 0));
           _questionList.Add(new QuestionObject("It is the longest-living organism on earth.", new string[3] { "Animals", "Humans", "Trees" }, 2));
           _questionList.Add(new QuestionObject("A chemical that is used to help the plants grow.", new string[3] { "Sunlight", "Fertilizer", "Water" }, 1));
           _questionList.Add(new QuestionObject("This is where water and minerals are converted (changed) into food for the plant.",new string[3]{"Leaves", "Stem" ,"Roots"} , 0));
           _questionList.Add(new QuestionObject("What is a process used by plants and other organisms to convert light energy,normally from the Sun, into chemical energy that can be later released to fuel the organisms.", new string[3] { "Water Photolysis", " Calvin Cycle", "Photosynthesis" }, 2));
           _questionList.Add(new QuestionObject("Gymnosperms and angiosperms are groups of seed-producing plants", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject("Angiosperms are seed plants that produce flowers", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject(" Monocots are plants that produce seed with two leaves", new string[2] { "True", "False" }, 0));
           _questionList.Add(new QuestionObject("The following are examples of Dicot except:", new string[3] { "Avocado", "Pine Tree" , "Santol" }, 1));
           _questionList.Add(new QuestionObject("The following are characteristic of algae except:", new string[3] { "Have chlorophyll" ,"Do not have chlorophyll","Can make their own food"}, 1));
 
           
           
           
           break;
        }

        this.QuestionList = _questionList;
    }
}
