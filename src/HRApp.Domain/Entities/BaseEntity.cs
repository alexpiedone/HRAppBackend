﻿namespace HRApp.Domain;

public class BaseEntity
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public bool Active { get; set; } = true;
}
