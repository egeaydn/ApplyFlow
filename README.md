<div align="center">
  <img src="https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET 8.0"/>
  <img src="https://img.shields.io/badge/ASP.NET_Core-MVC-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt="ASP.NET Core MVC"/>
  <img src="https://img.shields.io/badge/Tailwind_CSS-38B2AC?style=for-the-badge&logo=tailwind-css&logoColor=white" alt="Tailwind CSS"/>
  <img src="https://img.shields.io/badge/Alpine.js-8BC0D0?style=for-the-badge&logo=alpine.js&logoColor=black" alt="Alpine.js"/>
  <img src="https://img.shields.io/badge/Entity_Framework_Core-512BD4?style=for-the-badge&logo=microsoft&logoColor=white" alt="EF Core"/>
  <img src="https://img.shields.io/badge/Identity-Authentication-green?style=for-the-badge" alt="Identity"/>
</div>

<h1 align="center">
  <br>
  🚀 ApplyFlow
  <br>
</h1>

<h4 align="center">A modern, enterprise-grade job application tracking system built with <a href="https://dotnet.microsoft.com/" target="_blank">.NET 8.0</a></h4>

<p align="center">
  <a href="#-key-features">Key Features</a> •
  <a href="#-tech-stack">Tech Stack</a> •
  <a href="#-getting-started">Getting Started</a> •
  <a href="#-project-structure">Project Structure</a> •
  <a href="#-screenshots">Screenshots</a> •
  <a href="#-contributing">Contributing</a> •
  <a href="#-license">License</a>
</p>

<div align="center">
  <img src="https://img.shields.io/badge/Status-Active-success?style=flat-square" alt="Status"/>
  <img src="https://img.shields.io/badge/Maintained-Yes-success?style=flat-square" alt="Maintained"/>
  <img src="https://img.shields.io/badge/PRs-Welcome-brightgreen?style=flat-square" alt="PRs Welcome"/>
</div>

<br>

---

## 📋 Overview

**ApplyFlow** is a comprehensive job application management system designed to streamline the job search process. Built with modern .NET 8.0 and ASP.NET Core MVC, it provides a beautiful, responsive interface powered by Tailwind CSS and Alpine.js, enabling users to track, organize, and manage their job applications efficiently.

Whether you're actively job hunting or managing multiple applications, ApplyFlow helps you stay organized with an intuitive interface and powerful features.

## ✨ Key Features

### 🔐 **Authentication & Security**
- **ASP.NET Core Identity** integration for secure user authentication
- User registration with email validation
- Secure login with "Remember Me" functionality
- Password hashing and secure credential storage

### 📊 **Application Management**
- **Create, Read, Update, Delete (CRUD)** operations for job applications
- Track multiple job applications in one centralized location
- Store comprehensive application details:
  - Company name
  - Position title
  - Application status (Applied, Interview, Offered, Rejected)
  - Applied date
  - Job posting URL
  - Personal notes and comments

### 🎨 **Modern UI/UX**
- **Responsive Design** - Works seamlessly on desktop, tablet, and mobile devices
- **Tailwind CSS** - Modern utility-first CSS framework
- **Alpine.js** - Lightweight JavaScript framework for interactive components
- Smooth animations and transitions
- Beautiful gradient effects and modern card designs
- Status badges with color coding
- Empty states with helpful prompts

### 📱 **Responsive Views**
- **Desktop View** - Full-featured table with comprehensive information
- **Mobile View** - Card-based layout optimized for smaller screens
- Adaptive navigation with hamburger menu
- Touch-friendly interface elements

### 🎯 **User Experience**
- Intuitive navigation and user flow
- Confirmation dialogs for destructive actions
- Form validation with clear error messages
- Loading states and visual feedback
- Search and filter capabilities (Coming Soon)
- Dashboard analytics (Coming Soon)

## 🛠️ Tech Stack

### **Backend**
- **Framework**: .NET 8.0
- **Web Framework**: ASP.NET Core MVC
- **ORM**: Entity Framework Core
- **Database**: SQL Server (configurable for other providers)
- **Authentication**: ASP.NET Core Identity

### **Frontend**
- **CSS Framework**: Tailwind CSS 3.x
- **JavaScript**: Alpine.js 3.x
- **View Engine**: Razor Pages
- **Icons**: Heroicons (SVG)

### **Development Tools**
- **IDE**: Visual Studio 2022 / Visual Studio Code
- **Version Control**: Git
- **Package Manager**: NuGet
- **Build System**: MSBuild

## 🚀 Getting Started

### Prerequisites

Before you begin, ensure you have the following installed:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads) (LocalDB, Express, or full version)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)
- [Node.js](https://nodejs.org/) (for Tailwind CSS, optional if using CDN)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/ApplyFlow.git
   cd ApplyFlow
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Update database connection string**
   
   Edit `appsettings.json` and configure your connection string:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ApplyFlowDb;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
   }
   ```

4. **Apply database migrations**
   ```bash
   dotnet ef database update
   ```

5. **Run the application**
   ```bash
   dotnet run
   ```

6. **Open your browser**
   
   Navigate to `https://localhost:5001` or `http://localhost:5000`

