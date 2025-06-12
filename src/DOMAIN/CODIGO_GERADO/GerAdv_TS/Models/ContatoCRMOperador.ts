import { IContatoCRMOperador } from '../ContatoCRMOperador/Interfaces/interface.ContatoCRMOperador';
export interface ContatoCRMOperador
{
    id: number;
	contatocrm : number;
	operador : number;
	cargoesc : number;
	nomeoperador?: string;

}


export function ContatoCRMOperadorEmpty(): IContatoCRMOperador {
// 20250604
    
    return {
        id: 0,
		contatocrm: 0,
		operador: 0,
		cargoesc: 0,
    };
}

export function ContatoCRMOperadorTestEmpty(): IContatoCRMOperador {
// 20250604
    
    return {
        id: 1,
		contatocrm: 1,
		operador: 1,
		cargoesc: 1,
    };
}


