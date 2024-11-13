# MiniProject
This is a website where you can buy and sell stuff, from and to others.

## How to run code local:
```
  1. Run code "git clone https://github.com/Mikkelrv/MiniProject.git" in terminal
  2. Add file in the root of ThriftShopAPI, called appsettings.json, with the code below
  3. Run ThriftShopAPI project, followed by ThriftShopApp. And follow the localhost link
```

### appsettings.json:
```
{
    "ConnectionStrings": {
        "mongoDB": "mongodb+srv://asgermunk:IwAY0aCDddwqBdeD@cluster0.33zur.mongodb.net/"
    },
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
        }
    },
    "AllowedHosts": "*"
}
```

## Code convention:
```
  1. Camelcase
  2. Underscore when private
  3. Language = English
  4. Readabillity > Efficiency
```

