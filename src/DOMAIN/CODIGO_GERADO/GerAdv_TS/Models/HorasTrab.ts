import { IHorasTrab } from '../HorasTrab/Interfaces/interface.HorasTrab';
export interface HorasTrab
{
    id: number;
	cliente : number;
	processo : number;
	advogado : number;
	funcionario : number;
	servico : number;
	idcontatocrm : number;
	honorario : boolean;
	idagenda : number;
	data : string;
	status : number;
	hrini : string;
	hrfim : string;
	tempo : number;
	valor : number;
	obs : string;
	anexo : string;
	anexocomp : string;
	anexounc : string;
	nomeclientes?: string;
	nropastaprocessos?: string;
	nomeadvogados?: string;
	nomefuncionarios?: string;
	descricaoservicos?: string;

}


export function HorasTrabEmpty(): IHorasTrab {
// 20250604
    
    return {
        id: 0,
		cliente: 0,
		processo: 0,
		advogado: 0,
		funcionario: 0,
		servico: 0,
		idcontatocrm: 0,
		honorario: false,
		idagenda: 0,
		data: '',
		status: 0,
		hrini: '',
		hrfim: '',
		tempo: 0,
		valor: 0,
		obs: '',
		anexo: '',
		anexocomp: '',
		anexounc: '',
    };
}

export function HorasTrabTestEmpty(): IHorasTrab {
// 20250604
    
    return {
        id: 1,
		cliente: 1,
		processo: 1,
		advogado: 1,
		funcionario: 1,
		servico: 1,
		idcontatocrm: 1,
		honorario: true,
		idagenda: 1,
		data: 'X',
		status: 1,
		hrini: 'X',
		hrfim: 'X',
		tempo: 1,
		valor: 1,
		obs: 'X',
		anexo: 'X',
		anexocomp: 'X',
		anexounc: 'X',
    };
}


