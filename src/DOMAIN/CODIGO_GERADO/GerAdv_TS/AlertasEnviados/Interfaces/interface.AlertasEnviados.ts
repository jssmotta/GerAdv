"use client";
export interface IAlertasEnviados {
// 202501251
    id: number;
 
		operador: number,
		alerta: number,
		dataalertado: string,
		visualizado: boolean,
}

export interface IAlertasEnviadosFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IAlertasEnviadosIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}