import { IProcessOutputEngine } from '../ProcessOutputEngine/Interfaces/interface.ProcessOutputEngine';
export interface ProcessOutputEngine
{
    id: number;
	nome : string;
	database : string;
	tabela : string;
	campo : string;
	valor : string;
	output : string;
	administrador : boolean;
	outputsource : number;
	disableditem : boolean;
	idmodulo : number;
	isonlyprocesso : boolean;
	myid : number;

}


export function ProcessOutputEngineEmpty(): IProcessOutputEngine {
// 20250604
    
    return {
        id: 0,
		nome: '',
		database: '',
		tabela: '',
		campo: '',
		valor: '',
		output: '',
		administrador: false,
		outputsource: 0,
		disableditem: false,
		idmodulo: 0,
		isonlyprocesso: false,
		myid: 0,
    };
}

export function ProcessOutputEngineTestEmpty(): IProcessOutputEngine {
// 20250604
    
    return {
        id: 1,
		nome: 'X',
		database: 'X',
		tabela: 'X',
		campo: 'X',
		valor: 'X',
		output: 'X',
		administrador: true,
		outputsource: 1,
		disableditem: true,
		idmodulo: 1,
		isonlyprocesso: true,
		myid: 1,
    };
}


