namespace QueryOperadores;

public class CEstudiante{
  private string _nombre;
  private int _id;
  // private string _curso;
  // private double _promedio;

  public string Nombre { get=> _nombre; set=> _nombre = value; }
  public int Id { get => _id; set => _id = value; }
  // public string Curso { get=> _curso; set=> _curso =value; }
  // public double Promedio { get=> _promedio; set=> _promedio = value; }

  public CEstudiante(string pNombre, int pId)
  {
    _nombre = pNombre;
    _id = pId;
  }

  public override string ToString()
  {
    return string.Format("Nombre:{0}, {1}", _nombre, _id);
  }
}

public class CCurso{
  private string curso;
  private int id;
  public CCurso(string pCurso, int pId)
  {
    curso = pCurso;
    id = pId;
  }

  public string Curso { get=> curso; set=> curso = value; }
  public int Id { get=>id; set=> id=value; }

  public override string ToString()
  {
    return string.Format("Curso -> {0}", curso);
  }
}