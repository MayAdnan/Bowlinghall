using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Bowlinghall
{
    public static class FileHandler
    {
        private static string filePath = "players.json"; 
        public static void SavePlayer(List<Player> players)
        {
            try
            {
                // Serialisera listan av spelare till JSON
                string json = JsonSerializer.Serialize(players, new JsonSerializerOptions { WriteIndented = true });

                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving players: {ex.Message}");
            }
        }
        public static List<Player> LoadPlayers()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);

                    // Deserialisera JSON till en lista av spelare
                    List<Player> players = JsonSerializer.Deserialize<List<Player>>(json);
                    return players ?? new List<Player>();
                }
                else
                {
                    Console.WriteLine("No saved players found.");
                    return new List<Player>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading players: {ex.Message}");
                return new List<Player>();
            }
        }
        public static void AddPlayer(Player newPlayer)
        {
            try
            {
                List<Player> players = LoadPlayers();
                players.Add(newPlayer);
                SavePlayer(players);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding player: {ex.Message}");
            }
        }
    }
}
