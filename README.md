<h1 align="center"> Rocket Elevators REST API </h1>

REST API using C # and .NET Core allow requesting Rocket Elevators systems to access and manipulate textual representations of web resources through a set of stateless, predefined uniform operations.

## Members of the team

- **[Alexandre Leblanc](https://github.com/CptnWookie)**

- **[Frimina Zaddi](https://github.com/frimina)**

- **[Rafaela_Schwarz](https://github.com/rafa-3111)**

- **[Saad eddine](https://github.com/saadeddinne)**

# API Endpoints

Below are described the REST endpoints available that you can use to connect Rocket Elevators information system to the equipment in operation throughout the territory served.

## Battery

### All

```html
https://alexleblanc-rocketelevators.xyz/api/Batteries
```

### Retrieving a specific Battery: Search by id.

```html
https://alexleblanc-rocketelevators.xyz/api/Batteries/{id}
```

### Retrieving the current status of a specific Battery

```html
https://alexleblanc-rocketelevators.xyz/api/Batteries/{id}/status
```

### Changing the status of a specific Battery (PUT request)

```html
https://alexleblanc-rocketelevators.xyz/api/Batteries/{id}/status
```

### Delete a specific Battery (Delete request)

```html
https://alexleblanc-rocketelevators.xyz/api/Batteries/{id}
```

<hr>

## Column

### All

```html
https://alexleblanc-rocketelevators.xyz/api/Columns/
```

### Retrieving a specific Column: Search by id.

```html
https://alexleblanc-rocketelevators.xyz/api/Columns/{id}
```

### Retrieving the current status of a specific Column

```html
https://alexleblanc-rocketelevators.xyz/api/Columns/{id}/status
```

### Changing the status of a specific Column (PUT request)

```html
https://alexleblanc-rocketelevators.xyz/api/Columns/{id}/status
```

### Delete a specific Battery (Delete request)

```html
https://alexleblanc-rocketelevators.xyz/api/Columns/{id}
```

<hr>

## Elevator

### All

```html
https://alexleblanc-rocketelevators.xyz/api/Elevators/
```

### Retrieving a specific Elevator: Search by id.

```html
https://alexleblanc-rocketelevators.xyz/api/Elevators/{id}
```

### Retrieving the current status of a specific Elevator

```html
https://alexleblanc-rocketelevators.xyz/api/Elevators/{id}/status
```

### Changing the status of a specific Elevator (PUT request)

```html
https://alexleblanc-rocketelevators.xyz/api/Elevators/{id}/status
```

### Retrieving a list of Elevators that are not in operation at the time of the request

```html
https://alexleblanc-rocketelevators.xyz/api/ElevatorsOff
```

### Delete a specific Elevator (Delete request)

```html
https://alexleblanc-rocketelevators.xyz/api/Elevators/{id}
```

<hr>

## Building

### Retrieving a list of Buildings that contain at least one battery, column or elevator requiring intervention

```html
https://alexleblanc-rocketelevators.xyz/api/BuildingsOff
```

<hr>

## Leads

### Retrieving a list of Leads created in the last 30 days who have not yet become customers.

```html
https://alexleblanc-rocketelevators.xyz/api/NotCostumers
```

<hr>

## Response Example

```html
https://alexleblanc-rocketelevators.xyz/api/Elevators/3
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
