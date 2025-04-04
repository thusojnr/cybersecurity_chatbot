# Cybersecurity Chatbot

## Overview

This is a cybersecurity chatbot application built in C# designed to help users understand and stay safe online. It provides interactive responses to questions related to cybersecurity topics, including passwords, phishing, malware, and more. The chatbot uses various features, such as voice greetings, ASCII art for displaying an image, and simulated typing effects to enhance the user experience.

## Features

- **Voice Greeting**: When the program starts, it plays a voice greeting to welcome the user.
- **ASCII Art Image**: Displays an ASCII art representation of the cybersecurity logo when the program begins.
- **User Interaction**: Prompts the user for their name and provides a personalized welcome message.
- **Interactive Chatbot**: The chatbot can answer questions about cybersecurity and provide tips on safe online practices. It responds to specific keywords like "password", "2fa", "phishing", etc.
- **Typing Simulation**: The chatbot simulates typing responses, making the interaction feel more realistic.
- **Exit Option**: Users can exit the conversation by typing 'exit'.

## Requirements

- **.NET Framework**: This project requires the .NET framework to run on your local machine.
- **Audio File**: A WAV file (e.g., `welcome.wav`) for the voice greeting. Ensure this file exists in the `Audio` folder.
- **Image File**: A PNG file (e.g., `cybersecurity.png`) for the ASCII logo. Ensure this image exists in the `Images` folder.

## Setup

### Step 1: Clone the repository

```bash
git clone https://github.com/thusojnr/cybersecurity-chatbot.git
```

### Step 2: Open the project in Visual Studio

Open the solution file (`CybersecurityChatbot.sln`) in Visual Studio.

### Step 3: Ensure required files are in place

Ensure the following files are present in the correct directories:

- `Audio/welcome.wav`: The voice greeting file.
- `Images/cybersecurity.png`: The image for the ASCII art.

### Step 4: Build and Run

1. Build the project in Visual Studio (`Ctrl + Shift + B`).
2. Run the program (`Ctrl + F5`).

The chatbot will start, greeting the user with a voice message, showing the cybersecurity logo as ASCII art, and then prompt the user for their name.

## Usage

1. Upon starting, the program will greet you with a voice and display an ASCII representation of the cybersecurity logo.
2. Enter your name when prompted. The chatbot will greet you by name.
3. You can ask the chatbot questions related to cybersecurity. For example, you can ask:
    - "What is 2FA?"
    - "How can I create a strong password?"
    - "Tell me about phishing."
4. Type `help` to get a list of common topics the chatbot can discuss.
5. Type `exit` to end the conversation.

## Sample Interaction

```
Cybersecurity Chatbot
=============================

Welcome, Alice! You are now chatting with the Cybersecurity Awareness Bot.
I am here to help you stay safe online and provide cybersecurity advice.

Chatbot >> What can I help with, Alice?

Alice >> What is 2FA?

Chatbot >> Two-factor authentication adds an extra layer of security by requiring a second form of verification.
```

## Error Handling

- If the program cannot find the audio or image files, it will display an error message in the console.
- If invalid input is entered for the user's name (e.g., containing numbers or special characters), the program will ask the user to try again until a valid name is entered.
- If the chatbot does not understand the user's input, it will ask the user to rephrase or ask cybersecurity-related questions.

---
