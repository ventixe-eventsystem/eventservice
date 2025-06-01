﻿namespace Business.Models;
public class PackageModel
{
  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public decimal Price { get; set; }
  public string Type { get; set; } = null!;
  public string Description { get; set; } = null!;
}
