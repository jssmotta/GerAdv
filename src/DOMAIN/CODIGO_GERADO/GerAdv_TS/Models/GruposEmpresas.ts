import { Auditor } from "./Auditor";

import { IGruposEmpresas } from "../GruposEmpresas/Interfaces/interface.GruposEmpresas";
export interface GruposEmpresas
{
    id: number;
	oponente : number;
	cliente : number;
	email : string;
	inativo : boolean;
	descricao : string;
	observacoes : string;
	icone : string;
	despesaunificada : boolean;
	auditor?: Auditor | null;
}

export function GruposEmpresasEmpty(): IGruposEmpresas {
// 20250125
    return {
        id: 0,
		oponente: 0,
		cliente: 0,
		email: '',
		inativo: false,
		descricao: '',
		observacoes: '',
		icone: '',
		despesaunificada: false,
		auditor: null
    };
}
