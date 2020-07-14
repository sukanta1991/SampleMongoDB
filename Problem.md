# Problem Statement

We are planning to build a small utility app for the user to maintain their tasks in the form of Notes.

This application will be having multiple users, so it's required to store the data specific to the user.

Right now we are building and testing data access layer to check the operations.

## Proposed Solution

In this phase, we'll make the use DocumentDB on cloud to store the data. DocumentDB allows and makes it
easy to store and query the data in nested form. Here we'll arrange the data with user details along with a 
collection of Notes.

### Note

AWS DocumentDB does not have an API for public access. To access the DocumentDB from your local machine, A EC2 instance has to be created in the same VPC as DocumentDB cluster. The AWS DocumentDB can be accessed from your local machine by creating an SSH tunnel with port forwarding to EC2 instance.

### The following tasks needs to be completed as part of the case study

  - Create a DocumentDB cluster with TLS disabled on AWS Cloud using AWS console
  - Create an EC2 instance in the same VPC as the DocumentDB cluster
  - Create an SSH Tunnel from your local machine to the EC2 instance
  - Implement the functionality based on the comments provided in base code
  - Ensure that all Test cases provided are successful for assignment completion  

### Tech Stack

    .NET Core 3.1
    AWS DocumentDB