import { Auditor } from "./Auditor";

import { IHonorariosDadosContrato } from "../HonorariosDadosContrato/Interfaces/interface.HonorariosDadosContrato";
export interface HonorariosDadosContrato
{
    id: number;
	cliente : number;
	processo : number;
	fixo : boolean;
	variavel : boolean;
	percsucesso : number;
	arquivocontrato : string;
	textocontrato : string;
	valorfixo : number;
	observacao : string;
	datacontrato : string;
	auditor?: Auditor | null;
}

export function HonorariosDadosContratoEmpty(): IHonorariosDadosContrato {
// 20250125
    return {
        id: 0,
		cliente: 0,
		processo: 0,
		fixo: false,
		variavel: false,
		percsucesso: 0,
		arquivocontrato: '',
		textocontrato: '',
		valorfixo: 0,
		observacao: '',
		datacontrato: '',
		auditor: null
    };
}
