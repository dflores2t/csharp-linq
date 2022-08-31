namespace OperacionesBasicas;

public class CEstudiante{
  private string _nombre;
  private string _id;
  private string _curso;
  private double _promedio;

  public string Nombre { get=> _nombre; set=> _nombre = value; }
  public string Id { get => _id; set => _id = value; }
  public string Curso { get=> _curso; set=> _curso =value; }
  public double Promedio { get=> _promedio; set=> _promedio = value; }

  public CEstudiante(string pNombre, string pId,string pCurso,double pPromedio)
  {
    _nombre = pNombre;
    _id = pId;
    _curso = pCurso;
    _promedio = pPromedio;
  }

  public override string ToString()
  {
    return string.Format("Nombre:{0}, {1}, Curso: {2}, Promedio: {3}", _nombre, _id, _curso, _promedio);
  }
}