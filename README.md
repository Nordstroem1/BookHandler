# 📚 BookAPI

BookAPI är ett RESTful API för att hantera böcker, där användare kan utföra CRUD-operationer på böcker. API:et är byggt med **Clean Architecture** och följer **CQRS-mönstret** genom **MediatR**. Autentisering sker med JWT-token, och datan hanteras med Entity Framework och MySQL.

## 🚀 Teknologier
- .NET 8  
- Entity Framework Core  
- MySQL  
- JWT Authentication  
- Clean Architecture  
- CQRS med MediatR  
- XUnit (Enhetstester)  

## ✨ Funktioner
- Skapa, läsa, uppdatera och ta bort böcker  
- Användarautentisering med JWT  
- Säkrade endpoints  
- Clean Architecture-struktur  
- CQRS för att separera kommandon och frågor  
- Enhetstester med XUnit  

## 🏗 Arkitektur  
Projektet är byggt enligt **Clean Architecture** med separata lager för:  
- **Domain** – Innehåller affärslogik och entiteter  
- **Application** – Innehåller CQRS-hantering med MediatR  
- **Infrastructure** – Hanterar databasåtkomst och externa integrationer  
- **Presentation** – Exponerar API:et via controllers  
