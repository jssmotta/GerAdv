namespace MenphisSI;
 
public static class TSql
{  
    public static string Embrace(in string cWhere) => cWhere.IsEmpty() ? string.Empty : $" ( {cWhere} ) ";  
  
    public static string And => " AND "; 
 
    public static string OR => " OR ";
    
    public static string Where => " WHERE ";
    
    public static string Select => " SELECT "; 
 
    public static string From => " FROM "; 
 
    public static string OrderBy => " ORDER BY ";  
     
    public static string Virgula => ", ";
    
}

