## ToDO.API

This is the backend code for a ToDo App. The frontend can be accessed from https://github.com/syahmx/todo-spa.git.

## Development server

Run `dotnet run` for a dev server. API calls can be done to `http://localhost:5000/` according to the available controllers in
the scripts.

## Build

Run `dotnet publish -c Release` to build the project. The build artifacts will be stored in the `bin/` directory. It is recommended to
build the angular frontend into wwwroot folder for the application to work perfectly. Else, some API calls from the angular side needs
to be configured to request data from specified url.

The working application can be accessed at https://itodo.azurewebsites.net/.
