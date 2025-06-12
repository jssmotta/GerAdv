import { IParceriaProc } from '../ParceriaProc/Interfaces/interface.ParceriaProc';
export interface ParceriaProc
{
    id: number;
	advogado : number;
	processo : number;
	nomeadvogados?: string;
	nropastaprocessos?: string;

}


export function ParceriaProcEmpty(): IParceriaProc {
// 20250604
    
    return {
        id: 0,
		advogado: 0,
		processo: 0,
    };
}

export function ParceriaProcTestEmpty(): IParceriaProc {
// 20250604
    
    return {
        id: 1,
		advogado: 1,
		processo: 1,
    };
}


