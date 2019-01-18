![picture alt](https://upload.wikimedia.org/wikipedia/commons/c/c0/Clapperboard_Icon.png)

# Search Movies From IMDb

A C# Windows Forms application for searching movies from IMDb using OMDb API(RESTful web service).

You can perform all CRUD operations with movies(Add to watchlist,show movie details,change movie status or delete the movie), filter movie by status(Watched/Not watched) and filter by movie title.

Other options:

* You can make excel file with all movies in your watchlist and send by e-mail to friend.Also you can load someone's watchlist.

* You can send movie details from watchlist to friend's WhatsApp(using WhatsApp API).

* You can see top 100 IMDb movies with options to show movie details and add them to your watchlist.

* You can watch movie trailer

* There is option for movie recommendation (Recommend movie randomly from [excel file](https://github.com/LukaJo/MoviesFromImdb/blob/master/movies.xls) based on movie you searched for,to be concrete based on movie genre of movie you searched for and if u like recommendation you can save movie to your watchlist).

* Also you can copy watchlist to clipboard and print it if you like.

## Installation

Clone from Git 

1. In Team Explorer, go to Manage Connections then open the Connect view.
2. Select Clone under Local Git Repositories and enter the URL for your Git repo

```bash
https://github.com/LukaJo/MoviesFromImdb
```

3. Select a folder where you want your cloned repo to be kept.
4. Select Clone to clone the repo.

## Note

You need to generate API key from [OMDb API(The Open Movie Database)](http://www.omdbapi.com/) and replace in project.

Also you need to replace phone number(for sending to WhatsApp),email and email password(for sending email to friend),paths on your computer(to find generated excel file and for top100.json file located [here](https://github.com/LukaJo/MoviesFromImdb/blob/master/MoviesFromImdb/top100.json)) and connection string in App.config(to connect to your database).

Database with table and stored procedures are given [here](https://github.com/LukaJo/MoviesFromImdb/blob/master/Imdbscript.sql).You can select all and import in your database.

## Motivation

I love to watch movies so i decide to make an application. :)

## Development
This app is developed in C# with Visual Studio Community 2017 and SQL Server 2014.

## API Reference
[OMDb API(The Open Movie Database)](http://www.omdbapi.com/) is used in this application.
The OMDb API is a RESTful web service to obtain movie information, all content and images on the site are contributed and maintained by our users.

## Author
[Luka Jovic](https://www.linkedin.com/in/lukajovic/)

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
This project is licensed under the [MIT License](https://choosealicense.com/licenses/mit/)
