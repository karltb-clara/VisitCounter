# VisitCounter

This is a small project for testing database and application hosting on Azure.

## Local Setup

Begin by navigating to the project's root folder in the terminal.

### Apply Initial Migration

Run the below command to apply the initial migration, creating the database table.

```shell
$ dotnet ef database update
Build started...
Build succeeded.
...
```

### Run the Project

Once you have applied the initial migration, the project is ready to run.

Run the program with the below command.

```shell
$ dotnet run
Using launch settings from C:\Directory\With\Project
Building...
...
```


