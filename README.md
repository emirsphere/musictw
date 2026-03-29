# 🎵 MusicTW - Music-Oriented Social Network (Under Refactoring)

**Status:** 🚧 Active Development & Modernization

## 📌 About the Project
MusicTW is a social network project for music lovers, which I started during my early days of software development. Initially, I built it as a Windows Forms desktop application using an N-Tier architecture just to get a working product.

However, in line with my current engineering vision, I am actively refactoring this project. The goal is to migrate it from a legacy desktop app into a scalable **RESTful API** adhering to **Clean Architecture** principles.

## ⚙️ Current Tech Stack & Architecture
Currently, the core database architecture and business logic layers (BLL & DAL) are decoupled:
* **Language:** C#
* **Presentation Layer:** Windows Forms (To be completely deprecated and replaced by a Web API soon)
* **Data Access & ORM:** Entity Framework 6 (EF)
* **Database:** MS SQL Server / T-SQL
* **Architecture:** N-Tier (Data Access, Business Logic, Presentation)

## 🚀 Refactoring Roadmap
My plan to transition this project from its initial state to enterprise standards:

- [x] Design relational database tables (Users, Posts) using T-SQL.
- [x] Isolate DAL (Data Access Layer) and BLL (Business Logic Layer) using EF.
- [ ] **Deprecate the desktop dependency and migrate to ASP.NET Core Web API.**
- [ ] Integrate Clean Architecture and Repository/Unit of Work patterns.
- [ ] Implement JWT (JSON Web Token) for secure authentication.
- [ ] Refactor dependencies to be loosely coupled (Dependency Injection).

## 💡 Developer Note
This isn't my "perfect" code; it's my personal sandbox where I learn software architecture, database management, and how a system evolves. I am using this project to practice migrating a tightly-coupled structure into a modern, reliable backend system.
