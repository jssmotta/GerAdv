import { IInstancia } from '../Instancia/Interfaces/interface.Instancia';
export interface Instancia
{
    id: number;
	processo : number;
	acao : number;
	foro : number;
	tiporecurso : number;
	liminarpedida : string;
	objeto : string;
	statusresultado : number;
	liminarpendente : boolean;
	interpusemosrecurso : boolean;
	liminarconcedida : boolean;
	liminarnegada : boolean;
	data : string;
	liminarparcial : boolean;
	liminarresultado : string;
	nroprocesso : string;
	divisao : number;
	liminarcliente : boolean;
	comarca : number;
	subdivisao : number;
	principal : boolean;
	zkey : string;
	zkeyquem : number;
	zkeyquando : string;
	nroantigo : string;
	accesscode : string;
	julgador : number;
	zkeyia : string;
	nropastaprocessos?: string;
	descricaoacao?: string;
	nomeforo?: string;
	descricaotiporecurso?: string;

}


export function InstanciaEmpty(): IInstancia {
// 20250604
    
    return {
        id: 0,
		processo: 0,
		acao: 0,
		foro: 0,
		tiporecurso: 0,
		liminarpedida: '',
		objeto: '',
		statusresultado: 0,
		liminarpendente: false,
		interpusemosrecurso: false,
		liminarconcedida: false,
		liminarnegada: false,
		data: '',
		liminarparcial: false,
		liminarresultado: '',
		nroprocesso: '',
		divisao: 0,
		liminarcliente: false,
		comarca: 0,
		subdivisao: 0,
		principal: false,
		zkey: '',
		zkeyquem: 0,
		zkeyquando: '',
		nroantigo: '',
		accesscode: '',
		julgador: 0,
		zkeyia: '',
    };
}

export function InstanciaTestEmpty(): IInstancia {
// 20250604
    
    return {
        id: 1,
		processo: 1,
		acao: 1,
		foro: 1,
		tiporecurso: 1,
		liminarpedida: 'X',
		objeto: 'X',
		statusresultado: 1,
		liminarpendente: true,
		interpusemosrecurso: true,
		liminarconcedida: true,
		liminarnegada: true,
		data: 'X',
		liminarparcial: true,
		liminarresultado: 'X',
		nroprocesso: 'X',
		divisao: 1,
		liminarcliente: true,
		comarca: 1,
		subdivisao: 1,
		principal: true,
		zkey: 'X',
		zkeyquem: 1,
		zkeyquando: 'X',
		nroantigo: 'X',
		accesscode: 'X',
		julgador: 1,
		zkeyia: 'X',
    };
}


