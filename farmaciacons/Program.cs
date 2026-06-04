using System;
using System.IO;
using System.Collections.Generic;

public class ItemFarmacia
{
    private string codigo;
    private string nombre;
    private decimal precio;
    private bool activo;
    public string Codigo
    {
        get { return codigo; }
        set
        {
            if (value == null || value == "")
                throw new ArgumentException("El codigo no puede estar vacio.");
            codigo = value;
        }
    }

    public string Nombre
    {
        get { return nombre; }
        set
        {
            if (value == null || value == "")
                throw new ArgumentException("El nombre no puede estar vacio.");
            nombre = value;
        }
    }
    public decimal Precio
    {
        get { return precio; }
        set
        {
            if (value < 0)
                throw new ArgumentException("El precio no puede ser negativo.");
            precio = value;
        }
    }
    public bool Activo
    {
        get { return activo; }
        set { activo = value; }
    }
    public ItemFarmacia(string codigo, string nombre, decimal precio)
    {
        this.Codigo = codigo;
        this.Nombre = nombre;
        this.Precio = precio;
        this.activo = true;
    }
    public virtual string ObtenerTipo()
    {
        return "Item";
    }
    public virtual string ObtenerResumen()
    {
        return $"[{codigo}] {nombre} | Q{precio:F2}";
    }
}