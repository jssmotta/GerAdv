import { IAlertasEnviados } from "../AlertasEnviados/Interfaces/interface.AlertasEnviados";
export interface AlertasEnviados
{
    id: number;
	operador : number;
	alerta : number;
	dataalertado : string;
	visualizado : boolean;
}

export function AlertasEnviadosEmpty(): IAlertasEnviados {
// 20250125
    return {
        id: 0,
		operador: 0,
		alerta: 0,
		dataalertado: '',
		visualizado: false,
    };
}
