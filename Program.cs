using System;
using System.IO;
using System.Media;

//chatgpt was used to mange the code structure and to add the sound player as well as add color :"https://chatgpt.com"
//if function:"https://www.w3schools.com/cs/cs_conditions_elseif.php"

namespace CybersecurityAwarenessChatbot
{
    class Program
    {
        static void Main()
        {

            string filePath = @"C:\Users\suton\Desktop\st10448224 prog part 1\output.wav"; // audio was used from kokoro tts:"https://huggingface.co/spaces/hexgrad/Kokoro-TTS"

            if (File.Exists(filePath))
            {
                SoundPlayer player = new SoundPlayer(filePath);
                player.Play();
            }
            else
            {
                Console.WriteLine("\u001b[31mWarning: Voice file not found. Skipping sound playback.\u001b[0m"); // Print out the chat bot's text in red
            }

            Console.Title = "AchA - Cybersecurity Awareness Bot";

            // ASCII Art in red, ASCII art sources: "https://patorjk.com/software/taag/#p=display&f=ANSI%20Shadow&t=AchA" 
            Console.WriteLine("\u001b[31m");
            Console.WriteLine(@"
     █████╗  ██████╗██╗  ██╗ █████╗ 
    ██╔══██╗██╔════╝██║  ██║██╔══██╗
    ███████║██║     ███████║███████║
    ██╔══██║██║     ██╔══██║██╔══██║
    ██║  ██║╚██████╗██║  ██║██║  ██║
    ╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚═╝  ╚═╝  
        Welcome to AchA chatbot - Your Cybersecurity Awareness bot!
");
            Console.WriteLine("\u001b[0m");

            // Grabs the user's desktop username
            string desktopUsername = GetDesktopUsername();
            Console.WriteLine($"\u001b[31mChatbot: Hello, {desktopUsername}! I am AchA, your Cybersecurity Awareness Assistant.\u001b[0m");

            // Initial questions
            Console.WriteLine("\n\u001b[31mYou can ask me:\u001b[0m");
            Console.WriteLine("A. What is your purpose?");
            Console.WriteLine("B. How are you?");
            Console.WriteLine("C. What can I ask about?");
            Console.WriteLine();

            bool hasUnlockedCybersecurityTopics = false;// locks the user from asking questions about cybersecurity until they ask the chatbot what they can ask about. 

            while (true)
            {
                Console.Write("\u001b[32mYou: \u001b[0m"); // gives the User text in green for "you"
                string userInput = Console.ReadLine().ToLower().Trim();

                if (userInput == "exit")
                {
                    Console.WriteLine("\u001b[31mChatbot: Thank you for chatting! Stay safe online!\u001b[0m");
                    break;
                }

                if (!hasUnlockedCybersecurityTopics && (userInput == "c" || userInput.Contains("what can i ask")))
                {
                    hasUnlockedCybersecurityTopics = true;
                    Console.WriteLine("\n\u001b[31mChatbot: You can now ask me about the following cybersecurity topics:\u001b[0m");
                    Console.WriteLine("1. What is Phishing?");
                    Console.WriteLine("2. Tell me about Password safety.");
                    Console.WriteLine("3. How do I identify Suspicious links?");
                    Console.WriteLine("4. What is Malware?");
                    Console.WriteLine("5. What is Identity theft?");
                    Console.WriteLine("6. End the chat.");
                    Console.WriteLine();
                }

                RespondToUser(userInput, hasUnlockedCybersecurityTopics);
            }
        }

        static string GetDesktopUsername()
        {
            return Environment.UserName;
        }

        static void RespondToUser(string input, bool hasUnlockedCybersecurityTopics) //the "if" function allows the user to ask questions by their number or by their text give to the user  
        {
            if (input == "a" || input.Contains("your purpose") || input.Contains("what is your purpose"))
            {
                Console.WriteLine("\u001b[31mChatbot: My purpose is to help raise awareness about cybersecurity and keep you informed on how to stay safe online.\u001b[0m");
            }
            else if (input == "b" || input.Contains("how are you"))
            {
                Console.WriteLine("\u001b[31mChatbot: I'm just a bot, but I'm always ready to help you stay secure!\u001b[0m");
            }
            else if (input == "c" || input.Contains("what can i ask"))
            {
                Console.WriteLine("\u001b[31mChatbot: You can now ask me about phishing, password safety, suspicious links, malware, or identity theft.\u001b[0m");
            }
            else if (hasUnlockedCybersecurityTopics)
            {
                if (input == "1" || input.Contains("phishing"))
                {
                    Console.WriteLine("\u001b[31mChatbot: Phishing is a cyber attack where attackers impersonate legitimate organizations to steal sensitive information.\u001b[0m");
                }
                else if (input == "2" || input.Contains("password"))
                {
                    Console.WriteLine("\u001b[31mChatbot: It's important to use strong passwords. A good password should be at least 12 characters long and include a mix of letters, numbers, and symbols.\u001b[0m");
                }
                else if (input == "3" || input.Contains("link"))
                {
                    Console.WriteLine("\u001b[31mChatbot: Be cautious with links in emails or messages. Hover over the link to see the actual URL before clicking.\u001b[0m");
                }
                else if (input == "4" || input.Contains("malware"))
                {
                    Console.WriteLine("\u001b[31mChatbot: Malware is malicious software designed to harm your computer or steal information.\u001b[0m");
                }
                else if (input == "5" || input.Contains("identity theft"))
                {
                    Console.WriteLine("\u001b[31mChatbot: Identity theft occurs when someone uses your personal information without your permission.\u001b[0m");
                }
                else if (input == "6" || input.Contains("end the chat") || input.Contains("close"))
                {
                    Console.WriteLine("\u001b[31mChatbot: Thank you for chatting! Stay safe online!\u001b[0m");
                    Environment.Exit(0); // Close the console immediately
                }
                else
                {
                    Console.WriteLine("\u001b[31mChatbot: I'm sorry, I don't have information on that topic. Try asking about phishing, passwords, links, malware, or identity theft.\u001b[0m");
                }
            }
            else
            {
                Console.WriteLine("\u001b[31mChatbot: Please choose from the available options: A, B, or C.\u001b[0m");
            }
        }
    }
}

