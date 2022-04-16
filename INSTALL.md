## Clone and install dependencies

```bash
# Clone repository
$ git clone https://github.com/gabimariz/IBank.git

# Open project folder
$ cd IBank

# Install dotnet-ef global
$ dotnet tool install --global dotnet-ef

# Use package manager dotnet to restore packages
$ dotnet restore
```

## Setting up database connection

```C#
/*
	Open Infra/Data/AppDbContext.cs to configure the mariadb database edit USERNAME, PASSWORD 
	data and mariadb o mysql version
*/

options.UseMySql("server=localhost;username=USERNAME;password=PASSWORD;database=url_shortener",
	// Edit Major, Minor and Path version database
	new MariaDbServerVersion(new Version(MAJOR, MINOR, PATH)));
```

### Generating the migrations
```bash

# Open Infra folder and
# Manage the database
$ dotnet ef database update
```
Database backup with some registered users for testing.Database backup with some users registered for testing in the folder "Infra/Data/db" all users have a default password "string".

### Running application
```bash
# Run project
$ cd ../Application

$dotnet run
```

Open the browser at the url https://localhost:5000/swagger to view endpoint documentation.
