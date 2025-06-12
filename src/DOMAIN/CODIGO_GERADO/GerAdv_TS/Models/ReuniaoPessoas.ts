import { IReuniaoPessoas } from '../ReuniaoPessoas/Interfaces/interface.ReuniaoPessoas';
export interface ReuniaoPessoas
{
    id: number;
	reuniao : number;
	operador : number;
	nomeoperador?: string;

}


export function ReuniaoPessoasEmpty(): IReuniaoPessoas {
// 20250604
    
    return {
        id: 0,
		reuniao: 0,
		operador: 0,
    };
}

export function ReuniaoPessoasTestEmpty(): IReuniaoPessoas {
// 20250604
    
    return {
        id: 1,
		reuniao: 1,
		operador: 1,
    };
}


