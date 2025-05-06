import { Auditor } from "./Auditor";

import { IHorasTrab } from "../HorasTrab/Interfaces/interface.HorasTrab";
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
	auditor?: Auditor | null;
}

export function HorasTrabEmpty(): IHorasTrab {
// 20250125
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
		auditor: null
    };
}
