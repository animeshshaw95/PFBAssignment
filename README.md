### Contains-All-Alphabets API Documentation

## Overview

# The Contains-All-Alphabets API checks whether a given string contains all alphabets.
# It returns a boolean indicating the result.

**Base URL**

The API is hosted at: http://localhost:5110/api/AlphabetChecker

**Endpoint**

POST /contains-all-alphabets

This endpoint evaluates if the input string contains all the letters.

**Request**

**Method**: POST

**Content-Type**: application/json

**Request Body**

The request body should contain a raw string in JSON format.

**Example**:

"abcdefghijklmnopqrstuvwxyz"

**Response**

**Content-Type**: application/json

Successful Response (200 OK)

Returns whether the input contains all the alphabets.

**Example**:

{
    "containsAllAlphabets": true
}

**Error Responses**

400 Bad Request: If the input is null, empty, or not provided.

**Example**:

{
    "title": "One or more validation errors occurred.",
    "status": 400,
    "detail": "Input cannot be null or empty."
}

500 Internal Server Error: If an unexpected error occurs.


**cURL**

curl -X POST \
  http://localhost:5110/api/AlphabetChecker/contains-all-alphabets \
  -H "Content-Type: application/json" \
  -d '"abcdefghijklmnopqrstuvwxyz"'

**Response**
{
    "containsAllAlphabets": true
}