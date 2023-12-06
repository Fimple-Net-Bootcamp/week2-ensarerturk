# Sky Weather API

This API provides fictitious weather information for various planets and moons. For example, we can provide weather data for celestial bodies such as Mars, Jupiter's moon Europa or Saturn's moon Titan. The API is designed according to REST principles and makes efficient use of HTTP methods and status codes.

## Project Structer

- **Controllers:** API controllers
- - **WeatherController:** A controller that handles weather-related HTTP requests.

- **Models:** Data models
- - **CelestialBody:** Basic model representing celestial bodies.
- - **Moon:** A model of the Moon derived from the CelestialBody class with special properties.
- - **Planet:** Planet model derived from the CelestialBody class with special properties.
- - **WeatherData:** Model representing weather data.

- **Repositories:** Classes that manage database operations
- - **ICelestialBodyRepository:** Interface defining database operations related to celestial bodies.
- - **CelestialBodyRepository:** Class that implements the ICelestialBodyRepository interface and performs database operations.

- **Services:** Classes that manage business logic operations
- - **ICelestialBodyService:** Interface defining business logic operations related to celestial bodies.
- - **CelestialBodyService:** Class that implements the `ICelestialBodyService` interface and performs business logic operations.
- - **IWeatherService:** Interface that defines business logic operations related to weather.
- - **WeatherService:** Class that implements the `IWeatherService` interface and performs business logic operations.

## API Endpoints

### 1. Fetch All Celestial Bodies and Weather Information

**Endpoint:**
```bash
GET  /api/v1/celestialbodies
```

**Parameters:**
- **`page` (Optional):** Page number, default value: 1.
- **`pageSize` (Optional):** Number of items to show per page, default value: 10.
- **`status` (Optional):** Celestial bodies status, for example: "active".
- **`sortBy` (Optional):** Sort criteria, for example: "name" or "gravity".
- **`sortAscending` (Optional):** Sort order, default value: true.

**Example Usage:**
```bash
GET /api/v1/celestialbodies?page=1&pageSize=10&status=active&sortBy=name&sortAscending=true
```

**Achievement Status:**

- `200 OK:` Successful request status.

**Failed Status:**

- `400 Bad Request:` In case of a bad request.
- `500 Internal Server Error:` In case of server error.

### 2. Retrieve Specific Celestial Body and Weather Information

**Endpoint:**
```bash
GET  /api/v1/celestialbodies/{name}
```

**Parameters:**
- **`name` (Required):** Name of a celestial body.

**Example Usage:**
```bash
GET /api/v1/celestialbodies/Mars
```

**Achievement Status:**

- `200 OK:` Successful request status.

**Failed Status:**

- `404 Not Found:` When a celestial body is not found.
- `500 Internal Server Error:` In case of server error.

### 3. Retrieve Weather Information for Specific Celestial Body

**Endpoint:**
```bash
GET  /api/v1/celestialbodies/{name}/weathers
```

**Parameters:**
- **`name` (Required):** Name of the celestial body.

**Example Usage:**
```bash
GET /api/v1/celestialbodies/Mars/weathers
```
**Achievement Status:**

- `200 OK:` Successful request status.

**Failed Status:**

- `404 Not Found:` When the celestial body could not be found.
- `500 Internal Server Error:` In case of server error.

### 4. Update the Weather on a Specific Celestial Body

**Endpoint:**
```bash
PUT  /api/v1/celestialbodies/{name}
```

**Parameters:**
- **`name` (Required):** Name of the celestial body.
- **Request Body:** Updated celestial body model.

**Example Usage:**
```bash
PUT  /api/v1/celestialbodies/Mars
```

**Achievement Status:**

- `200 OK:` Successful request status.

**Failed Status:**

- `404 Not Found:` When the celestial body could not be found.
- `500 Internal Server Error:` In case of server error.

### 5. Partially Update Weather on a Specific Celestial Body

**Endpoint:**
```bash
PATCH  /api/v1/celestialbodies/{name}
```

**Parameters:**
- **`name` (Required):** Name of the celestial body.
- **Request Body:** Partially updated celestial body model.

**Example Usage:**
```bash
PATCH /api/v1/celestialbodies/Mars
```

**Achievement Status:**

- `200 OK:` Successful request status.

**Failed Status:**

- `404 Not Found:` When the celestial body could not be found.
- `500 Internal Server Error:` In case of server error.

### 6. Delete Specific Celestial Body

**Endpoint:**
```bash
DELETE /api/v1/celestialbodies/{name}
```

**Parameters:**
- **`name` (Required):** Name of the celestial body.

**Example Usage:**
```bash
DELETE /api/v1/celestialbodies/Mars
```