## Institutions

### Institutions List
---
> GET /api/institutions

```
 GIVEN  : Anyone
 WHEN   : Reequests Institutions
 THEN   : Return List
```

#### Response
```
{
    "institutions": [
        {
            "name": "string",
            "code": "string"
        }
    ]
}
```

`Status codes: 200, 500`

### Institution Details
---
> GET /api/institutions/{institutionId}

```
 GIVEN  : Authenticated institution
 WHEN   : Requests details
 THEN   : Return details with students listing
```

#### Request

Name              | Type         | Description
------------------|--------------|------------
Authentication(*) | Header       | Bearer {string}
institutionId(*)  | Request path | {UUID}

#### Response
```
{
    "id": "string",
    "code": "string",
    "students": [
        {
            "id": "string",
            "name": "string",
            "registrationNumber": "string",
            "discountType": "integer"
        }
    ]
}
```

`Status codes: 200, 400, 404, 500`

### Register Institution
---
> POST /api/institutions

```
 GIVEN  : Anyone
 WHEN   : Registers Institution
 THEN   : Return Result
```

#### Request

Name              | Type         | Description
------------------|--------------|------------
Body(*)           | body         | {}

```
{
    "email": "string",
    "password": "string",
    "name": "string",
    "code": "string",
    "city": "string",
    "address": "string",
    "ownership": "string"
}
```

#### Response
```
{
    "name": "string",
    "code": "string"
}
```

`Status codes: 200, 500`

### Login Institution
---
> PUT /api/institutions

```
 GIVEN  : Anyone
 WHEN   : Authenticates Institution
 THEN   : Return Result
```

#### Request

Name              | Type         | Description
------------------|--------------|------------
Body(*)           | body         | {}

```
{
    "email": "string",
    "password": "string"
}
```

#### Response
```
{
    "id": "string",
    "token": "string",
    "tokenExpirationTime": "integer"
}
```

`Status codes: 200, 500`

### Send Institution Password Reset Instructions
---
> PATCH /api/institutions

```
 GIVEN  : Anyone
 WHEN   : Authenticates Institution
 THEN   : Return Result
```

#### Request

Name              | Type         | Description
------------------|--------------|------------
Body(*)           | body         | {}

```
{
    "email": "string"
}
```

#### Response

`Status codes: 200, 500`

### Reset Institution Password
---
> PATCH /api/institutions/reset

```
 GIVEN  : Anyone
 WHEN   : Authenticates Institution
 THEN   : Return Result
```

#### Request

Name              | Type         | Description
------------------|--------------|------------
Body(*)           | body         | {}

```
{
    "code": "string",
    "password": "string"
}
```

#### Response

`Status codes: 200, 500`

### Students Import
---
> POST /api/institutions/{institutionId}/students

```
 GIVEN  : Authenticated institution
 WHEN   : Uploads Excel file
 THEN   : Imports **new** students
```

#### Request

Name              | Type         | Description
------------------|--------------|------------
Authentication(*) | Header       | Bearer {string}
institutionId(*)  | Request path | {UUID}
Body(*)           | body         | .xlsx

`Status codes: 200, 400, 404, 500`

### Student Delete
---
> DELETE /api/institutions/{institutionId}/students/{studentId}

```
 GIVEN  : Authenticated institution
 WHEN   : Requests student removal
 THEN   : Delete student
```

#### Request

Name              | Type         | Description
------------------|--------------|------------
Authentication(*) | Header       | Bearer {string}
institutionId(*)  | Request path | {UUID}
studentId(*)      | Request path | {UUID}

`Status codes: 200, 400, 404, 500`

### Students Drop
---
> DELETE /api/institutions/{institutionId}/students

```
 GIVEN  : Authenticated institution
 WHEN   : Requests students drop
 THEN   : Remove all students
```

#### Request

Name              | Type         | Description
------------------|--------------|------------
Authentication(*) | Header       | Bearer {string}
institutionId(*)  | Request path | {UUID}


`Status codes: 200, 400, 404, 500`

## Manager

### Students Records List
---
> GET /api/manager

```
 GIVEN  : Manager
 WHEN   : Reequests Records
 THEN   : Return List
```

#### Request

Name              | Type         | Description
------------------|--------------|------------
Authentication(*) | Header       | Bearer {string}

#### Response
```
{
    "students": [
        {
            "name": "string",
            "registrationNumber": "string",
            "institution": "string",
            "institutionType": "string",
            "ticketCode": "string",
            "discountType": "integer"
        }
    ]
}
```

`Status codes: 200, 500`

### Login Manager
---
> PUT /api/manager

```
 GIVEN  : Anyone
 WHEN   : Authenticates Manager
 THEN   : Return Result
```

#### Request

Name              | Type         | Description
------------------|--------------|------------
Body(*)           | body         | {}

```
{
    "email": "string",
    "password": "string"
}
```

#### Response
```
{
    "id": "string",
    "token": "string",
    "tokenExpirationTime": "integer"
}
```

`Status codes: 200, 500`

## Network

### Network of available Institutions
---
> GET /api/network

```
 GIVEN  : Anyone
 WHEN   : Reequests Network
 THEN   : Return List of available Institutions to register
```

#### Response
```
{
    "network": [
        {
            "id": "string",
            "name": "string",
            "city": "string",
            "street": "string",
            "streetNo": "string",
            "ownership": "string",
            "ord": "integer" | null
        }
    ]
}
```

`Status codes: 200, 500`

## Students

### Student Details
---
> GET /api/students/{studentId}

```
 GIVEN  : Authenticated student
 WHEN   : Requests details
 THEN   : Return details
```

#### Request

Name              | Type         | Description
------------------|--------------|------------
Authentication(*) | Header       | Bearer {string}
studentId(*)      | Request path | {UUID}

#### Response
```
{
    "studentName": "string",
    "code": "string",
    "discountType": "integer",
    "createdAt": "string"
}
```

`Status codes: 200, 400, 404, 500`


### Login / Register Student
---
> POST /api/students

```
 GIVEN  : Anyone
 WHEN   : Authenticates or Registers Student
 THEN   : Return Result
```

#### Request

Name              | Type         | Description
------------------|--------------|------------
Body(*)           | body         | {}

```
{
    "email": "string",
    "password": "string",
    "registrationNumber": "string"
}
```

#### Response
```
{
    "id": "string",
    "token": "string",
    "tokenExpirationTime": "integer"
}
```

`Status codes: 200, 500`

### Send Student Password Reset Instructions
---
> PATCH /api/students

```
 GIVEN  : Anyone
 WHEN   : Authenticates Institution
 THEN   : Return Result
```

#### Request

Name              | Type         | Description
------------------|--------------|------------
Body(*)           | body         | {}

```
{
    "email": "string"
}
```

#### Response

`Status codes: 200, 500`

### Reset Student Password
---
> PATCH /api/students/reset

```
 GIVEN  : Anyone
 WHEN   : Authenticates Institution
 THEN   : Return Result
```

#### Request

Name              | Type         | Description
------------------|--------------|------------
Body(*)           | body         | {}

```
{
    "code": "string"
}
```

#### Response

`Status codes: 200, 500`