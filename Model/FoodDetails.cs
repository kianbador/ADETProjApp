using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADETProjApp.Model
{
    public class FoodDetails
    {
        public static ObservableCollection<Food> AlaCarte = new ObservableCollection<Food>()
        {
            new Food() {Id="AC1", foodName = "1 pc Chicken Pop", price = "73", imagePath = "..\\img\\Food\\AlaCarteMeals\\1chieckenpop.png", Quantity=0},
            new Food() {Id="AC2", foodName = "2 pcs Chicken Pop", price = "107", imagePath = "..\\img\\Food\\AlaCarteMeals\\2chieckenpop.png",  Quantity=0},
            new Food() {Id="AC3", foodName = "5 pcs Lumpiang Shanghai", price = "69", imagePath = "..\\img\\Food\\AlaCarteMeals\\lumpiangshanghai.png",  Quantity=0},
            new Food() {Id="AC4", foodName = "Master's Spaghetti", price = "59", imagePath = "..\\img\\Food\\AlaCarteMeals\\masterspaghetti.png",  Quantity=0},
            new Food() {Id="AC5", foodName = "Classic Macaroons", price = "49", imagePath = "..\\img\\Food\\AlaCarteMeals\\classicmacaroons.png",  Quantity=0},
            new Food() {Id="AC6", foodName = "Master's Lasagna", price = "53", imagePath = "..\\img\\Food\\AlaCarteMeals\\masterslasagna.png",  Quantity=0}
        };

        public static ObservableCollection<Food> Sides = new ObservableCollection<Food>()
        {
            new Food() {Id="S1", foodName = "Rice", price = "25", imagePath = "..\\img\\Food\\SideMeals\\rice.png", Quantity=0},
            new Food() {Id="S2", foodName = "Fries", price = "38", imagePath = "..\\img\\Food\\SideMeals\\fries.png",  Quantity=0},
            new Food() {Id="S3", foodName = "Mashed Potato", price = "23", imagePath = "..\\img\\Food\\SideMeals\\mashedpotato.png",  Quantity=0},
            new Food() {Id="S4", foodName = "Nuggets", price = "39", imagePath = "..\\img\\Food\\SideMeals\\nuggets.png",  Quantity=0},
            new Food() {Id="S5", foodName = "ChichaFries", price = "34", imagePath = "..\\img\\Food\\SideMeals\\chichafries.png",  Quantity=0},
            new Food() {Id="S6", foodName = "Nuuggy Fries", price = "53", imagePath = "..\\img\\Food\\SideMeals\\nuggyfries.png",  Quantity=0}
        };

        public static ObservableCollection<Food> SoloValue = new ObservableCollection<Food>()
        {
            new Food() {Id="SV1", foodName = "AC1 w/ Coke", price = "123", imagePath = "..\\img\\Food\\Solo\\a1.png", Quantity=0},
            new Food() {Id="SV2", foodName = "AC2 w/ Fries", price = "161", imagePath = "..\\img\\Food\\Solo\\a2.png",  Quantity=0},
            new Food() {Id="SV3", foodName = "AC3 w/ Affogato", price = "184", imagePath = "..\\img\\Food\\Solo\\a3.png",  Quantity=0},
            new Food() {Id="SV4", foodName = "AC4 w/ Master's Frappe", price = "78", imagePath = "..\\img\\Food\\Solo\\a4.png",  Quantity=0},
            new Food() {Id="SV5", foodName = "AC5 w/ Fries", price = "99", imagePath = "..\\img\\Food\\Solo\\a5.png",  Quantity=0},
            new Food() {Id="SV6", foodName = "AC6 w/ Float & 1 pc Pizza", price = "89", imagePath = "..\\img\\Food\\Solo\\a6.png",  Quantity=0}
        };

        public static ObservableCollection<Food> MatchyCombo = new ObservableCollection<Food>()
        {
            new Food() {Id="MC1", foodName = "Scoopy Fries", price = "64", imagePath = "..\\img\\Food\\MatchyCombo\\scoopyfries.png", Quantity=0},
            new Food() {Id="MC2", foodName = "Frappe Lasagna", price = "123", imagePath = "..\\img\\Food\\MatchyCombo\\frappelasagna.png",  Quantity=0},
            new Food() {Id="MC3", foodName = "Mashed Nuggets Fries + Coke", price = "150", imagePath = "..\\img\\Food\\MatchyCombo\\mashednuggetsfriescoke.png",  Quantity=0},
            new Food() {Id="MC4", foodName = "Scoopy ChichaFries", price = "69", imagePath = "..\\img\\Food\\MatchyCombo\\scoopychichafries.png",  Quantity=0},
            new Food() {Id="MC5", foodName = "SuperScoop Fries", price = "69", imagePath = "..\\img\\Food\\MatchyCombo\\superscoopfries.png",  Quantity=0},
            new Food() {Id="MC6", foodName = "Ube Affogato", price = "69", imagePath = "..\\img\\Food\\MatchyCombo\\ubeaffogato.png",  Quantity=0},
            new Food() {Id="MC7", foodName = "Nuggets Fries", price = "89", imagePath = "..\\img\\Food\\MatchyCombo\\nuggetsfries.png",  Quantity=0}
        };

        public static ObservableCollection<Food> Pizza = new ObservableCollection<Food>()
        {
            new Food() {Id="P1", foodName = "Pepperoni Pizza", price = "298", imagePath = "..\\img\\Food\\Pizza\\pepperonipizza.png", Quantity=0},
            new Food() {Id="P2", foodName = "Hawaiian Pizza", price = "298", imagePath = "..\\img\\Food\\Pizza\\hawaianpizza.png",  Quantity=0},
            new Food() {Id="P3", foodName = "Ham & Cheese Pizza", price = "279", imagePath = "..\\img\\Food\\Pizza\\hamandcheese.png",  Quantity=0},
            new Food() {Id="P4", foodName = "Veggies Pizza", price = "279", imagePath = "..\\img\\Food\\Pizza\\veggiespizza.png",  Quantity=0},
            new Food() {Id="P5", foodName = "Mixed Pizza", price = "319", imagePath = "..\\img\\Food\\Pizza\\mixedpizza.png",  Quantity=0}
        };

        public static ObservableCollection<Food> Drinks = new ObservableCollection<Food>()
        {
            new Food() {Id="D1", foodName = "Softdrinks", price = "22", imagePath = "..\\img\\Food\\Drinks\\softdrinks.png", Quantity=0},
            new Food() {Id="D2", foodName = "MuchFloat", price = "35", imagePath = "..\\img\\Food\\Drinks\\muchfloat.png",  Quantity=0},
            new Food() {Id="D3", foodName = "Master's Frappe", price = "47", imagePath = "..\\img\\Food\\Drinks\\mastersfrappe.png",  Quantity=0},
            new Food() {Id="D4", foodName = "Coffee Latte", price = "49", imagePath = "..\\img\\Food\\Drinks\\caffelatte.png",  Quantity=0},
            new Food() {Id="D5", foodName = "Affogato", price = "59", imagePath = "..\\img\\Food\\Drinks\\affogato.png",  Quantity=0}
        };

        public static ObservableCollection<Food> Desserts = new ObservableCollection<Food>()
        {
            new Food() {Id="DS1", foodName = "Cone Berry", price = "37", imagePath = "..\\img\\Food\\Desserts\\coneberry.png", Quantity=0},
            new Food() {Id="DS2", foodName = "Scoopy Berry", price = "43", imagePath = "..\\img\\Food\\Desserts\\scoopyberry.png",  Quantity=0},
            new Food() {Id="DS3", foodName = "SuperScoop", price = "52", imagePath = "..\\img\\Food\\Desserts\\superscoop.png",  Quantity=0},
            new Food() {Id="DS4", foodName = "Leche Flan", price = "39", imagePath = "..\\img\\Food\\Desserts\\lecheflan.png",  Quantity=0},
            new Food() {Id="DS5", foodName = "Ube Cake", price = "45", imagePath = "..\\img\\Food\\Desserts\\ubecake.png",  Quantity=0},
            new Food() {Id="DS6", foodName = "Halo-Halo", price = "49", imagePath = "..\\img\\Food\\Desserts\\halohalo.png",  Quantity=0}
        };

        public static ObservableCollection<Food> GetAlaCarte()
        {
            return AlaCarte;
        }

        public static ObservableCollection<Food> GetSides()
        {
            return Sides;
        }

        public static ObservableCollection<Food> GetSoloValue()
        {
            return SoloValue;
        }

        public static ObservableCollection<Food> GetMatchyCombo()
        {
            return MatchyCombo;
        }

        public static ObservableCollection<Food> GetPizza()
        {
            return Pizza;
        }

        public static ObservableCollection<Food> GetDrinks()
        {
            return Drinks;
        }

        public static ObservableCollection<Food> GetDesserts()
        {
            return Desserts;
        }
    }
}
