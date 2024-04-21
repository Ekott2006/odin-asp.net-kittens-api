# Project: Kittens API (ASP.NET)

This project implements a kittens application similar to the Ruby on Rails version covered in The Odin Project's [curriculum](https://www.theodinproject.com/lessons/ruby-on-rails-kittens-api). Here, we'll achieve the same functionality using ASP.NET Core, Entity Framework Core (EF Core), and PostgreSQL.

## Prerequisites:

- **.NET Core SDK:** Ensure you have the .NET Core SDK installed that matches your target framework version (e.g., .NET 8.0). Verify the installation by running `dotnet --version` in CMD. If not installed, download it from [official website](https://dotnet.microsoft.com/en-us/download).
- **PostgreSQL:** Install PostgreSQL from the [official download page](https://www.postgresql.org/download/). Create a database and user with the username `postgres` and password `postgres`.
- **Git:** Download and install Git from [official download page](https://git-scm.com/downloads). Verify installation by running `git --version` in CMD.

## Steps:

1. **Clone the Repository:**
    - Open CMD and navigate to the desired directory where you want to clone the repository.
    - 
   ```bash
   git clone https://github.com/Ekott2006/odin-asp.net-kittens-api.git
   ```

   This will clone the repository into a new folder named `odin-asp.net-kittens-api`.

2. **Navigate to Project Directory:**
    - Change directory into the cloned repository:

   ```bash
   cd odin-asp.net-kittens-api/WebApp
   ```

3. **Install Packages:**
    - Restore the NuGet packages defined in the project:

   ```bash
   dotnet restore
   ```

4. **Run Migrations:**
    - Run this command to create and apply the initial migration:

   ```bash
   dotnet ef database update
   ```

5. **Run the Application:**
    - Execute the following command to build and launch the application:

   ```bash
   dotnet run
   ```

The application should start and be accessible in your default web browser, typically at `http://localhost:5196`
