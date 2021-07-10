export interface Fraccion {
  id: string;
  claveFraccion: string;
  descripcion: string;
  unidadMedida:	string;
  igi: string;
  ige: string;
  permisosFraccion?: PermisosFraccion[];
  nicos: string[];
  }

  export interface PermisosFraccion{
    id: string;
    permiso: string;
    acotacion: string;
  }

  