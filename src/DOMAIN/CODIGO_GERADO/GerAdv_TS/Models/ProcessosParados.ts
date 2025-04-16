import { IProcessosParados } from "../ProcessosParados/Interfaces/interface.ProcessosParados";
export interface ProcessosParados
{
    id: number;
	processo : number;
	operador : number;
	semana : number;
	ano : number;
	datahora : string;
	datahistorico : string;
	datanenotas : string;
}

export function ProcessosParadosEmpty(): IProcessosParados {
// 20250125
    return {
        id: 0,
		processo: 0,
		operador: 0,
		semana: 0,
		ano: 0,
		datahora: '',
		datahistorico: '',
		datanenotas: '',
    };
}
