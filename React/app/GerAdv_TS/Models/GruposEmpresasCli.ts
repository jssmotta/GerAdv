import { IGruposEmpresasCli } from '../GruposEmpresasCli/Interfaces/interface.GruposEmpresasCli';
export interface GruposEmpresasCli
{
    id: number;
	grupo : number;
	cliente : number;
	oculto : boolean;
	descricaogruposempresas?: string;
	nomeclientes?: string;

}


export function GruposEmpresasCliEmpty(): IGruposEmpresasCli {
// 20250604
    
    return {
        id: 0,
		grupo: 0,
		cliente: 0,
		oculto: false,
    };
}

export function GruposEmpresasCliTestEmpty(): IGruposEmpresasCli {
// 20250604
    
    return {
        id: 1,
		grupo: 1,
		cliente: 1,
		oculto: true,
    };
}


