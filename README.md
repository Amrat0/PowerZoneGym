# 🏋️ PowerZoneGym – Gym Trainee Information Management System

**PowerZoneGym** is a web-based **Gym Trainee Information Management System** developed using **ASP.NET Core MVC** and **SQL Server**.

The application helps gym owners and staff manage trainees, memberships, training levels, blood groups, monthly fees, fee vouchers, trainee photographs, and printable fee reports from a centralized system.

---

## 📸 Project Overview


PowerZoneGym provides a modern and user-friendly dashboard for managing daily gym operations.

### 🏠 Gym Management Dashboard

PowerZoneGym Dashboard
<img width="1366" height="601" alt="Screenshot (23)" src="https://github.com/user-attachments/assets/bba70738-3fd0-4646-b05d-e96a434b3cc3" />
<img width="1366" height="607" alt="Screenshot (24)" src="https://github.com/user-attachments/assets/3c67ccc7-f30e-4173-a94e-594b00595049" />
<img width="1366" height="612" alt="Screenshot (25)" src="https://github.com/user-attachments/assets/1c0872ae-3d0d-468f-8e95-e1ea952d5fdc" />


---

## ✨ Features

### 👤 Trainee Management

* Add new gym trainees
* Edit trainee information
* View complete trainee details
* Delete trainee records
* Upload and manage trainee profile images
* Store trainee contact information
* Record trainee creation date
* Assign blood groups
* Assign training levels
* Manage monthly trainee fees

### 💳 Fee Collection

* Monthly fee collection system
* Record trainee fee payments
* View paid and unpaid fees
* Search fee records by date
* Filter fee collection records
* Update existing fee vouchers
* Delete fee voucher records
* View complete payment details

### 🧾 RDLC Fee Reports

PowerZoneGym includes an integrated **RDLC reporting system** for generating printable gym fee reports.

The report includes:

* Trainee information
* Trainee photograph
* Monthly fee information
* Payment details
* Fee voucher information
* Printable report layout
* External trainee image support
* Report generation directly from the application

### 🖼️ Trainee Image Management

* Upload trainee photographs
* Store images inside `wwwroot/Images`
* Display trainee images in the application
* Display trainee photographs inside RDLC reports
* Support external images in generated reports

### 🔎 Search & Filtering

* Search trainees quickly
* Search fee records
* Filter paid fees
* Filter unpaid fees
* Filter records by date
* View all fee records

### 🎨 Modern User Interface

* Responsive Bootstrap-based design
* Modern navigation bar
* Font Awesome icons
* Dashboard-style interface
* Hover effects
* Responsive tables
* User-friendly forms
* Dark-mode interface support
* Modern gym-themed design

---

## 🧰 Technologies Used

### Backend

* **ASP.NET Core MVC**
* **C#**
* **Entity Framework Core**
* **LINQ**
* **.NET 10**

### Frontend

* **HTML5**
* **CSS3**
* **JavaScript**
* **Bootstrap**
* **Font Awesome**
* **Razor Views**

### Database

* **Microsoft SQL Server**
* **SQL Server Express**
* **SQL Server Management Studio (SSMS)**

### Reporting

* **RDLC Reports**
* **Microsoft.Reporting.NETCore**
* **ReportViewerCore.NETCore**

### Development Tools

* **Visual Studio Community**
* **Git**
* **GitHub**
* **SQL Server Management Studio**

---

## 🗄️ Database

PowerZoneGym uses **Microsoft SQL Server** as its database.

The application manages entities such as:

* Trainees
* Blood Groups
* Training Levels
* Monthly Fee Vouchers

Entity Framework Core is used for database communication and CRUD operations.

---

## 📊 RDLC Reporting

One of the main features of PowerZoneGym is the integrated **RDLC Fee Report**.

The report is generated from trainee and monthly fee information and can be printed as a professional fee voucher.

### 🧾 Fee Report

Gym Trainee Fee Report
<img width="1366" height="535" alt="Screenshot (37)" src="https://github.com/user-attachments/assets/13f708f4-57fb-45d9-82ae-33c59ad52301" />



The RDLC report supports:

* Dynamic trainee data
* Dynamic fee information
* Trainee profile image
* External image loading
* Printable fee voucher
* Professional report formatting

---

## 📂 Project Structure

