# AIPS Portal - School Management System

AIPS Portal is a comprehensive desktop application built with C# (Windows Forms) and MongoDB, designed to digitalize and streamline school operations. From managing student and teacher records to automating result card generation and broadcasting announcements, AIPS Portal provides an all-in-one solution for school administration.

## Key Features

* **Student & Teacher Management**: Easily maintain, add, and update records for both students and faculty members.
* **Admissions Module**: Secure and streamlined admission forms to enroll new students into the system.
* **Attendance Tracking**: Efficiently track daily attendance for students across all classes and sections.
* **Result Card Generation**: Automatically generate and export student and teacher result cards in both PDF (via iTextSharp) and PNG formats.
* **Automated WhatsApp Notifications**: Built-in integration with the Twilio API to broadcast news, announcements, and alerts directly to students' WhatsApp numbers.
* **News Announcer**: A dedicated dashboard module to publish school news dynamically, storing content securely on MongoDB.

## Tech Stack

* **Frontend/UI:** C# Windows Forms (.NET)
* **Database:** MongoDB (MongoDB Atlas cloud integration via MongoDB.Driver)
* **APIs & Libraries:** 
  * Twilio API - For WhatsApp messaging & notifications.
  * iTextSharp - For generating PDF result cards.

## Getting Started

1. Clone the repository: `git clone https://github.com/your-username/aips-portal.git`
2. Open the [.sln](cci:7://file:///c:/AIPS%20Portal/AIPS%20Portal.sln:0:0-0:0) file in Visual Studio.
3. Restore NuGet packages (MongoDB.Driver, Twilio, iTextSharp).
4. Build and Run the application. 
*(Note: Ensure you have updated the Twilio credentials and MongoDB connection strings before running.)*