### Quick Setup with Visual Studio

1. Open `ApplyFlow.slnx` in Visual Studio 2022
2. Press `F5` to build and run
3. The browser will automatically open to the application

## 📁 Project Structure

```
ApplyFlow/
├── 📂 Controllers/           # MVC Controllers
│   ├── AuthController.cs          # Authentication logic
│   ├── HomeController.cs          # Home page
│   └── JobApplicationsController.cs   # CRUD operations
│
├── 📂 Models/               # Data models
│   └── JobApplication.cs          # Job application entity
│
├── 📂 ViewModel/            # View models for forms
│   ├── LoginViewModel.cs
│   └── RegisterViewModel.cs
│
├── 📂 Views/                # Razor views
│   ├── 📂 Auth/
│   │   ├── Login.cshtml
│   │   └── Register.cshtml
│   ├── 📂 Home/
│   │   └── Index.cshtml
│   ├── 📂 JobApplications/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   ├── Details.cshtml
│   │   └── Delete.cshtml
│   └── 📂 Shared/
│       └── _Layout.cshtml
│
├── 📂 Identity/             # Identity & Database Context
│   ├── ApplicationUser.cs
│   ├── ApplicationIdentityDbContext.cs
│   └── AppDbContext.cs
│
├── 📂 Migrations/           # EF Core migrations
│
├── 📂 Enums/               # Enumerations
│   └── ApplicationStatus.cs
│
├── 📂 wwwroot/             # Static files
│   ├── 📂 css/
│   ├── 📂 js/
│   └── 📂 lib/
│
├── Program.cs              # Application entry point
├── appsettings.json        # Configuration
└── tailwind.config.js      # Tailwind configuration
```

## 🎨 Color Scheme

ApplyFlow uses a professional blue color palette:

```javascript
primary: {
  50: '#eff6ff',
  100: '#dbeafe',
  200: '#bfdbfe',
  300: '#93c5fd',
  400: '#60a5fa',
  500: '#3b82f6',  // Primary brand color
  600: '#2563eb',
  700: '#1d4ed8',
  800: '#1e40af',
  900: '#1e3a8a',
}
```

## 📸 Screenshots

### Home Page
Modern landing page with gradient effects and clear call-to-action buttons.

### Dashboard
Comprehensive application tracking with status indicators and quick actions.

### Application Forms
Intuitive forms with inline validation and helpful tooltips.

### Mobile View
Fully responsive design optimized for mobile devices.

## 🔒 Security Features

- **Password Hashing**: Secure password storage using ASP.NET Core Identity
- **Authentication**: Token-based authentication
- **Authorization**: Role-based access control ready
- **SQL Injection Prevention**: Parameterized queries via Entity Framework
- **XSS Protection**: Razor automatic encoding
- **CSRF Protection**: Anti-forgery tokens on forms

## 🧪 Testing

```bash
# Run unit tests
dotnet test

# Run with coverage
dotnet test /p:CollectCoverage=true
```

## 📦 Database Schema

### JobApplication Table
| Column | Type | Description |
|--------|------|-------------|
| Id | int | Primary key |
| UserId | string | Foreign key to AspNetUsers |
| CompanyName | string | Company name |
| Position | string | Job position |
| Status | enum | Application status |
| AppliedDate | DateTime | Application date |
| JobLink | string | URL to job posting |
| Notes | string | User notes |

## 🎯 Roadmap

- [x] Core CRUD functionality
- [x] User authentication
- [x] Modern UI with Tailwind CSS
- [x] Responsive design
- [ ] Dashboard with analytics
- [ ] Application status timeline
- [ ] Email notifications
- [ ] Document upload (CV, cover letter)
- [ ] Calendar integration
- [ ] Export to PDF/Excel
- [ ] Search and advanced filtering
- [ ] Dark mode support
- [ ] Multi-language support

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the project
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📝 Code of Conduct

Please read our [Code of Conduct](CODE_OF_CONDUCT.md) before contributing.

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE.txt) file for details.

## 👨‍💻 Author

**Your Name**
- GitHub: [@yourusername](https://github.com/yourusername)
- LinkedIn: [Your Name](https://linkedin.com/in/yourprofile)

## 🙏 Acknowledgments

- [.NET Team](https://github.com/dotnet) for the amazing framework
- [Tailwind CSS](https://tailwindcss.com/) for the utility-first CSS framework
- [Alpine.js](https://alpinejs.dev/) for lightweight JavaScript
- [Heroicons](https://heroicons.com/) for beautiful SVG icons

## 📞 Support

If you have any questions or need help, please:

- Open an [issue](https://github.com/yourusername/ApplyFlow/issues)
- Send an email to support@applyflow.com
- Join our [Discord community](https://discord.gg/applyflow)

---

<div align="center">
  <p>Made with ❤️ and .NET</p>
  <p>⭐ Star this repository if you find it helpful!</p>
</div>