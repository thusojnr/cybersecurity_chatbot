using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Media;
using System.Text.RegularExpressions;
using System.Threading;

namespace cybersecurity_chatbot
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Play voice greeting when the program starts
            PlayVoice();

            // Display an ASCII representation of the cybersecurity logo
            DisplayImage();

            // Prompt the user for their name and greet them
            string userName = GetUserName();
            DisplayWelcomeMessage(userName);

            // Chatbot's initial prompt
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Chatbot >> ");
            Console.ResetColor();
            TypeText($"What can I help with, {userName}?", 30);
            Console.ResetColor();

            // Start the chatbot conversation
            StartChat(userName);
        }

        /// <summary>
        /// Plays a voice greeting from an audio file.
        /// </summary>
        static void PlayVoice()
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            // Construct the relative path to the audio file
            string relativePath = Path.Combine("Audio", "welcome.wav");
            string audioPath = Path.GetFullPath(Path.Combine(basePath, relativePath));

            if (File.Exists(audioPath))
            {
                using (SoundPlayer player = new SoundPlayer(audioPath))
                {
                    // Load and play the audio file synchronously
                    player.Load();
                    player.PlaySync();
                }
            }
            else
            {
                // Display error if the audio file is not found
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: Audio file not found at: {audioPath}");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Displays an ASCII representation of an image.
        /// </summary>
        static void DisplayImage()
        {
            // Display a message indicating we are showing the image
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nDisplaying Cybersecurity Logo\n");
            Console.ResetColor();

            var imageBasePath = AppDomain.CurrentDomain.BaseDirectory;
            // Construct the relative path to the image
            string imageRelativePath = Path.Combine("Images", "cybersecurity.png");
            string imagePath = Path.GetFullPath(Path.Combine(imageBasePath, imageRelativePath));

            try
            {
                // Load the image and resize it to a smaller size for display
                Bitmap image = new Bitmap(imagePath);
                image = new Bitmap(image, new Size(80, 45));

                // Loop through each pixel in the image to convert it to an ASCII character
                for (int height = 0; height < image.Height; height++)
                {
                    for (int width = 0; width < image.Width; width++)
                    {
                        Color pixelColor = image.GetPixel(width, height);
                        int gray = (pixelColor.R + pixelColor.G + pixelColor.B) / 3; // Convert pixel to grayscale
                        char asciiChar = gray > 200 ? '*' : gray > 150 ? '#' : '@'; // Choose an ASCII character based on brightness
                        Console.Write(asciiChar);
                    }
                    Console.WriteLine(); // New line for each row of pixels
                }
            }
            catch (Exception error)
            {
                // Handle errors if the image cannot be loaded
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {error.Message}");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Gets and validates the user's name (only letters allowed).
        /// </summary>
        static string GetUserName()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\nEnter your name: ");
            Console.ResetColor();

            string userName = Console.ReadLine();

            // Loop until a valid name (letters only) is entered
            while (string.IsNullOrWhiteSpace(userName) || !Regex.IsMatch(userName, @"^[a-zA-Z]+$"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Invalid input! Name must contain only letters. Try again: ");
                Console.ResetColor();
                userName = Console.ReadLine();
            }
            return userName;
        }

        /// <summary>
        /// Displays a welcome message to the user.
        /// </summary>
        static void DisplayWelcomeMessage(string userName)
        {
            // Display a personalized welcome message
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n==========================================================================");
            Console.WriteLine($"Welcome, {userName}! You are now chatting with the Cybersecurity Awareness Bot.");
            Console.WriteLine("I am here to help you stay safe online and provide cybersecurity advice.");
            Console.WriteLine("==========================================================================\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Simulates a typing effect when displaying text.
        /// </summary>
        static void TypeText(string text, int delay = 50)
        {
            // Simulate typing one character at a time with a delay between characters
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine(); // Move to the next line after finishing the text
        }

        /// <summary>
        /// Starts the chatbot conversation with the user.
        /// </summary>
        static void StartChat(string userName)
        {
            // Define a dictionary of common responses to user input
            Dictionary<string, string> responses = new Dictionary<string, string>
            {
                { "how are you", "I'm just a bot, {userName}, but I'm here to help you stay safe online!" },
                { "help", "I can explain: Passwords, 2FA, social engineering, ransomeware, data breach, phishing, safe browsing, VPNs, malware." },
                { "purpose", "My purpose is to educate you about cybersecurity and help you stay safe online." },
                { "password", "A strong password should be at least 12 characters long, with a mix of letters, numbers, and symbols." },
                { "2fa", "Two-factor authentication adds an extra layer of security by requiring a second form of verification." },
                { "two-factor authentication", "Two-factor authentication adds an extra layer of security by requiring a second form of verification." },
                { "social engineering", "Be cautious of unsolicited messages asking for personal information. Scammers often use social engineering tactics." },
                { "ransomware", "Ransomware is a type of malware that encrypts your files and demands payment for the decryption key." },
                { "data breach", "A data breach occurs when unauthorized individuals gain access to sensitive information." },
                { "phishing", "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organizations." },
                { "safe browsing", "Always check for 'https://' in the URL and avoid clicking on suspicious links." },
                { "vpn", "A VPN encrypts your internet traffic, making it safer from hackers." },
                { "malware", "Malware is intrusive software created by cybercriminals to steal data and damage systems." }
            };

            // Display prompt to start the conversation
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Chatbot >> ");
            Console.ResetColor();
            TypeText("Type 'help' for topics or 'exit' to quit.", 30);
            Console.ResetColor();

            // Infinite loop for the chatbot conversation
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{userName} >> ");
                Console.ResetColor();

                // Get and process user input
                string userInput = Console.ReadLine()?.Trim().ToLower();

                // Handle empty or invalid input
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Chatbot >> ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    TypeText($"Hmm, I didn’t quite understand that, {userName}. Could you rephrase?", 30);
                    continue;
                }

                // Exit the conversation if the user types 'exit'
                if (userInput == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Chatbot >> ");
                    Console.ResetColor();
                    TypeText($"Goodbye, {userName}! Stay safe online!", 30);
                    break;
                }

                List<string> matchedResponses = new List<string>();

                // Check if user input matches any predefined responses
                foreach (var entry in responses)
                {
                    if (userInput.Contains(entry.Key))
                    {
                        string response = entry.Value.Replace("{userName}", userName);
                        matchedResponses.Add(response);
                    }
                }

                // Display matched responses or prompt for cybersecurity-related questions
                if (matchedResponses.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Chatbot >> ");
                    Console.ResetColor();

                    foreach (string response in matchedResponses)
                    {
                        TypeText($"{response}", 30);
                    }
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Chatbot >> ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    TypeText($"{userName}, I didn’t quite understand that. Please ask cybersecurity-related questions.", 30);
                    Console.ResetColor();
                }
            }
        }
    }
}
