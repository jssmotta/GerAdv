import { IHonorariosDadosContrato } from '../HonorariosDadosContrato/Interfaces/interface.HonorariosDadosContrato';
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
	nomeclientes?: string;
	nropastaprocessos?: string;

}


export function HonorariosDadosContratoEmpty(): IHonorariosDadosContrato {
// 20250604
    
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
    };
}

export function HonorariosDadosContratoTestEmpty(): IHonorariosDadosContrato {
// 20250604
    
    return {
        id: 1,
		cliente: 1,
		processo: 1,
		fixo: true,
		variavel: true,
		percsucesso: 1,
		arquivocontrato: 'X',
		textocontrato: 'X',
		valorfixo: 1,
		observacao: 'X',
		datacontrato: 'X',
    };
}


