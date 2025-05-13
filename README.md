# InvestApp - Islamic Investment Portfolio Manager

![InvestApp Screenshot](screenshot.png) <!-- Add a screenshot if available -->

InvestApp is a desktop application designed to help users manage their investment portfolios while ensuring compliance with Islamic finance principles (Halal screening, Zakat calculation).

## Features

- **User Authentication**: Secure login/signup system with validation.
- **Portfolio Management**: Add, remove, and track assets.
- **Halal Compliance Check**: Automatically screens assets for Sharia compliance.
- **Zakat Calculator**: Computes Zakat obligations (2.5% on eligible assets).
- **File-Based Storage**: Saves user data and portfolios locally.
- **Risk Assessment**: Classifies assets by risk level (Low/Medium/High).

## Technologies Used

- **Language**: C#
- **Framework**: .NET Windows Forms
- **Dependencies**: 
  - `System.Net.Mail` (Email validation)
  - File I/O (Data persistence)

## Installation

1. **Prerequisites**:
   - Windows OS
   - [.NET 6.0 Runtime](https://dotnet.microsoft.com/download) or later

2. **Steps**:
   ```bash
   git clone https://github.com/yourusername/InvestApp.git
   cd InvestApp
   Open `InvestApp.sln` in Visual Studio
   Build and Run (F5)
