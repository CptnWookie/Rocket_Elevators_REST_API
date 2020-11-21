<h1 align="center"> Rocket Elevators REST API </h1>

REST API using C # and .NET Core allow requesting Rocket Elevators systems to access and manipulate textual representations of web resources through a set of stateless, predefined uniform operations.

# API Endpoints

Below are described the REST endpoints available that you can use to connect Rocket Elevators information system to the equipment in operation throughout the territory served.

## Link to Postman collection

**[Postman collection](https://www.getpostman.com/collections/d5c693e95cd3789e0c5a)**

## Interventions

### All Pending Interventions

```html
https://rocketelevatorsfoundationrestapi.azurewebsites.net/api/Interventions/Status/Pending
```

### Changing the specific Pending Intervention status to "InProgress" and adding a timestamp to Start Intervention field the database

```html
https://rocketelevatorsfoundationrestapi.azurewebsites.net/api/Interventions/10/Init
```

### Changing the specific InProgress Intervention status to "Complete" and adding a timestamp to End Intervention field the database

```html
https://rocketelevatorsfoundationrestapi.azurewebsites.net/api/Interventions/{id}/End
```
<hr>


## Battery

### All

```html
https://rocketelevatorsrest-api.azurewebsites.net/api/Batteries
```

### Retrieving a specific Battery: Search by id.

```html
https://rocketelevatorsrest-api.azurewebsites.net/api/Batteries/{id}
```

### Retrieving the current status of a specific Battery

```html
https://rocketelevatorsrest-api.azurewebsites.net/api/Batteries/{id}/status
```

### Changing the status of a specific Battery (PUT request)

```html
https://rocketelevatorsrest-api.azurewebsites.net/api/Batteries/{id}/status
```

### Delete a specific Battery (Delete request)

```html
https://rocketelevatorsrest-api.azurewebsites.net/api/Batteries/{id}
```

<hr>

## Column

### All

```html
https://rocketelevatorsrest-api.azurewebsites.net/api/Columns/
```

### Retrieving a specific Column: Search by id.

```html
https://rocketelevatorsrest-api.azurewebsites.net/api/Columns/{id}
```

### Retrieving the current status of a specific Column

```html
https://rocketelevatorsrest-api.azurewebsites.net/api/Columns/{id}/status
```

### Changing the status of a specific Column (PUT request)

```html
https://rocketelevatorsrest-api.azurewebsites.net/api/Columns/{id}/status
```

### Delete a specific Battery (Delete request)

```html
https://rocketelevatorsrest-api.azurewebsites.net/api/Columns/{id}
```

<hr>

## Elevator

### All

```html
https://rocketelevatorsrest-api.azurewebsites.net/api/Elevators/
```

### Retrieving a specific Elevator: Search by id.

```html
https://rocketelevatorsrest-api.azurewebsites.net/api/Elevators/{id}
```

### Retrieving the current status of a specific Elevator

```html
https://rocketelevatorsrest-api.azurewebsites.net/api/Elevators/{id}/status
```

### Changing the status of a specific Elevator (PUT request)

```html
https://rocketelevatorsrest-api.azurewebsites.net/api/Elevators/{id}/status
```

### Retrieving a list of Elevators that are not in operation at the time of the request

```html
https://rocketelevatorsrest-api.azurewebsites.net/api/ElevatorsOff
```

### Delete a specific Elevator (Delete request)

```html
https://rocketelevatorsrest-api.azurewebsites.net/api/Elevators/{id}
```

<hr>

## Building

### Retrieving a list of Buildings that contain at least one battery, column or elevator requiring intervention

```html
https://rocketelevatorsrest-api.azurewebsites.net/api/BuildingsOff
```

<hr>

## Leads

### Retrieving a list of Leads created in the last 30 days who have not yet become customers.

```html
https://rocketelevatorsrest-api.azurewebsites.net/api/NotCostumers
```

<hr>

## Response Example

```html
https://rocketelevatorsrest-api.azurewebsites.net/api/Elevators/3
```

```json
[
	{
		"id": 3,
		"columnId": 1,
		"serialNumber": "000-86-8653",
		"elevatorModel": "Elevatroma",
		"elevatorType": "Commercial",
		"elevatorStatus": "Intervention",
		"dateOfCommissioning": "2018-07-13T00:00:00",
		"dateOfLastInspection": "2019-03-15T00:00:00",
		"certificateOfInspection": "General",
		"information": "Quos ullam sit vero aut voluptatem aut sunt.",
		"notes": "Quas nihil vitae praesentium porro eaque maxime.",
		"createdAt": "2018-11-26T17:41:43",
		"updatedAt": "2020-11-02T17:59:44"
	}
]
```

## :memo: License

- This project is under license from CodeBoxx.

Made with ❤️ in Quebec

&#xa0;

<a href="#top">Back to top</a>
