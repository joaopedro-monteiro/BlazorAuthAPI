﻿namespace BlazorAuth.Error
{
    public class ApiResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public List<Error>? Errors { get; set; }
    }
}
