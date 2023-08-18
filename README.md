# Animal Shelter API

### By Allie Zhao

## Description

Code review assignment for Epicodus.
Simple C#/ASP.NET API built for use with a MySQL (or otherwise client-compatible) database.
Allows user to add, edit, and track rescue cats and dogs for an animal shelter.
Anyone can read from the API, but only authorized users may create, update, and delete rescue animals.

## Technologies Used

- C#
- ASP.NET
- Entity Framework Core
- MySQL (or other client-compatible RMDBS)

## Setup/Installation Requirements

### Step 1: Database setup

- set up a MySQL (or otherwise client protocol compatible) database instance
- create a new database `[your_db_name]`, using a name of your choice
    - to do this, enter `CREATE DATABASE [your_db_name];` in your DB shell
    - you may also use a GUI database tool like MySQL Workbench
- in the `AnimalShelterAPI` directory, create the file `appsettings.json`, containing the following

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=[your_database_address];Port=3306;database=[your_db_name];uid=[your_db_login];pwd=[your_db_password];"
  }
}
```

- substitute fields in square brackets with your own database information
- also change port value if your database is not configured to use 3306
- from the `AnimalShelterAPI` directory, apply the included database migration
    - the command for this is `dotnet ef database update`
    - ensure your database instance is running first

### Step 2: Launch API

- clone repository to location of your choice
- ensure .NET 6 SDK is installed and correctly configured
- ensure proper .NET dependencies are retrieved
    - this should happen automatically with `dotnet run`
- navigate to `AnimalShelterAPI` directory
- in your terminal, enter `dotnet run`

### Step 3: Query API

-

## API Documentation

These are the endpoints for the AnimalShelterAPI.
If desired, you may change the application's domain and port from `localhost:5000` to
something else in `AnimalShelterAPI/Properties/launchSettings.json`.
You will need to replace `localhost:5000` in all requests with your domain and port number if you do so.

### `Get`

#### `GET http://localhost:5000/api/Animals`

Retrieves the full list of animals, ordered by Id.

You may also optionally filter your request by appending one or more query strings in the form of `?{parameter1}={query1}&{parameter2}={query2}` to your request.
These parameters are listed below.
If no animals match your query, nothing will be returned.

| Parameter  | Type | Required? | Description|
|------------|------|-----------|------------|
|speciesFilter|string|no|Returns animals of a specific species only (canine, feline, etc.)|
|breedFilter|string|no|Returns animals of a specific breed only (Beagle, Sphynx, etc.)|
|minimumAgeFilter|int|no|Returns animals over this age only.|
|maximumAgeFilter|int|no|Returns animals under this age only.|
|adoptableFilter|boolean|no|Returns only animals available/unavailable for adoption.|

*Example:* `GET http://localhost:5000/api/Animals?speciesFilter=Canine&adoptableFilter=true` *will retrieve all dogs available to be adopted.*

#### `GET http://localhost:5000/api/Animals/{id}`

Retrieves a specific animal by its id, or a status of `404 Not Found` if no animal with that id exists.
*Example:* `GET http://localhost:5000/api/Animals/4` *would retrieve the animal with the id of 4.*

### `POST`

#### `POST http://localhost:5000/api/Animals`

Adds a new animal to the database.
You must include a body with all required properties (`name`(string), `species`(string), `description`(string), `age`(int), `adoptable`(bool))
with your request, plus any optional properties (`notes`(string), `breed`(string), `imageurl`(string)).
Do not include the animal's id.
For example:

```json
{
    "name": "Donkey",
    "Species": "Donkey",
    "description": "Donkey, like from Shrek.",
    "age": 45,
    "adoptable": "true"
}
```

### `PUT`

#### `PUT http://localhost:5000/api/Animals/{id}`

With the animal's `id` specified in th endpoint, updates the specified animal with new information.
Entirely replaces all old information with the submitted information, including NULLing any properties left blank.
If no animal with the specified id is found, returns status `404 Not Found`.

You must submit a body with your request like the following:
```json
{
    "rescueanimalid": {id},
    "name": "Donkey",
    "species": "Donkey",
    "notes": "What's his catchphrase again?",
    "breed": "Rude.",
    "imageurl": "image url here",
    "description": "Donkey, like from Shrek.",
    "age": 45,
    "adoptable": "true"
}
```
**The value of `id` from the endpoint must match the value of `rescueanimalid` specified in the request body.**

### `DELETE`

#### `DELETE http://localhost:5000/api/Animals/{id}`

Delete the animal with the specified `id`. Does not require a request body.
If no animal with the specified `id` exists, returns status `404`.

## Known Bugs

None yet! 

## License

MIT

Copyright (c) 2023 Allie Zhao
