
# Countries Service with Hangfire  

Get real-time information about countries via a RESTful API integrated with Hangfire for efficient background task processing.  

## Overview  

The **GetCountries** endpoint retrieves a comprehensive list of countries. The service ensures availability by prioritizing data sources in the following order:  
1. **Cache** (for quick access).  
2. **Database** (for reliable storage).  
3. **External API** (fallback for the latest information).  

If none of the sources are available, the service gracefully handles errors and provides appropriate responses.  

---

## Steps  

### Call the API Endpoint  

#### HTTP Method: `GET`  
#### URL: `/get-countries`  

### Response  

- **Success (200 OK)**:  
  Returns a JSON list of country data.  

- **Error (500 Internal Server Error)**:  
  Returns an error message if the service encounters an issue.  

---

## Hangfire Integration  

### What is Hangfire?  
Hangfire is a powerful library for background job processing in .NET applications. It enables the execution of tasks without blocking the main application thread. These tasks can be scheduled to run at specific intervals or as one-time jobs.  

### Why Use Hangfire in Countries Service?  
Integrating Hangfire into the **Countries Service** ensures smooth and efficient handling of background processes, including:  

- **Regular Data Updates**:  
  The country-fetching logic in the `CountryService` can be scheduled to run periodically (e.g., every 30 minutes) to keep the database and cache updated with the latest country information.  

- **Improved Performance**:  
  Fetching data from external APIs or performing database updates can be time-consuming. Hangfire ensures that these resource-intensive operations are offloaded to background workers, keeping the main application responsive.  

- **Reliability and Resilience**:  
  Hangfire provides:  
  - **Automatic Retries**: Retries failed jobs to ensure successful execution.  
  - **Job Logging**: Tracks progress and execution status.  
  - **Persistence**: Ensures tasks are not lost even if the application restarts.  

---

### Key Advantages of Hangfire Integration  

1. **Avoid Stale Data**:  
   With automatic and regular updates, the service ensures the database and cache always contain fresh country information.  

2. **Enhanced User Experience**:  
   By handling intensive tasks in the background, the application remains fast and responsive.  

3. **Reduced Operational Overhead**:  
   Eliminates the need for manual triggers, reducing the risk of bottlenecks or stale data.  

4. **Seamless Recovery**:  
   Failed jobs are automatically retried, and progress is logged for easy monitoring.  

---

## Example Workflow with Hangfire  

1. A recurring Hangfire job fetches country data from the external API every 30 minutes.  
2. The data is stored in the database and cached for quick retrieval.  
3. Users accessing the `/get-countries` endpoint receive data from the cache or database, ensuring fast response times.  

By offloading this logic to Hangfire, the main application is free to handle user requests without delays caused by data-fetching operations.  

--- 

This approach ensures that the **Countries Service** is highly efficient, scalable, and user-friendly, meeting the demands of real-time country information retrieval.  

## Get Second Largest Number

This endpoint retrieves the second largest unique integer from an array provided in the request body.

### Endpoint

**HTTP Method**: `POST`  
**URL**: `/second-largest`  

### Request

**Body**:  
A JSON object with the following structure:
```json
{
    "RequestArrayObj": [1, 2, 3, 4]
}
```

- **RequestArrayObj**: An array of integers with at least two elements.

### Response

- **Success (200 OK)**:  
  Returns the second largest unique integer from the array.

  Example:  
  Input: `[1, 2, 3, 4]`  
  Output: `3`  

- **Error (400 Bad Request)**:  
  - If the array has fewer than two elements:  
    `"Array must have at least two integers."`  
  - If the array does not have at least two unique integers:  
    `"Array must have at least two unique integers."`  

### Example Workflow

1. **Request**:  
   `POST /second-largest`  
   Body:  
   ```json
   {
       "RequestArrayObj": [7, 7, 3, 10]
   }
   ```

2. **Response**:  
   Status: `200 OK`  
   Body: `7`
