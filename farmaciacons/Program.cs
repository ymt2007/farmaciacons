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
public class Lote
{
    private string numeroLote;
    private DateTime fechaVencimiento;
    private int cantidad;
    public string NumeroLote
    {
        get { return numeroLote; }
        set
        {
            if (value == null || value == "")
                throw new ArgumentException("El numero de lote no puede estar vacio.");
            numeroLote = value;
        }
    }
    public DateTime FechaVencimiento
    {
        get { return fechaVencimiento; }
        set { fechaVencimiento = value; }
    }
    public int Cantidad
    {
        get { return cantidad; }
        set
        {
            if (value < 0)
                throw new ArgumentException("La cantidad no puede ser negativa.");
            cantidad = value;
        }
    }
    public Lote(string numeroLote, DateTime fechaVencimiento, int cantidad)
    {
        this.NumeroLote = numeroLote;
        this.FechaVencimiento = fechaVencimiento;
        this.Cantidad = cantidad;
    }
    public void Descontar(int unidades)
    {
        cantidad = cantidad - unidades;
    }
    public bool EstaVencido()
    {
        if (DateTime.Today >= fechaVencimiento)
            return true;
        else
            return false;
    }
    public int DiasParaVencer()
    {
        TimeSpan diferencia = fechaVencimiento - DateTime.Today;
        return (int)diferencia.TotalDays;
    }
    public bool EstaProximoAVencer(int dias)
    {
        if (DiasParaVencer() > 0 && DiasParaVencer() <= dias)
            return true;
        else
            return false;
    }
    public string ObtenerResumen()
    {
        return $"Lote: {numeroLote} | Vence: {fechaVencimiento:dd/MM/yyyy} | Cantidad: {cantidad} uds";
    }
}