import { IAlertasEnviados } from '../AlertasEnviados/Interfaces/interface.AlertasEnviados';
export interface AlertasEnviados
{
    id: number;
	operador : number;
	alerta : number;
	dataalertado : string;
	visualizado : boolean;
	nomeoperador?: string;
	nomealertas?: string;

}


export function AlertasEnviadosEmpty(): IAlertasEnviados {
// 20250604
    
    return {
        id: 0,
		operador: 0,
		alerta: 0,
		dataalertado: '',
		visualizado: false,
    };
}

export function AlertasEnviadosTestEmpty(): IAlertasEnviados {
// 20250604
    
    return {
        id: 1,
		operador: 1,
		alerta: 1,
		dataalertado: 'X',
		visualizado: true,
    };
}


