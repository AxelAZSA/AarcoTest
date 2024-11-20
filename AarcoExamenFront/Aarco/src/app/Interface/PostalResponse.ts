export class PostalResponse {
    CatalogoJsonString!: string | null;
    Error!: string | null;
  }
  
  // Interfaces para deserializar el contenido de `CatalogoJsonString`
  export interface Catalogo {
    Municipio: Municipio;
    Ubicacion: Ubicacion[];
  }
  
  export interface Municipio {
    iIdMunicipio: number;
    Estado: Estado;
    iMunicipioEstado: number;
    iClaveMunicipioCepomex: number;
    sMunicipio: string;
  }
  
  export interface Estado {
    iIdEstado: number;
    Pais: any; // Cambiar a un tipo específico si es conocido
    iEstadoPais: number;
    iClaveEstadoCepomex: number;
    sEstado: string;
    sAbreviaturaEstado: string | null;
  }
  
  export interface Ubicacion {
    iIdUbicacion: number;
    CodigoPostal: any; // Cambiar a un tipo específico si es conocido
    iUbicacionCodigoPostal: number;
    TipoUbicacion: any; // Cambiar a un tipo específico si es conocido
    iClaveUbicacionCepomex: number;
    Ciudad: any; // Cambiar a un tipo específico si es conocido
    sUbicacion: string;
  }
  