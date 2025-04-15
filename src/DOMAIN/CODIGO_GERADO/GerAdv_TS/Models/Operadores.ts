import { Auditor } from "./Auditor";

import { IOperadores } from "../Operadores/Interfaces/interface.Operadores";
export interface Operadores
{
    id: number;
	cliente : number;
	enviado : boolean;
	casa : boolean;
	casaid : number;
	casacodigo : number;
	isnovo : boolean;
	grupo : number;
	nome : string;
	email : string;
	senha : string;
	ativado : boolean;
	atualizarsenha : boolean;
	senha256 : string;
	suportesenha256 : string;
	suportemaxage : string;
	auditor?: Auditor | null;
}

export function OperadoresEmpty(): IOperadores {
// 20250125
    return {
        id: 0,
		cliente: 0,
		enviado: false,
		casa: false,
		casaid: 0,
		casacodigo: 0,
		isnovo: false,
		grupo: 0,
		nome: '',
		email: '',
		senha: '',
		ativado: false,
		atualizarsenha: false,
		senha256: '',
		suportesenha256: '',
		suportemaxage: '',
		auditor: null
    };
}
