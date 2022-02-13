# People API

## Getting started
> Install
> 
> > dotnet core 3.1 version


> Endpoints
- Health check
> Example:
> https://localhost:5001/health

- Get all the people (get request)
> Example:
> https://localhost:5001/people

- Adding people (post request)
> Example:
> https://localhost:5001/people
```
{
    "Id": 21
    "Name": "test",
    "Age": 10
}
```
- update people (put request)
> Example:
> https://localhost:5001/people
```
{
    "Id": 21
    "Name": "test",
    "Age": 10
}
```

- delete people by id (delete request)
> Example:
> https://localhost:5001/people/10

- search people by name (get request)
> Example:
> https://localhost:5001/people?name="test"

