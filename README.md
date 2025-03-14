### 📌 **Appointment Scheduler - ASP.NET Core MVC Project**  

---

## 🚀 **Project Overview**
**Appointment Scheduler** is a web-based application designed to help **business professionals, employees, and officers** efficiently manage their daily meetings and appointments. This project is built using **ASP.NET Core MVC (8.0)** and follows **modern software design principles** such as **Separation of Concerns (SoC), SOLID, and Dependency Injection (IoC)**.

---

## 🎯 **Project Features**
### 🔹 **User Authentication & Authorization**
✅ Secure **User Registration & Login** using **ASP.NET Core Identity**  
✅ **Session & Cookie Management** for maintaining authentication  
✅ Prevents **unauthorized access** to appointment management pages  

### 🔹 **Appointment Management**
✅ **Create**, **Edit**, **Delete**, and **View** Appointments  
✅ Only logged-in users can manage their **own** appointments  
✅ Validation for **Title, Date, and Description** to prevent incorrect data  

### 🔹 **Dynamic Theming (Light & Dark Mode)**
✅ Users can **toggle between Light & Dark mode**  
✅ Theme selection is saved in **local storage** for a persistent user experience  

### 🔹 **Robust Data Management**
✅ Uses **Entity Framework Core (EF Core) - Code First Approach**  
✅ **SQL Server Database** with **Automatic Migrations**  
✅ Implements **Separation of Concerns (SoC)** for maintainability  

### 🔹 **Security & Session Handling**
✅ Implements **Session & Cookies** for user tracking  
✅ Enforces **Logout only via UI**, preventing unauthorized sign-outs  

### 🔹 **Validation & Error Handling**
✅ **Client-side validation** with **jQuery & Unobtrusive Validation**  
✅ **Server-side validation** for data integrity  
✅ **Validation summary** displays errors in forms  

---

## 📂 **Project Structure**
```
AppointmentScheduler/
│── Controllers/              # MVC Controllers (Account, Appointment)
│── Views/                    # Razor Views (Login, Register, Appointments, Edit, Delete)
│── Models/                   # Database Models (User, Appointment)
│── ViewModels/               # Data Transfer Models for Forms
│── Filters/                  # Custom Action Filters (Logging, Validation)
│── Data/                     # Database Context & Seed Data
│── wwwroot/css/              # Theme CSS (light.css, dark.css)
│── wwwroot/js/               # JavaScript for Client-side Validation
│── appsettings.json          # Database Configuration
│── Program.cs                # ASP.NET Core Application Entry Point
```

---

## 🛠️ **Technologies Used**
- **Frontend:** Bootstrap 5, Razor Pages, jQuery  
- **Backend:** ASP.NET Core MVC 8.0, C#  
- **Database:** SQL Server with Entity Framework Core  
- **Authentication:** ASP.NET Core Identity  
- **Design Patterns:** SOLID, Dependency Injection (IoC)  

---

## 📥 **Installation & Setup**
### 🔹 **1. Clone the Repository**
```bash
git clone https://github.com/your-username/appointment-scheduler.git
cd appointment-scheduler
```

### 🔹 **2. Configure Database**
1. **Open `appsettings.json`** and set your SQL Server connection string:
```json
"ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=AppointmentDB;Trusted_Connection=True;"
}
```
2. **Run Migrations & Update Database**
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 🔹 **3. Run the Application**
```bash
dotnet run
```
🚀 Open **`http://localhost:5000`** in your browser.

---

## 🎯 **How to Use**
1. **Register a new account** or **login** with existing credentials.  
2. Manage **appointments**:
   - Click **"New Appointment"** to create one.
   - Click **"Edit"** to modify an existing appointment.
   - Click **"Delete"** to remove an appointment.
3. Toggle between **Light Mode / Dark Mode**.  
4. Click **"Logout"** to securely exit the system.  

---

## 🛡️ **Security Features**
- **Session-Based Authentication** to prevent unauthorized access.    
- **Hashed Passwords & Identity Protection** via **ASP.NET Identity**.  

---

## 🛠️ **Future Enhancements**
✅ **Email Notifications for Appointments**  
✅ **Admin Panel for Managing Users**  
✅ **Google Calendar Integration**  
✅ **Multi-Language Support**  


---

### 🎯 **Final Notes**
✅ **Fully functional Appointment Scheduler** with authentication, validation, and UI themes.  
✅ **Built using ASP.NET Core 8.0, EF Core, and Bootstrap 5**.  
✅ **Secure, scalable, and follows best coding practices**.  



