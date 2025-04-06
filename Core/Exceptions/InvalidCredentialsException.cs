﻿namespace Core.Exceptions;

public class InvalidCredentialsException : Exception
{
    public InvalidCredentialsException() 
        : base("Invalid email or password")
    {
    }
}