```text
PowerZoneGym/
│
├── Controllers/
│   ├── HomeController.cs
│   ├── GymTraineeController.cs
│   ├── FeeVoucherController.cs
│   └── ReportController.cs
│
├── Models/
│   ├── GymTrainee.cs
│   ├── BloodGroup.cs
│   ├── TrainingLevel.cs
│   ├── MonthlyFeeVoucher.cs
│   └── ViewModels/
│
├── Data/
│   └── GymDbContext.cs
│
├── Views/
│   ├── Home/
│   ├── GymTrainee/
│   ├── FeeVoucher/
│   └── Shared/
│
├── wwwroot/
│   ├── css/
│   ├── js/
│   ├── Images/
│   └── Reports/
│       └── GymTrainee_FeeReport.rdlc
│
├── appsettings.json
├── Program.cs
└── PowerZoneGym.csproj
```

---

## 🔐 Application Security

The application uses ASP.NET Core security features including:

* Anti-forgery token protection
* Server-side validation
* Authentication/authorization structure
* Secure database access through Entity Framework Core
* Configuration through `appsettings.json`

---

## ⚙️ How to Run the Project

### 1. Clone the Repository

```bash
git clone https://github.com/YOUR-USERNAME/PowerZoneGym.git
```

### 2. Open the Project

Open the solution/project in **Visual Studio Community**.

### 3. Configure SQL Server

Update the connection string in:

```text
appsettings.json
```

Example:

```json
{
  "ConnectionStrings": {
    "ConStr": "Server=YOUR_SERVER;Database=PowerZoneGym;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

Replace `YOUR_SERVER` with your SQL Server instance.

### 4. Restore Dependencies

Visual Studio will restore the required NuGet packages automatically.

### 5. Create/Update the Database

If migrations are included in the project, run:

```powershell
Update-Database
```

### 6. Run the Application

Press:

```text
Ctrl + F5
```

or:

```text
F5
```

The application will open in your browser.

---

## 📋 Main Modules

| Module              | Description                            |
| ------------------- | -------------------------------------- |
| 👤 Trainees         | Manage gym trainee records             |
| 🩸 Blood Groups     | Manage trainee blood groups            |
| 🏋️ Training Levels | Manage different training levels       |
| 💰 Fee Collection   | Manage monthly trainee payments        |
| 📅 Fee Search       | Search payments by date                |
| 📊 Fee Status       | View paid and unpaid fees              |
| 🧾 RDLC Reports     | Generate printable fee reports         |
| 🖼️ Images          | Upload and display trainee photos      |
| 🔍 Search           | Quickly search trainee and fee records |

---

## 🖼️ Screenshots

### 👤 Trainee Management

![Trainee Management]<img width="1348" height="603" alt="Screenshot (26)" src="https://github.com/user-attachments/assets/5b821571-0a39-4e85-bc3a-9ddd7d872aaf" />


### 💰 Fee Collection

Fee Collection <img width="1348" height="603" alt="Screenshot (26)" src="https://github.com/user-attachments/assets/94d7308c-edfa-4683-8553-9ed8699aae4b" /> <img width="1351" height="605" alt="Screenshot (27)" src="https://github.com/user-attachments/assets/31890caa-af66-48b6-b89d-0940f086174d" />


### 🧾 RDLC Fee Voucher

RDLC Fee Voucher <img width="1366" height="535" alt="Screenshot (37)" src="https://github.com/user-attachments/assets/388f4dd7-9820-4988-bbd7-ea927f352c47" />

### 📱 Responsive Interface

PowerZoneGym Interface <img width="1350" height="608" alt="Screenshot (28)" src="https://github.com/user-attachments/assets/021e4f5c-0786-4b80-b976-d8203e9e3a6c" />


> Replace `YOUR-IMAGE-ID` with the image links generated by GitHub when you drag and drop your screenshots into the README editor.

---

## 🎯 Project Objectives

PowerZoneGym was developed to simplify common gym management tasks by replacing manual record keeping with a centralized digital system.

The system provides a single platform for:

* Managing trainee information
* Managing trainee photographs
* Tracking monthly fees
* Monitoring paid and unpaid payments
* Searching payment history
* Generating printable fee vouchers
* Maintaining organized gym records

---

## 🚀 Future Improvements

Possible future enhancements include:

* Online payment integration
* SMS notifications for fee reminders
* Email notifications
* Attendance management
* Membership expiry notifications
* Dashboard analytics
* Role-based user management
* Cloud deployment
* Automated database backup

---

## 👨‍💻 Developer

**Amrat**

Computer Science Developer

**Technologies:**
ASP.NET Core • C# • Entity Framework Core • SQL Server • React • JavaScript • AI Integration

---

## ⭐ Project

If you find this project useful, consider giving the repository a ⭐ on GitHub.

**PowerZoneGym – Gym Trainee Information Management System**
